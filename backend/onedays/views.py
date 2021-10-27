from decimal import Context
from django.shortcuts import get_list_or_404, get_object_or_404, render
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import serializers, status

from accounts.models import Tutor
from .models import Lecture
from .serializers import LectureListSerializer, LectureSerializer, LectureDetailSerializer

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


# 카테고리별 강의
@api_view(['GET'])
def category(request, c_num):
    lectures = get_list_or_404(Lecture.objects.filter(category=c_num))
    serializer = LectureListSerializer(lectures, many=True)
    return Response(serializer.data)


# 강의 세부정보
@api_view(['GET'])
def detail(request, l_num):
    lecture = get_object_or_404(Lecture.objects.filter(pk=l_num))
    serializer = LectureDetailSerializer(lecture)
    return Response(serializer.data)