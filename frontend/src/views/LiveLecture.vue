<template>
  <div id="LiveRoot">
    <div class="content-box">
      <web-cam />
    </div>
  </div>
</template>

<script>
import WebCam from '@/components/WebRtc/WebCam';
export default {
  name : 'Live',
  components: {
    WebCam,
  },

}
</script>

<style lang="scss" scoped>

</style>