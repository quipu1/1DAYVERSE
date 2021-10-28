<template>
  <div class="warp">
    <Navbar/>
    <main @click="shutDown" >    
      <div v-if="loading">
        <h1>로딩 중..</h1>
      </div>
      <div v-else-if="lectures.length > 0">
        <h1>강의 목록</h1>
      </div>
      <div v-else>
        <h1>강의가 없습니다.</h1>
      </div>
      <div id="lectureContainer">
        <Lecture
          v-for="(lecture,idx) in lectures"
          :key="idx"
          :lecture="lecture"
        />
      </div>
    </main>

    <Footer/>
  </div>
</template>

<script>
import axios from 'axios'
import Navbar from '@/components/Navbar.vue'
import Lecture from '@/components/Lecture.vue'
import Footer from '@/components/Footer.vue'

export default {
  name : "Category",
  props : ["keyword"],
  components : {
    Navbar,
    Lecture,
    Footer,
  },
  data(){
    return {
      lectures : "",
      loading  : false,
    }
  },
  
  created(){
    
    axios.get(`http://127.0.0.1:8000/od/onedays/searchq=${this.keyword}`)
    .then((res)=>{
      console.log(res)
    })
  },
  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
    },

   },

}
</script>

<style scoped>
.warp{
  position: relative;
  width: 100%;
  height: 100%;
}
main{
  text-align: center;
  height: 100vh;
}
#lectureContainer{
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  justify-content:center;
  align-items: flex-start;
  justify-items: center;
  gap: 2.5%;
  padding: 0 5%;
  height: 100%;
  margin-top: 5%;
}
</style>