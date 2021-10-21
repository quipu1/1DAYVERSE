<template>
  <div class="warp">
    <Navbar/>
    <main>
      <div id="ClassCreateForm">
        <div id="selectTable">
          <div class="select-component" @click="onClickBtn">강의 제목</div>
          <div class="select-component" @click="onClickBtn">카테고리</div>
          <div class="select-component" @click="onClickBtn">강사명</div>
          <div class="select-component" @click="onClickBtn">강의 내용</div>
          <div class="select-component" @click="onClickBtn">강의 시간</div>
          <div class="select-component" @click="onClickBtn">강의 비용</div>
          <div class="select-component" @click="onClickBtn">강의 크기</div>
          <div class="select-component" @click="onClickBtn">강의 비밀번호</div>
        </div>
        <div id="selectedArea">
          <div v-if="idx==1">1</div>
          <div v-if="idx==2">2</div>
          <div v-if="idx==3">3</div>
          <div v-if="idx==3">4</div>
          <div v-if="idx==5">5</div>
          <div v-if="idx==6">6</div>
          <div v-if="idx==7">7</div>
          <div v-if="idx==8">8</div>
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
      idx : 1,
    }
  },
  methods : {
    onClickBtn(){
      // const list = document.querySelectorAll('.select')
      this.idx 
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
   .select-component:nth-child(1){
    border-right: 10px solid #FFEEF7;

   }
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