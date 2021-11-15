<template>
  <div class="warp">
    <Navbar/>
    <main @click="shutDown">
      <div class="left">
        <div class="image-container">
          <i class></i>
          <img :src="`@/../../../backend${this.lecture.main_image}`" alt="" id="classImage">
        </div>
        <div>
          <p>{{lecture.description}}</p>
        </div>
      </div>
      <div class="right">
        <div class="class-info">
          <span v-if="lecture.category===1">운동</span>
          <span v-else-if="lecture.category===2">취미</span>
          <span v-else-if="lecture.category===3">언어</span>
          <span><b>{{lecture.title}}</b></span>
          <span>강사 : {{lecture.tutor}}</span>
          <span>모집 인원 : {{lecture.lecture_cnt}} / {{lecture.room_size}}명</span>
          <span>가격 : {{cost}}원</span>
        </div>
        <button v-if="!err_message" @click="Pay" id="payBtn">
          <img :src="PayImage" alt="">
        </button>
        <div v-else>{{ err_message }}</div>
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
  props : ["lecture_id"],
  components : {
    Navbar,
  },
  data(){
    return {
      PayImage : PayImage,
      lecture : "",
      cost : "",
      image : image,
      registerable: null,
    }
  },
  created(){
    axios.get(`https://k5c202.p.ssafy.io/od/onedays/lecture/detail/${this.lecture_id}`)
    .then((res)=>{
      this.lecture = res.data.detail
      this.cost = res.data.detail.price.toLocaleString('ko-KR')
    })
    const user_id = this.$store.getters["userStore/getUserId"]
    axios.get(`https://k5c202.p.ssafy.io/od/onedays/check/${user_id}/${this.lecture_id}`)
    .then((res) => 
      this.registerable = res.data
    )
    .catch((err) => console.log(err))
  },
  computed : {
    err_message() {
      if (this.registerable == false) {
        return '이미 등록한 강좌힙니다.'
      }
      else if (Number(this.lecture.lecture_cnt) >= Number(this.lecture.room_size)) {
        return '이미 마감된 강좌힙니다.'
      }
      return null
    }
  },

  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
    },
    Pay(){
      const Form = new FormData();
      Form.append("lecture_price", this.lecture.price)
      Form.append("lecture_title", this.lecture.title)
      Form.append("lecture_id", this.lecture.id)
      Form.append("user_id", this.$store.getters["userStore/getUsername"])
      axios.post("https://k5c202.p.ssafy.io/od/payments/ready/", Form)
      .then((res)=>{
        location.href = res.data
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
  font-size: 1.3rem;
  margin-bottom: 5%;
}
#payBtn{
  /* width: 100%; */
  /* height: 5%; */
  background-color: transparent;
  display: flex;
  justify-content: flex-start;
  border: none;
  cursor: pointer;
}
</style>