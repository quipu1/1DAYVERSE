<template>
  <div class="warp">
    <Navbar/>
    <main>
      <div class="left">
        <div class="image-container">
          <i class></i>
          <img :src="cls.main_image" alt="" id="classImage">
        </div>
        <div>
          <p>{{cls.description}}</p>
        </div>
      </div>
      <div class="right">
        <div class="class-info">
          <span>취미</span>
          <span><b>{{cls.name}}</b></span>
          <span>강사 : {{cls.teacher}}</span>
          <span>모집 인원 : {{cls.size}}명</span>
          <span>가격 : {{cls.price.toLocaleString('ko-KR')}}원</span>
        </div>
        <button @clilck="pay" id="payBtn">
          <img :src="PayImage" alt="">
        </button>
      </div>
    </main>
  </div>  
</template>

<script>
import axios from 'axios'
import Navbar from '@/components/Navbar.vue'
import image from '@/assets/drawing_image.jpg'
import PayImage from '@/assets/payment_icon_yellow_medium.png'
export default {
  name : "ClassDetail",
  components : {
    Navbar,
  },
  data(){
    return {
      PayImage : PayImage,
      cls : {
        "main_image" : image,
        "name" : "윤소영의 그림 클래스",
        "teacher" : "윤소영",
        "description" : "그림 그리는 거 가르치는 강좌입니다. dddddddddddddddddddddddddddddddddddddㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁdddddddddddddddddddddd",
        "price" : 1000000,
        "size" : 20,
       }
    }
  },
  methods : {
    pay(){
      // const Form = new URLSearchParams();
      // Form.append("cid", "TC0ONETIME")
      // Form.append("partner_order_id", "1001")
      // Form.append("partner_user_id", "jira")
      // Form.append("item_name", "name")
      // Form.append("quantity", "1")
      // Form.append("total_amount", "10000")
      // Form.append("tax_free_amount" , "100")
      // Form.append("approval_url" , "https://developers.kakao.com/success")
      // Form.append("cancle_url" , "https://developers.kakao.com/fail")
      // Form.append("fail_url", "https://developers.kakao.com/cancel/")

      const Form = {
        "cid" : "TC0ONETIME",
        "partner_order_id" : "1001",
        "partner_user_id" : "jira",
        "item_name" : "이름",
        "quantity" : 1,
        "total_amount" : 10000,
        "tax_free_amount" : 100,
        "approval_url" : "https://developers.kakao.com/success",
        "cancel_url" : "https://developers.kakao.com/fail",
        "fail_url" : "https://developers.kakao.com/cancel",
      }

      const APP_ADMIN_KEY = "	0eb5333f6c1ef20cd388e6e954902b51"
      const Headers = {
        Authorization: `KakaoAK ${APP_ADMIN_KEY}`, 
        // 'Access-Control-Allow-Origin': '*', 
        'Content-type': "application/x-www-form-urlencoded;charset=utf-8",
        // "Accept" : " MediaType.APPLICATION_JSON_UTF8_VALUE",
      }

      axios.post('https://kapi.kakao.com/v1/payment/ready',null, {
        headers : Headers,
        params : Form,
      })
      .then((res)=>{
        console.log(res)
      })
      .catch((err)=>{
        console.log(err)
      })
      
    }
  }


}
</script>

<style scoped>
.warp{
  position: relative;
  width: 100%;
  height: 100%;
}
main{
  display: flex;
  background-color: lightgray;
  padding : 2% 5%;
  height: 100vh;
}
.left{
  display: flex;
  width: 50%;
  flex-direction: column;
  align-items: center;
  /* justify-content: center; */
}
.image-container {
  /* width: 50%; */
  width: auto;
  height: 40%;
  box-sizing: border-box;
  margin-bottom: 5%;

}

#classImage{
  /* width: 100%;/ */
  height: 100%;
}
.right{
  width: 50%;
  display: flex;
  flex-direction: column;
  /* justify-content: center; */
  align-items: center;
}
.class-info{
  display: flex;
  width: 100%;
  height: 40%;
  flex-direction: column;
  align-items: flex-start;
  justify-content: space-around;
  margin-bottom: 5%;
}
#payBtn{
  width: 100%;
  /* height: 5%; */
  background-color: transparent;
  border: none;
  cursor: pointer;
}
</style>