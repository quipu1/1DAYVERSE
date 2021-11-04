<template>
<div v-if="streamManager">
	<div v-if="streamManager.stream.videoActive" class="active-user">
		<ov-video :stream-manager="streamManager"/>
	</div>
  <div v-else class="inactive-user">
    <div v-if="!streamManager.stream.videoActive" class="inactive-user-img">
      <img src="@/assets/default_user.png" alt="user">
    </div>
    <div  class="inactive-user-info">
      <p v-if="!streamManager.stream.videoActive" class="inactive-icon"><i class="fas fa-video-slash"></i></p>
      <p v-if="!streamManager.stream.audioActive" class="inactive-icon"><i class="fas fa-microphone-slash"></i></p>
    </div>
  </div>
	<div class="user-name"><span>{{ clientData }}</span></div>
</div>
</template>

<script>
import OvVideo from '@/components/WebRtc/OvVideo';

export default {
	name: 'UserVideo',

	components: {
		OvVideo,
	},

	props: {
		streamManager: Object,
	},

	computed: {
		clientData () {
			const { clientData } = this.getConnectionData();
      const username = clientData.username;
			return username;
		},
    clientImage () {
      const { clientData } = this.getConnectionData();
      const userimg = clientData.userimg;
			return userimg;
    }
	},

	methods: {
		getConnectionData () {
			const { connection } = this.streamManager.stream;
			return JSON.parse(connection.data);
		},
	},
};
</script>
<style lang="scss" scoped>
@import "../../styles/UserVideo.scss";
	
</style>