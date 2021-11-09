<template>
  <div id="unity">
    <Navbar/>
    <iframe src="Unity/Build/index.html" frameborder="0"></iframe>
  </div>  
</template>

<script>
import Navbar from '@/components/Navbar.vue'

export default {
  name: "Unity",
  components: {
    Navbar,
  },
  methods: {
  }

}
</script>

<style>
</style>