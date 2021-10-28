from django.shortcuts import get_object_or_404, render
from rest_framework.response import Response
from rest_framework.decorators import api_view
from rest_framework import status

from accounts.models import Tutee
from onedays.serializers import RegistrationSeralizer

# Create your views here.

def ready():
    pass


@api_view(['POST'])
def enroll(request):
    # 프론트에서 유저pk를 가져오면
    # 유저pk를 통해 튜티pk 가져오기
    userId = request.data['tutee']
    tutee = get_object_or_404(Tutee, user=userId)
    tuteeId = tutee.id

    # 튜티pk를 데이터에 새로 저장
    data = request.data.copy()
    data['tutee'] = tuteeId

    serializer = RegistrationSeralizer(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data)
    else:
        data = {
            'message': '올바르지 않은 형식입니다.'
        }
        return Response(data, status=status.HTTP_400_BAD_REQUEST)