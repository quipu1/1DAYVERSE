from django.db import models
from django.contrib.auth.models import AbstractUser
from phonenumber_field.modelfields import PhoneNumberField

# Create your models here.
class User(AbstractUser):
    username = models.CharField(max_length=20, unique=True)
    email = models.EmailField(max_length=100)
    password = models.CharField(max_length=50)
    character = models.ForeignKey(Character, on_delete=models.CASCADE)
    profile_image = models.ImageField(blank=True)
    birth_day = models.DateField(blank=True)
    phone_number = PhoneNumberField()


class Teacher(User):
    validation = models.BooleanField()


class Student(User):
    pass

class Character(models.Model):
    pass