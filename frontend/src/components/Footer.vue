<template>
  <div class="box">
    <footer>
      <div class="footer">
        <div class="site">
          <img :src="require('@/assets/1DAYVERSE.png')" class="image" alt="">
        </div>
        <div class="team">
          <div class="member">
            <div>Park Jun Su<img :src="require('@/assets/github_logo.png')" alt=""></div>
            <div>Ryu Ji Woo<img :src="require('@/assets/github_logo.png')" alt=""></div>
            <div>Sung Ru Bi<img :src="require('@/assets/github_logo.png')" alt=""></div>
            <div>Yoon So Young<img :src="require('@/assets/github_logo.png')" alt=""></div>
            <div>Lee Hye Eun<img :src="require('@/assets/github_logo.png')" alt=""></div>
          </div>
        </div>
      </div>
      <p class="rights">© 1Dayverse | All Rights Reserved</p>
    </footer>
  </div>
</template>

<script>
export default {
  name: "Footer",
}
</script>

<style scoped>
.box {
  background-color: hsl(286, 32%, 22%);
  color: white;
  width: 100%;
  height: 8vh;
}
.footer 
{
  display: flex;
  width: 100%;
  padding: 0.3vh 0 0.3vh 0;
  margin: 0 0;
  justify-content: space-between;
}
.footer > div
{
  margin: 0 1vh;
}
.rights
{
  font-size: 1vh;
  margin: 0;
}
.site
{
  font-size: 0.6vh;
}
.image
{
  height: 5vh;
  margin: 0 auto;
}
.team
{
  font-size: 1.5vh;
  font-weight: bold;
  text-align: right;
}
.member
{
  font-weight: normal;
  display: flex;
}
.member > div 
{
  margin: 1vh 0 0 1vh;
  display: flex;
  font-size: 1.7vh;
}
div > img
{
  height: 2vh;
  margin: 0 0 0 0.2vh;
}
</style>

