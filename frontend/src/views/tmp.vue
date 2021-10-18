<template>
  <div>
    <div class="line"></div>
    <div class="hole"></div>
    <div class="box">
      <div class="id-card">
        <div class="job">
        </div>
        <div class="detail">
          <div class="profile">
            <img src="https://i.imgur.com/eCijVBe.png" alt="">
            <div class="info">
              <h2>hyeeun</h2>
              <h2>1998.06.12</h2>
              <h2>01012345678</h2>
            </div>
          </div>
          <div class="class-info">
            <h2>수강내역</h2>
            <h3>클래스1</h3>
            <h3>클래스2</h3>
            <h3>클래스3</h3>
          </div>
        </div>
        <div class="links-wrap">
          <a href=""><i class="fa fa-globe"></i></a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  
}
</script>

<style scoped>
.box {
  width: 800px;
  margin: 0 auto;
  background: rgb(255, 199, 248);
  padding: 2rem;
  border-radius: 15px;
  box-shadow: 0 5px 5px rgba(0,0,0,0.125);
}
.id-card {
  border-radius: 15px;
  /* background-color: transparent; */
  background-color: white;
}
.detail {
  display: flex;
}
img {
  height: 150px;
}
.profile {
  margin: auto 0;
}
.line {
  background-color: rgb(31, 31, 31);
  width: 50px;
  height: 150px;
  position: absolute;
  box-shadow: 0 5px 5px rgba(0,0,0,0.125);
}
.hole {
  background-color: white;
  width: 80px;
  height: 20px;
  position: absolute;
  border-radius: 50px;
}
</style>