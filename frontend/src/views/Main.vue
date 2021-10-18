<template>
  <div>
    <Navbar/>
    <main>
      <section>
        <div class="content-text">
          배움이 있는 메타버스의 세계
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
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'

export default {
  name : "Main",
  components : {
    Navbar,
  }
}
</script>

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