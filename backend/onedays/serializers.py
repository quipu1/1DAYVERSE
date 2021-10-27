from django.db import models
from django.db.models import fields
from rest_framework import serializers
from rest_framework.exceptions import ValidationError
from django.contrib.auth import get_user_model
import re

from .models import Lecture

class LectureSerializer(serializers.ModelSerializer):
    class Meta:
        model = Lecture
        fields = '__all__'


class LectureListSerializer(serializers.ModelSerializer):
    
    class Meta:
        model = Lecture
        fields = ('id', 'name', 'description', 'main_image')


class LectureDetailSerializer(serializers.ModelSerializer):

    class Meta:
        model = Lecture
        exclude = ('password',)