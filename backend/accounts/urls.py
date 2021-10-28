from django.urls import path
from . import views
from rest_framework_jwt.views import obtain_jwt_token


urlpatterns = [
    path('signup/', views.signup),
    path('login/', views.login),
    path('logout/', views.logout),
    path('withdraw/<str:username>/', views.withdraw),
    path('profile/<str:username>/', views.profile)
]