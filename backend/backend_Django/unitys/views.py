from django.contrib.auth import get_user_model, authenticate, login, logout
from django.shortcuts import get_list_or_404, get_object_or_404

# Create your views here.
from rest_framework import status
from rest_framework import serializers
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework.serializers import Serializer

from accounts.models import Tutee, Tutor, User
from accounts.serializers import ProfileSerializer, UserSerializer, ProfileModifySerializer
from onedays.models import Lecture
from onedays.serializers import ProfileLectureSerializer


# Create your views here.
@api_view(['POST'])
def user_info(request):
    data = {
        'request': request.data,
        'hi': 'hi'
    }
    print(data)
    print('djangodjangodjangoadjango')
    print('dkdkdkdkdkdkk')
    return Response(data)

