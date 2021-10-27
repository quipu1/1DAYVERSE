from decimal import Context
from django.shortcuts import get_object_or_404, render
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status

from accounts.models import Tutor
from .serializers import LectureSerializer

# 강의 등록
@api_view(['POST'])
def register(request):
    # 프론트에서 유저pk를 가져오면
    # 유저pk를 통해 튜터pk 가져오기
    userId = request.data['tutor']
    tutor = get_object_or_404(Tutor, user=userId)
    tutorId = tutor.id

    # 튜터pk를 데이터에 새로 저장
    data = request.data.copy()
    data['tutor'] = tutorId

    serializer = LectureSerializer(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    else:
        data = {
            'message': '올바르지 않은 형식입니다.'
        }
        return Response(data, status=status.HTTP_400_BAD_REQUEST)

