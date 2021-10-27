<template>
  <div class="box">
    <footer>
      <div>
        <div class="footer">
          <div class="site">
            <img :src="require('@/assets/1DAYVERSE.png')" class="image" alt="">
          </div>
          <div class="team">
            <div>
              Team
            </div>
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
      </div>
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
}
.footer 
{
  display: flex;
  width: 100%;
  padding: 0.3rem 0 0.3rem 0;
  margin: 0 0;
  justify-content: space-between;
}
.footer > div
{
  margin: 0 1rem;
}
.rights
{
  font-size: 0.8rem;
}
.site
{
  font-size: 0.5rem;
}
.image
{
  height: 7vh;
  margin: 0 auto;
}
.team
{
  font-size: 3vh;
  font-weight: bold;
  text-align: right;
}
.member
{
  font-size: 2vh;
  font-weight: normal;
  display: flex;
}
.member > div 
{
  margin: 0 0 0 1rem;
  display: flex;
}
div > img
{
  height: 3vh;
  margin: 0 0 0 0.2rem;
}
</style>

