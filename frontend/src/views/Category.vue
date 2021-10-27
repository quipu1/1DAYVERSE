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
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Lecture from '@/components/Lecture.vue'

export default {
  name : "Category",
  props : ["category"],
  components : {
    Navbar,
    Lecture,
  },
  data(){
    return {
      lectures : [
        {name : "1번강의", teacher : "1번", id: 1,},
        {name : "2번강의", teacher : "2번강", id : 2,},
        {name : "3번강의", teacher : "3번강사", id : 3},
        {name : "엄청나게 긴 강 오버플로우", teacher : "4번강사당", id : 4,},
        {name : "5번강의", teacher : "5번강사입니다", id : 5},
      ]
    }
  },
  created(){
    console.log(this.category)
  },
  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
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