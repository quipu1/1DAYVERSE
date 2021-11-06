<template>
  <div id="CameraRoot">
    <div class="cam-content-box">
      <div id="share-container" v-if="datas.share.active">
        <div id="share-screen" v-if="datas.share.screen">
          <user-video class="flex-item screen-video" :stream-manager="datas.share.screen"></user-video>
        </div>
      </div>
      <div id="video-container" :class="{'flex-column': datas.share.active, 'screen-share' : data.share.active}">
        <div id="prev">
          <button class="webcam-button page-button" @click="page -= 1;" v-if="prev">
            <div v-if="!datas.share.active">fas fa-chevron-left</div>
            <div v-else>fas fa-angle-up</div>
          </button>
        </div>
        <div id="videos" :class="{'flex-column': datas.share.active}">
          <user-video :class="{publisher : true, 'flex-item': true, 'width-40': setWidth40, 'width-30' : setWidth30}" :stream-manager="datas.publisher" v-if="page == 0"></user-video>
          <user-video :class="{subscribers : true, 'flex-item': true, 'width-40': setWidth40, 'width-30' : setWidth30}" v-for="(sub, idx) in pageSub" :key="idx" :stream-manager="sub"></user-video>
        </div>
        <div id="next">
          <button class="webcam-button page-button" @click="page += 1;" v-if="next">
            <div v-if="!datas.share.active">fas fa-chevron-right</div>
            <div v-else>fas fa-angle-down</div>
          </button>
        </div>
      </div>
    </div>
    <div id="webcam-nav">
      <button id="btnSetvideo" @click="updateStream(0)" class="webcam-button">
          <div v-if="!datas.setting.publishVideo"><div id="unpublish-video">fas fa-video-slash</div></div>
          <div v-else><div id="publish-video">fas fa-video</div></div>
      </button>
      <button id="btnSetAudio" @click="updateStream(1)" class="webcam-button">
          <div v-if="!datas.setting.publishAudio"><div id="unpublish-audio">fas fa-microphone-slash</div></div>
          <div v-else><div id="publish-audio">fas fa-microphone</div></div>
      </button>
      <button id="btnShareScreen" @click="shareScreen" class="webcam-button">
        <div v-if="!screenShare"><div id="unpublish-screen">fas fa-upload</div></div>
        <div v-else><div id="publish-screen">fas fa-upload</div></div>
      </button>
      <button id="btnLeaveSession" @click="leaveSession" class="webcam-button"><div id="leave-session">fas fa-phone-alt</div></button>
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
      page: 0,
      screenShare : false,
      maxHeight : 0,
      datas: {},
    }
  },
  created() {
    this.datas = this.data;
  },
  mounted() {
    const target = document.querySelector('.cam-content-box')
    const targetRect = target.getBoundingClientRect();
    this.maxHeight = targetRect.height;
  },
  updated(){
    const screen = document.querySelector('.screen-video video');
    if(screen !== null) screen.setAttribute('style', `max-height:${this.maxHeight-80}px;`);
  },

  computed : {
    setWidth40 : function(){
      if(this.datas.subscribers.length < 2 && !this.datas.share.active){
        return true;
      }
      return false;
    },
    setWidth30 : function(){
      if(this.datas.subscribers.length >= 2 && !this.datas.share.active){
        return true;
      }
      return false;
    },
    next : function(){
      if((!this.datas.share.active && this.datas.subscribers.length+1 - (this.page+1)*6 > 0 ) || (this.data.share.active && this.data.subscribers.length+1 - (this.page+1)*4 > 0 )){
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
      let remain = (this.datas.subscribers.length+1)%6;
      if(remain != 0){
        return (this.datas.subscribers.length+1)/6+1;
      }
      return (this.datas.subscribers.length+1)/6;
    },
    pageSub : function(){
      if(this.page == 0){
        if(!this.datas.share.active){
          return this.datas.subscribers.slice(0,5);
        }
        return this.datas.subscribers.slice(0,3);
      }else{
        if(!this.datas.share.active){
          return this.datas.subscribers.slice(this.page*5, Math.min(this.page*5+6,this.data.subscribers.length));
        }
        return this.datas.subscribers.slice(this.page*3, Math.min(this.page*3+4,this.data.subscribers.length));
      }
    },
  },

  methods: {
    updateMainVideoStreamManager (stream) {
			if (this.datas.mainStreamManager === stream) return;
			this.datas.mainStreamManager = stream;
		},
    updateStream(type) {
      console.log("cam updateStream");
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