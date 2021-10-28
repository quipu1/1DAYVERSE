<template>
  <div class="warp">
    <Navbar/>
    <main @click="shutDown">
      <Lecture
        v-for="(lecture,idx) in lectures"
        :key="idx"
        :lecture="lecture"
      />
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
  props : ["group"],
  components : {
    Navbar,
    Lecture,
    Footer,
  },
  data(){
    return {
      lectures : []
    }
  },
  watch : {
    group : function() {
      return this.groupChange();
    }
  },
  
  created(){
    switch(this.group){
      case "health":
        axios.get("http://127.0.0.1:8000/od/onedays/category/1")
        .then((res)=>{this.lectures = res.data})
        break
      case "hobby":
        axios.get("http://127.0.0.1:8000/od/onedays/category/2")
        .then((res)=>{this.lectures = res.data})
        break
      case "lang":
        axios.get("http://127.0.0.1:8000/od/onedays/category/3")
        .then((res)=>{ this.lectures = res.data})
        break
    }
  },
  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
    },
    groupChange(){
      switch(this.group){
        case "health":
          axios.get("http://127.0.0.1:8000/od/onedays/category/1")
          .then((res)=>{this.lectures = res.data})
          break
        case "hobby":
          axios.get("http://127.0.0.1:8000/od/onedays/category/2")
          .then((res)=>{this.lectures = res.data})
          break
        case "lang":
          axios.get("http://127.0.0.1:8000/od/onedays/category/3")
          .then((res)=>{ this.lectures = res.data})
          break
      }
    },

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
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  justify-content:center;
  align-items: center;
  justify-items: center;
  gap: 2.5%;
  padding: 0 5%;
  height: 100%;
  margin-top: 5%;
}
</style>