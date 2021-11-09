<template>
  <div>
    <Navbar/>
    <main @click="shutDown">
      <section>
        <div class="content-text flex-column">
          <span>배움이 있는 메타버스의 세계</span>
          <button  id="goToUnityBtn" @click="goToUnity">유니티로 입장하기</button>
        </div>

        <div class="content-image">
          <img :src="require('@/assets/image0.jpg')" alt="" class="image">
        </div>
      </section>
      <section>
        <div class="content-text">
         <b>1dayverse</b>는 자신만의 캐릭터를 만들 수 있습니다.
        </div>
        <div class="content-image">
          <img :src="require('@/assets/image1.webp')" alt="" class="image">
        </div>
      </section>
      <section>
        <div class="content-text">
          원데이 클래스에 참여해보세요
        </div>
        <div class="content-image">
          <img :src="require('@/assets/image2.webp')" alt="" class="image">
        </div>
      </section>
    </main>
    <Footer/>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'

export default {
  name : "Main",
  components : {
    Navbar,
    Footer,
  },
  methods : {
    shutDown(){
      const dropdownBtn = document.querySelector(".dropdown-btn");
      const dropdownListContainer = document.querySelector(".dropdown-list-container");
      dropdownListContainer.style.display="none"
      dropdownBtn.style.backgroundColor="transparent"
    },
    goToUnity(){
      this.$router.push({name : "Study" })
    },
  }
}
</script>

<style>
@font-face {
    font-family: 'GmarketSansMedium';
    src: url('https://cdn.jsdelivr.net/gh/projectnoonnu/noonfonts_2001@1.1/GmarketSansMedium.woff') format('woff');
    font-weight: normal;
    font-style: normal;
}

* {
    font-family: 'GmarketSansMedium';
}
.main-pink{
  background-color: #C86B98;
}
.main-purple{
  background-color: #8D3DA5;
}
.main-blue{
  background-color: #202D91;
}

</style>

<style scoped>
*, *:before, *:after {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
main{
  width:100%;
  height: 100%;
  overflow: hidden;
  position: relative;
  /* height: 100vh; */
}
section {
  display: flex;
  padding: 10%;
  align-items: center;
  height:100%;
}
.flex-column{
  display: flex;
  flex-direction: column;
  align-items: center;
}
#goToUnityBtn{
  margin-top: 5%;
  width: 30%;
  line-height: 75px;
  border:none;
  cursor: pointer;
  border-radius: 15px;
  background-color: #C86B98;
}
#goToUnityBtn:hover{
  background-color: #202D91;
  color: white;
}
section:nth-child(1){
  background-color: rgb(255, 205, 243);
}
section:nth-child(2){
  background-color: rgb(244, 183, 237);
}
section:nth-child(3){
  background-color: rgb(223, 186, 255);
}
.content-text{
  width: 50%;
  font-size: 1.5rem;
  line-height: 100%;
  /* text-align: center; */
}
.content-image{
  width: 50%;
}
.image{
  width: 100%;
}
</style>