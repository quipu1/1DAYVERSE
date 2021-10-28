<template>
  <div class="warp">
    <Navbar/>
    <main>
      <div class="left">
        <div class="image-container">
          <i class></i>
          <img :src="image" alt="" id="classImage">
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
          <span><b>{{lecture.name}}</b></span>
          <span>강사 : {{lecture.tutor}}</span>
          <span>모집 인원 : {{lecture.room_size}}명</span>
          <span>가격 : {{this.cost}}원</span>
        </div>
        <button @click="Pay" id="payBtn">
          <img :src="PayImage" alt="">
        </button>
      </div>
    </main>
    <Footer/>
  </div>  
</template>

<script>
import axios from 'axios'
import Navbar from '@/components/Navbar.vue'
import image from '@/assets/drawing_image.jpg'
import Footer from '@/components/Footer.vue'
import PayImage from '@/assets/payment_icon_yellow_medium.png'

export default {
  name : "ClassDetail",
  props : ["lecture_id"],
  components : {
    Navbar,
    Footer,
  },
  data(){
    return {
      PayImage : PayImage,
      lecture : "",
      // cost : "",
      image : image
    }
  },
  created(){
    axios.get(`http://127.0.0.1:8000/od/onedays/lecture/detail/${this.lecture_id}`)
    .then((res)=>{
      this.lecture = res.data
      console.log(res.data)
      this.$store.dispatch['lectureStore/GET_LECTURE', this.lecture]
    })
  },
  computed : {
    cost() {
      return this.lecture.price.toLocaleString('ko-KR')
    }
  },

  methods : {
    Pay(){
      axios.post("http://127.0.0.1:8000/od/payments/ready/")
      .then((res)=>{
        location.href = res.data.next_url
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