from django.http.response import HttpResponse
from django.shortcuts import get_object_or_404, render
from rest_framework.response import Response
from rest_framework.decorators import api_view
from rest_framework import status
import requests
from accounts.models import Tutee
from onedays.serializers import RegistrationSeralizer

# Create your views here.
@api_view(['POST'])
def ready(request):
    Form = request.data
    Front_URL = "http://localhost:3000/buy/"
    URL = 'https://kapi.kakao.com/v1/payment/ready'
    headers = {
        "Authorization": "KakaoAK " + "0eb5333f6c1ef20cd388e6e954902b51",   # 변경불가
        "Content-type": "application/x-www-form-urlencoded;charset=utf-8",  # 변경불가
    }
    params = {
        "cid": "TC0ONETIME",    # 테스트용 코드
        "partner_order_id": "1001",     # 주문번호
        "partner_user_id": "100",    # 유저 아이디
        "item_name": Form["lecture_title"],        # 구매 물품 이름
        "quantity": "1",                # 구매 물품 수량
        "total_amount": Form["lecture_price"],        # 구매 물품 가격
        "tax_free_amount": "0",         # 구매 물품 비과세
        "approval_url": Front_URL + "done/" + Form["lecture_id"] + "/",
        "cancel_url": Front_URL + "cancel/",
        "fail_url" : Front_URL + "fail/",
    }
    print(headers)
    # print(params)
    res = requests.post(URL, headers=headers, params=params)
    # print(res.body)

    next_url = res.json()['next_redirect_pc_url']   # 결제 페이지로 넘어갈 url을 저장
    return HttpResponse(next_url)
    # return 



@api_view(['POST'])
def enroll(request):
    # 프론트에서 유저pk를 가져오면
    # 유저pk를 통해 튜티pk 가져오기
    userId = request.data['tutee']
    tutee = get_object_or_404(Tutee, user=userId)
    tuteeId = tutee.id

    # 튜티pk를 데이터에 새로 저장
    data = request.data.copy()
    data['tutee'] = tuteeId

    serializer = RegistrationSeralizer(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data)
    else:
        data = {
            'message': '올바르지 않은 형식입니다.'
        }
        return Response(data, status=status.HTTP_400_BAD_REQUEST)