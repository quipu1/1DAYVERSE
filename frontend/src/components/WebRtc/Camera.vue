<template>
  <div id="CameraRoot">
    <div class="cam-content-box">
      <user-video :stream-manager="datas.publisher"></user-video>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import UserVideo from '@/components/WebRtc/UserVideo.vue'
axios.defaults.headers.post['Content-Type'] = 'application/json';
export default {
  name: 'Camera',
  components: {
    UserVideo,
  },
  props: {
    data: Object,
    location: String,
  },
  data() {
    return {
      screenShare : false,
      datas: {},
    }
  },
  created() {
    this.datas = this.data;
  },
  computed : {
    setWidth40 : function(){
      if(this.data.subscribers.length < 2 && !this.data.share.active){
        return true;
      }
      return false;
    },
    setWidth30 : function(){
      if(this.data.subscribers.length >= 2 && !this.data.share.active){
        return true;
      }
      return false;
    },
    next : function(){
      if((!this.data.share.active && this.data.subscribers.length+1 - (this.page+1)*6 > 0 ) || (this.data.share.active && this.data.subscribers.length+1 - (this.page+1)*4 > 0 )){
        return true;
      }
      return false;
    },
    prev : function(){
      if(this.page > 0){
        return true;
      }
      return false;
    },
    totalPage : function(){
      let remain = (this.data.subscribers.length+1)%6;
      if(remain != 0){
        return (this.data.subscribers.length+1)/6+1;
      }
      return (this.data.subscribers.length+1)/6;
    },
    pageSub : function(){
      if(this.page == 0){
        if(!this.data.share.active){
          return this.data.subscribers.slice(0,5);
        }
        return this.data.subscribers.slice(0,3);
      }else{
        if(!this.data.share.active){
          return this.data.subscribers.slice(this.page*5, Math.min(this.page*5+6,this.data.subscribers.length));
        }
        return this.data.subscribers.slice(this.page*3, Math.min(this.page*3+4,this.data.subscribers.length));
      }
    },
  },

  methods: {
    updateMainVideoStreamManager (stream) {
			if (this.datas.mainStreamManager === stream) return;
			this.datas.mainStreamManager = stream;
		},
    updateStream(type) {
      this.$emit('updateStream', type);
    },
    shareScreen() {
      let screen = this.datas.OV.initPublisher(undefined, {
        resolution: "1280x720",
        videoSource: "screen",
        publishAudio: this.datas.setting.publishAudio,
      });

      screen.once('accessAllowed', () => {
        screen.stream
          .getMediaStream()
          .getVideoTracks()[0]
          .addEventListener('ended', () => {
            this.datas.session.unpublish(screen);
            this.screenShare = false;
            this.datas.share.active = false;
            this.datas.share.screen = undefined;
            this.datas.session.publish(this.data.publisher);
          });

          this.datas.session.unpublish(this.datas.publisher);
          this.screenShare = true;
          this.datas.share.active = true;
          this.datas.share.screen = screen;
          this.datas.session.publish(this.datas.share.screen);

      })
      screen.once("accessDenied", () => {
        console.warn("ScreenShare: Access Denied");
      });

    },

    leaveSession() {
        this.datas.share.active = false;
        this.$emit('leaveSession');
    },

  },
}
</script>

<style>

</style>