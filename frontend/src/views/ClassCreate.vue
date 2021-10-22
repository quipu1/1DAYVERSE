<template>
  <div class="warp">
    <Navbar/>
    <main>
      <div id="ClassCreateForm">
        <div id="selectTable">
          <div class="select-component" @click="onClickBtn('title')" get>강의 제목</div>
          <div class="select-component" @click="onClickBtn('category')">카테고리</div>
          <div class="select-component" @click="onClickBtn('tutor')">강사명</div>
          <div class="select-component" @click="onClickBtn('description')">강의 내용</div>
          <div class="select-component" @click="onClickBtn('time')">강의 시간</div>
          <div class="select-component" @click="onClickBtn('cost')">강의 비용</div>
          <div class="select-component" @click="onClickBtn('size')">강의 크기</div>
          <div class="select-component" @click="onClickBtn('password')">강의 비밀번호</div>
        </div>
        <div id="selectedArea">
          <div v-if="idx=='title'">1</div>
          <div v-if="idx=='category'">2</div>
          <div v-if="idx=='tutor'">3</div>
          <div v-if="idx=='description'">4</div>
          <div v-if="idx=='time'">5</div>
          <div v-if="idx=='cost'">6</div>
          <div v-if="idx=='size'">7</div>
          <div v-if="idx=='password'">8</div>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'

export default {
  name : "ClassCreate",
  components : {
    Navbar,
  },
  data(){
    return {
      idx : 'title',
    }
  },
  methods : {
    onClickBtn(content){
      // const list = document.querySelectorAll('.select')
      console.log(this.idx)
      this.idx =content
    },
  }

}
</script>

<style scoped>
  .warp{
    position : relative;
    width: 100%;
    height: 100%;
  }
  main{
    width: 100%;
    padding: 2% 0%;
    display: flex;
    justify-content: center;
    height: 80vh;
  }
  #ClassCreateForm{
    display: flex;
    position: relative;

    width: 90%;
    /* background-color: black; */

  }
  #selectTable{
    width: 20%;
    height: 100%;
    /* background-color: #FFEEF7; */

    display: grid;
    grid-template-rows: 8;
    justify-items: flex-end;
    align-items: center;
    /* justify-content: center; */
    gap: 1%;

    
  }
  .select-component{
    width: 100%;
    background-color: #FFEEF7;
    height: 100%;
    /* text-align: center; */
    cursor:pointer;
    display: flex;
    justify-content: center;
    align-items: center;
    border-right: 10px solid white;
  }
   /* .select-component:nth-child(1){
    border-right: 10px solid #FFEEF7;

   } */
   
  #selectedArea{
    width: 80%;
    background-color: #FFEEF7;
    
    display: flex;
    justify-content: center;
    align-items: center;
  }
  span {
    position: absolute;
    background-color: black;
    transform: translate(-50%, -50%);
    pointer-events: none;
    border-radius: 50%;
    animation: animate 1s linear infinite;

  }
  @keyframes animate{
    0%
    {
      width: 0px;
      height: 0px;
      opacity: 35%;
    }
    100%{ 
      width: 50px;
      height: 50px;
      opacity: 0%;
    }
  }
</style>