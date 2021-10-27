<template>
  <div class="warp">
    <Navbar/>
    <main>
      <h1>구매가 완료되었습니다.</h1>
    </main>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
// import axios from 'axios'

export default {
  name : "BuyDone",
  components : {
    Navbar,
  },
  data(){
    return {

    }
  },
  mounted(){
    // const link = document.location.href
    // var str = link.split('?')
    // var URLSearhParams =  new URLSearchParams(link.search);
    // console.log(str)
  },
}
</script>

<style scoped>

</style>