from django.shortcuts import render
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status


from django.views.decorators.http import require_GET, require_POST, require_http_methods

# Create your views here.
@api_view(['GET'])
def main(request):
    print('main')
    return Response({"status: login"}, status=status.HTTP_200_OK)
