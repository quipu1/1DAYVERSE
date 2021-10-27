<template>
    <nav>
    <div style="display:flex; align-items:center; width:50%; justify-content:space-around; padding:0 2.5%;">
      <img :src="logo" alt="" id="logoImage" @click="goToMainPage">
      <div style="display:flex; justify-content:center;" id="dropdown">
        <button @click="showMenu" class='dropdown-btn'>전체 카테고리 <i class="fas fa-caret-down" style="background-color:none; color:#EEAEF9;"></i></button>
        <div class='dropdown-list-container' style="display:none;">
          <a href="#" @click="goToHealthCategory">운동</a>
          <a href="#" @click="goToHobbyCategory">취미</a>
          <a href="#" @click="goToLanguageCategory">언어</a>
          <!-- <a href="#" @click="goToETCCategory">기타</a> -->
        </div>
      </div>
      <div class="btn" @click="makeClass"><span v-show="isTeacher">강의 생성</span></div>
    </div>
   <div style="display:flex; align-items:center; width:50%; justify-content:space-around; padding:0 2.5%;">
      <input id="inputTag" type="text" v-model="keyword" placeholder="검색어 입력"  @keyup.enter="search">
      <div class="btn"> 
        <span v-if="isLogin" @click="goToMyPage">내 정보</span>
        <span v-else @click="goToSignupPage">회원가입</span>
      </div>
      <div class="btn">
        <span v-if="isLogin" @click="logout">로그 아웃</span>
        <span v-else @click="login">로그인</span>
      </div>
    </div>
  </nav>
</template>

<script>

import logo from '@/assets/1DAYVERSE.png'
export default {
  name : "Navbar",
  data (){
    return {
      logo : logo,
      isTeacher : true,
      isLogin : false,
      keyword : "",
    }
  },
  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
    },
    showMenu(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      if (dropdownListContainer.style.display=="none"){
        dropdownListContainer.style.display="block";
        dropdownBtn.style.backgroundColor="#DBBFFF"
      }else{
        dropdownListContainer.style.display="none"
        dropdownBtn.style.backgroundColor="transparent"
      }
    },
    search(){
      alert(`${this.keyword}`)
    },
    makeClass(){
      this.$router.push({name : "LectureCreate"})
    },
    goToMyPage(){
      alert('내 정보 페이지로 이동')
    },
    goToSignupPage(){
      this.$router.push({name : "Singup"})
    },
    logout(){
      if(confirm('로그아웃 하시겠습니까?')){
        alert('로그아웃')
        this.$router.push({name : "Login"})
      }else{
        alert('취소 되었습니다.')
      }
    },
    login(){
      this.$router.push({name : "Login"})

    },
    goToMainPage(){
      this.$router.push({name : "Main"})

    },
    goToHealthCategory(){
      this.$router.push({name : "Category", params: {group : "health"}})
      this.shutDown();
    },
    goToHobbyCategory(){
      this.$router.push({name : "Category", params: {group : "hobby"}})
      this.shutDown();

    },
    goToLanguageCategory(){
      this.$router.push({name : "Category", params: {group : "lang"}})
      this.shutDown();

    }
  }

}
</script>

<style scoped>
nav{
  display: flex;
  justify-content: space-around;
  align-items: center;
  justify-items: center;
  width: 100%;
  background-color: #FFEEF7;
  height: 10%;
  /* margin-bottom: 5%; */
}
#logoImage{
  width: 30%;
  cursor: pointer;
}
#dropdown{
  width: 30%;
}

.dropdown-btn{
  border: none;
  font-size: 1.1rem;
  background-color:transparent;
  text-align: center;
  cursor:pointer;
}
.down-caret {
  width: 0;
  height: 0;
  border-style: solid;
  border-width: 5px 5px 0 5px;
  border-color: #ffffff transparent transparent transparent;
  display: inline-block;
  margin-left: 6px;
  top: -3px;
  position: relative;
  transform: rotate(0deg);
  transition: all .25s ease-in;
}
.dropdown-list-container{
  position: absolute;
  display: none;
  background-color:#ffffff;
  margin-top:2rem;
  transition: all .25s linear;
  border-radius: 5px;
  z-index: 10;
}
.dropdown-list-container a {
  font-size: 1.1rem;
  line-height: 40px;
  text-decoration: none;
  color:black;
  display: block;
  width: 200px;
  line-height: 75px;
  /* border-bottom: 1px solid black; */
  text-align: center;
  border-radius: 5px;

}
.dropdown-list-container a:hover{
  background-color: #DBBFFF;
}
#inputTag{
  width: 50%;
  font-size: 1.1rem;
  background-color: #DBBFFF;
  border:none;
  border-radius: 5px;
  text-align: center;
  line-height: 40px;
}
#inputTag:focus{
  border:none;
  outline: none;
}
.btn {
  width: 20%;
  font-size: 1.1rem;
  cursor:pointer;

}
</style>
