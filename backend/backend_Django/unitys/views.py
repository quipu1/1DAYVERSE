from django.contrib.auth import get_user_model, authenticate, login, logout
from django.shortcuts import get_list_or_404, get_object_or_404

# Create your views here.
from rest_framework import status
from rest_framework import serializers
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework.serializers import Serializer

from accounts.models import Tutee, Tutor, User, Character
from accounts.serializers import ProfileSerializer, UserSerializer, ProfileModifySerializer
from onedays.models import Lecture
from onedays.serializers import ProfileLectureSerializer


# Create your views here.
@api_view(['POST'])
def set_character(request):
    get_data = request.data

    # 유니티에서 받아온 데이터
    username = get_data['nickname']
    character = get_data['character']


    data = {
        'character': get_data['character'],
    }

    # 해당 유저에 데이터 저장
    user = get_object_or_404(User, username=username)
    user.character_id = request.POST.get('character')
    user.save()

    return Response(data)


# 유니티 캐릭터 등록
# @api_view(['POST'])
# def set_character(request):
#     data = request.data


#     return Response('hi')

