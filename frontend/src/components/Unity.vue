<template>
<div id="UnityRoot" :class="{'mini-map':!showMap}" @click="goUnity">
  <div class="content-box">
    <div class="mini-map-box" v-if="!showMap">
      <p>교실로<br>돌아가기</p>
    </div>
    <div class="max-map-box">
      <!-- <unity id="unity"
          src = "/public/unity2/Build/webGL.json"
          unityLoader = "./public/unity2/Build/onedayverseBuild.loader.js"
          width="1280"
          height="600"
          /> -->
    </div>
  </div>
</div>
</template>

<script>
// import Unity from 'vue-unity-webgl';
export default {
  name: 'Unity',
  components: {
    // Unity,
  },
  computed: {
    showMap: function() {
      if(this.$route.name === 'Study')
        return true;
      else 
        return false;
    },
  },
  methods: {
    goUnity(){
        if(!this.showMap){
            this.$router.push({name : "Study"});
        }
    },

  },
}
</script>

<style scoped>
iframe {
  width: 100px !important;
  height: 100px !important;
}
.unity-box {
  border: none;
  background: none;
  height: 90vh;
  width: 100%;
  display: flex;
  justify-content: center;
  margin-top: 3vh;
}
.mini-map-box {
  position: fixed;
  right: 5px;
  bottom: 75px;
  width: 70px;
  height: 100px;
  z-index: 95;
  position: absolute;
  background: rgba(255,255,255,0.5);
}
</style>