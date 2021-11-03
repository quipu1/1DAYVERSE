<template>
<Nav />
  <div id="LiveRoot">
    <div class="wrap">
      <!-- <web-cam /> -->
      <camera-setting />
    </div>
  </div>
</template>

<script>
// import WebCam from '@/components/WebRtc/WebCam';
import CameraSetting from '@/components/WebRtc/CameraSetting'
import Nav from '@/components/Navbar.vue'
export default {
  name : 'Live',
  components: {
    // WebCam,
    CameraSetting,
    Nav,
  },

}
</script>
<style scoped>

</style>