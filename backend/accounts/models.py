from django.db import models
from django.contrib.auth.models import AbstractUser
from phonenumber_field.modelfields import PhoneNumberField

class Character(models.Model):
    name = models.CharField(max_length=20)
    character_image = models.CharField(max_length=200)

# Create your models here.
class User(AbstractUser):
    username = models.CharField(max_length=20, unique=True)
    email = models.EmailField(max_length=100, unique=True)
    password = models.CharField(max_length=50)
    character = models.ForeignKey(Character, on_delete=models.CASCADE)
    profile_image = models.ImageField(blank=True)
    birth_day = models.CharField(max_length=15)
    phone_number = PhoneNumberField()
    teachable = models.IntegerField()
    

class Tutor(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)


class Tutee(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)

