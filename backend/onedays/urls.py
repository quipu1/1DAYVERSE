from django.urls import path
from . import views

urlpatterns = [
    path('register/', views.register),
    path('category/<int:c_num>', views.category),
    path('lecture/detail/<int:l_num>', views.detail),
    path('search/', views.search),
]