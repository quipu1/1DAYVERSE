<template>
  <div class="warp">
    <Navbar/>
    <main>
      <div id="ClassCreateForm">
        <div id="selectTable">
          <div class="select-component" @click="onClickBtn('title')" id="title" style="background-color:#202D91; color:white;">강의 제목</div>
          <div class="select-component" @click="onClickBtn('category')" id="category">카테고리</div>
          <div class="select-component" @click="onClickBtn('tutor')" id="tutor">강사명</div>
          <div class="select-component" @click="onClickBtn('description')" id="description">강의 내용</div>
          <div class="select-component" @click="onClickBtn('time')" id="time">강의 시간</div>
          <div class="select-component" @click="onClickBtn('cost')" id="cost">강의 비용</div>
          <div class="select-component" @click="onClickBtn('size')" id="size">강의 크기</div>
          <div class="select-component" @click="onClickBtn('password')" id="password">강의 비밀번호</div>
        </div>
        <div id="selectedArea">
          <section v-if="idx=='title'" class="section-content" id="classTitle" >
            <h1 class="section-header">
              <div></div> 
              강의의 클래스 이름 정하기 
              <button  @click="onClickBtn('category')">다음</button>
            </h1>
            <div class="section-container">
              <label>강의 이름</label>
              <input type="text" class="input-form" placeholder="10글자 미만으로 정해주세요" maxlength="10">
            </div>
          </section>
          <section v-if="idx=='category'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 카테고리 정하기 
              <button  @click="onClickBtn('tutor')">다음</button>
            </h1>
            <div class="section-container"> 
              <div class="category-card" id="excerciseCard" @click="selectCategory('excerciseCard')">
                <h3>운동</h3>
              </div>
              <div class="category-card" id="hobbyCard" @click="selectCategory('hobbyCard')">
                <h3>취미</h3>
              </div>
              <div class="category-card" id="langCard" @click="selectCategory('langCard')">
                <h3>언어</h3>
              </div>          
            </div>
          </section>
          <section v-if="idx=='tutor'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강사 이름 확인
              <button  @click="onClickBtn('description')">다음</button>
            </h1>
            <div class="section-container" id="tutorContent">
              <div class="profile-image">
                <img src="" alt="" class="tutor-image">
              </div>
              <div class="profile-content">
                <span>튜터 이름</span>
              </div>
            </div>
          </section>
          <section v-if="idx=='description'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 설명 입력 정하기 
              <button  @click="onClickBtn('time')">다음</button>
            </h1>
            <div class="section-container" id="lectureContent">
              <div class="content-row">
                <label>강의 사진</label>
                <input type="file" multiple>
              </div>
              <div class="content-row" style="height: 100%;">
                <label for="">강의 내용</label>
                <textarea type="text" class="input-form"></textarea>
              </div>
            </div>
          </section>
          <section v-if="idx=='time'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 시간 정하기 
              <button @click="onClickBtn('cost')">다음</button>
            </h1>
            <div class="section-container">
              <label>강의 시간</label>
              <input type="datetime-local" class="input-form" value="2021-10-15T10:20"> ~
              <input type="datetime-local" class="input-form" value="2021-10-22T10:20">
            </div>
          </section>
          <section v-if="idx=='cost'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 금액 정하기 
              <button  @click="onClickBtn('size')">다음</button>
            </h1>
            <div class="section-container">
              <label>강의 금액</label>
              <input type="number" class="input-form" v-model="cost" @keyup="commaCost(this)">
            </div>
          </section>
          <section v-if="idx=='size'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 클래스 이름 정하기 
              <button  @click="onClickBtn('category')">다음</button>
            </h1>
            <div class="section-container">
              <div class="class-card" id="smallCard" @click="selectSize('smallCard')">
                <h3>Small</h3>
              </div>
              <div class="class-card" id="mediumCard" @click="selectSize('mediumCard')">
                <h3>Medium</h3>
              </div>
              <div class="class-card" id="largeCard" @click="selectSize('largeCard')">
                <h3>Large</h3>
              </div>                
            </div>
          </section>
          <section v-if="idx=='password'" class="section-content">
            <h1 class="section-header">
              <div></div> 
              강의의 비밀번호 정하기 
              <button  @click="onSubmit">제출</button>
            </h1>
            <div class="section-container">
              <label>강의 비밀번호</label>
              <input type="text" class="input-form" placeholder="8글자 이하로 적어주세요" maxlength="8" >
            </div>
          </section>
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
      // cost : '',


    }
  },
  methods : {
    onClickBtn(content){
      const comps = document.getElementsByClassName("select-component")
    // border-right: ;
      
      for(let i = 0 ; i < comps.length;i++){
        comps[i].style.borderRight="10px solid white";  
        comps[i].style.backgroundColor=" #FFEEF7";
        comps[i].style.color="black"
      }
      document.getElementById(content).style.borderRight="10px solid white"
      
      document.getElementById(content).style.backgroundColor="#202D91"
      document.getElementById(content).style.color="white"



      this.idx =content
    },
    selectCategory(name){
      const cards = document.getElementsByClassName("category-card")
      for (let i  = 0; i< cards.length;i ++){cards[i].style.opacity = "1";}
      document.getElementById(name).style.opacity="0.5";
    },
    commaCost(){
      return 'W 1000'
    },
    selectSize(name){
      const cards = document.getElementsByClassName("class-card")
      for (let i  = 0; i< cards.length;i ++){cards[i].style.opacity = "1";}
      document.getElementById(name).style.opacity="0.5";

    },
    onSubmit(){
      alert('제출 되었습니다.')
      this.$router.go(0)
      
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
    padding: 2% 5%;
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
    width: 15%;
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
    cursor:pointer;
    display: flex;
    justify-content: center;
    align-items: center;
    border-right: 10px solid white;
    transition: 0.25s;
  }
   .select-component:hover{
    transform: scale(0.9);
   }
  #selectedArea{
    width: 75%;
    background-color: #FFEEF7;
    
    display:flex;
    justify-content: center;

    /* align-items: space-between; */
  }
  .section-content{
    padding: 2% 0;
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items:center;
    justify-content: space-between;
  }
  .section-header{
    /* top: 20%; */
    background-color: lightgray;
    width: 100%;
    height: 15%;
    font:bolder;
    border-radius: 15px;

    display: flex;
    justify-content: space-around;
    align-items: center;
    
  }
  .section-container{
    display: flex;
    width: 80%;
    height: 50%;
    padding: 2%;
    justify-content: space-between;
    align-items: center;
    background-color: lightgray;
    border-radius: 15px;

  }
  .section-container > label {
    width: 20%;
    font-size: 1.25rem;
    text-align: center;
  }
  .section-container > input{
    width: 70%;
    font-size: 1.25rem;
    font: bolder;
    border: none;
    border-radius: 15px;
    margin: 0 5%;
    text-align: center;
  }
  .section-container > input:focus{
    outline: none;
  }
  .category-card{
    background-color: lightgray;
    width: 30%;
    border: 1px solid black;
    border-radius: 15px;
    height: 100%;
    /* aspect-ratio: 1; */
    margin: 0 1%;

    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;

    transition: transform .25s;
  }
  #excerciseCard{
    background-color: orange;
  }
  #hobbyCard{
    background-color: royalblue;
  }
  #langCard{
    background-color: olive;
  }
  .category-card:hover{
    transform: scale(0.9);
  }
  #tutorContent{
    flex-direction: column;
    justify-content: space-around;
    align-items: center;
    /* height: 100%; */

  }
  .profile-image{
    background-color: azure;
    border-radius: 50%;
    width: 20%;
    aspect-ratio: 1;
  }
  .profile-content{
    background-color: aliceblue;
    width: 50%;
    height: 25%;
    font-size: 1.25rem;

    display: flex;
    justify-content: center;
    align-items: center;
  }
  #lectureContent{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
  }
  .content-row{
    width: 100%;
    display: flex;
    justify-content: space-around;
    align-items: center;
  }
  .content-row > label{
    width: 20%;
  }
  .content-row > input, textarea{
    width: 80%;
  }
  .content-row > textarea{
    height: 50%;
  }
  
  .class-card{
    background-color: lightgray;
    width: 30%;
    border: 1px solid black;
    border-radius: 15px;
    height: 100%;
    /* aspect-ratio: 1; */
    margin: 0 1%;

    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;

    transition: transform .25s;
  }
  #smallCard{
    background-color: orange;

  }
  #mediumCard{
    background-color: royalblue;
  }
  #largeCard{
    background-color: olive;
  }
  /* span {
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
  } */
</style>