from django.contrib.auth import get_user_model
from django.shortcuts import get_object_or_404

# Create your views here.
from rest_framework import status
from rest_framework.decorators import api_view
from rest_framework.response import Response
from .models import Tutee, Tutor, User
from .serializers import UserSerializer


@api_view(['POST'])
def signup(request):
	# Client에서 온 데이터를 받아서
    password = request.data.get('password')
    password_confirmation = request.data.get('passwordConfirmation')
		
	# 패스워드 일치 여부 체크
    if password != password_confirmation:
        return Response({'error': '비밀번호가 일치하지 않습니다.'}, status=status.HTTP_400_BAD_REQUEST)
		
	# UserSerializer를 통해 데이터 직렬화
    serializer = UserSerializer(data=request.data)
    
	# validation 작업 진행 -> password도 같이 직렬화 진행
    if serializer.is_valid(raise_exception=True):
        user = serializer.save()

        # 튜터, 튜티 나누기
        teachable = request.data.get('teachable')

        if teachable == "0":
            tutee = Tutee()
            tutee.user_id = user.id
            tutee.save()
        elif teachable == "1":
            tutor = Tutor()
            tutor.user_id = user.id
            tutor.save()
        else:
            return Response({'error': '강사/학생을 체크해주세요.'}, status=status.HTTP_400_BAD_REQUEST)

        # password는 직렬화 과정에는 포함 되지만 → 표현(response)할 때는 나타나지 않는다.
        return Response(serializer.data, status=status.HTTP_201_CREATED)

# @csrf_exempt
@api_view(['POST'])
def login(request):

    username = request.POST['username']
    password = request.POST['password']
    teachable = request.POST['teachable']

    if User.objects.filter(username=username).exists():
        getUser = User.objects.get(username=username)
        if getUser.teachable == int(teachable):
            if getUser.password == password:
                request.session['user'] = getUser.id
                return Response(request.session, status=status.HTTP_200_OK)
            else:
                return Response({'error': '비밀번호가 틀렸습니다.'}, status=status.HTTP_400_BAD_REQUEST)
        else:
            return Response({'error': '강사/학생 체크를 확인해주세요.'}, status=status.HTTP_400_BAD_REQUEST)
    else:
        return Response({'error': '존재하지 않는 id 입니다.'}, status=status.HTTP_400_BAD_REQUEST)


@api_view(['POST'])
def logout(request):
    request.session.pop('user')
    return Response({"status: logout"}, status=status.HTTP_200_OK)