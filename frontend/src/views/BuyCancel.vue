<template>
  <div class="warp">
    <Navbar/>
    <main>
      <h1>구매가 취소되었습니다.</h1>
    </main>
    <Footer/>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'

export default {
  name : "BuyCancel",
  components : {
    Navbar,
    Footer,
  },
  data(){
    return {

    }
  },
}
</script>

<style scoped>

</style>