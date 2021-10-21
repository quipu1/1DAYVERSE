<template>
  <div class="box">
    <footer>
      <div>
        <ul class="footer">
          <li class="site">
            <img :src="require('@/assets/1DAYVERSE.png')" class="image" alt="">
          </li>
          <li class="team">
            <div>
              Team
            </div>
            <ul class="member">
              <li>Park Jun Su<img :src="require('@/assets/github_logo.png')" alt=""></li>
              <li>Ryu Ji Woo<img :src="require('@/assets/github_logo.png')" alt=""></li>
              <li>Sung Ru Bi<img :src="require('@/assets/github_logo.png')" alt=""></li>
              <li>Yoon So Young<img :src="require('@/assets/github_logo.png')" alt=""></li>
              <li>Lee Hye Eun<img :src="require('@/assets/github_logo.png')" alt=""></li>
            </ul>
          </li>
        </ul>
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
  padding: 0.3rem 0;
  justify-content: space-between;
}
.footer > li
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
.member > li 
{
  margin: 0 0 0 1rem;
  display: flex;
}
li > img
{
  height: 3vh;
  margin: 0 0 0 0.2rem;
}
</style>

