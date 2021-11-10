<template>
  <div id="WebCamRoot">
    <div id="session" v-if="data.session">
			<div id="video-container" class="col">
				<camera :data="data" :location="location" v-on:leaveSession="leaveSession" v-on:updateStream="updateStream" />
				<chat :data="data" v-on:send="send" />
			</div>
		</div>
  </div>
</template>

<script>
import axios from 'axios';
import { OpenVidu } from 'openvidu-browser';
import Camera from './Camera.vue';
import Chat from './Chat.vue';

axios.defaults.headers.post['Content-Type'] = 'application/json';

const OPENVIDU_SERVER_URL = "https://k5c202.p.ssafy.io:5443";
const OPENVIDU_SERVER_SECRET = "oneday";
export default {
  name: 'WebCam',
  components: {
    Camera,
    Chat,
  },
	props: {
		location: String,
	},
  data() {
    return {
			data: {
				OV: undefined,
				roomName: '',
				session: undefined,
				mainStreamManager: undefined,
				publisher: undefined,
				subscribers: [],
				participants: 1,
				setting: {
					audioSource: undefined, 
					videoSource: undefined, 
					publishAudio: false,  	
					publishVideo: false,  	
					resolution: '640x480',  
					frameRate: 30,			
					insertMode: 'APPEND',	
					mirror: false
				},
				// chat
				message: [],
				MessageBell: false,
				msgTime: '',
				// share screen
				share: {
					active: false,
					screen: undefined,
				},
			},
			user: {},
			lecture_id: 24,
    }
  },
  created() {
		this.user = this.$store.state.userStore;
		this.data.roomName = this.location + this.lecture_id + 'classRoom';
		this.data.setting.videoSource = this.$store.state.camStore.video;
		this.data.setting.audioSource = this.$store.state.camStore.audio;
    this.joinSession();
  },
  unmounted() {
      if (this.data.session) this.data.session.disconnect();

			this.data.session = undefined;
			this.data.mainStreamManager = undefined;
			this.data.publisher = undefined;
			this.data.subscribers = [];
			this.data.OV = undefined;
			this.data.message = [];
			this.data.share.active = false;
			this.data.share.screen = undefined;
    
  },
  methods: {
		joinSession () {
			this.data.OV = new OpenVidu();

			this.data.session = this.data.OV.initSession();

			this.data.session.on('streamCreated', ({ stream }) => {
				const subscriber = this.data.session.subscribe(stream);
				if(subscriber.stream.typeOfVideo === "SCREEN") {
					this.data.share.active = true;
					this.data.share.screen = subscriber;
				}
				this.data.subscribers.push(subscriber);
				this.data.participants = this.data.subscribers.length + 1;
			});

			this.data.session.on('streamDestroyed', ({ stream }) => {
				const index = this.data.subscribers.indexOf(stream.streamManager, 0);
				if(stream.typeOfVideo === "SCREEN") {
					this.data.share.active = false;
					this.data.share.screen = undefined;
				}
				if (index >= 0) {
					this.data.subscribers.splice(index, 1);
				}
				this.data.participants = this.data.subscribers.length + 1;
			});

			// Chat
			this.data.session.on('signal:my-chat', (event) => {
				this.data.message.push({sender: JSON.parse(event.from.data), message: event.data, time: this.msgTime});
				this.data.MessageBell = true;
			});

			this.data.session.on('exception', ({ exception }) => {
				console.warn(exception);
			});
			this.getToken(this.data.roomName).then(token => {
				this.data.session.connect(token, { clientData: this.user })
					.then(() => {


						let publisher = this.data.OV.initPublisher(undefined, this.data.setting);

						this.data.mainStreamManager = publisher;
						this.data.publisher = publisher;

						this.data.session.publish(this.data.publisher);
					})
					.catch(error => {
						console.log('There was an error connecting to the session:', error.code, error.message);
					});
			});

			window.addEventListener('beforeunload', this.leaveSession)
		},

		leaveSession () {
			if (this.data.session) this.data.session.disconnect();

			this.data.session = undefined;
			this.data.mainStreamManager = undefined;
			this.data.publisher = undefined;
			this.data.subscribers = [];
			this.data.OV = undefined;
			this.data.message = [];
			window.removeEventListener('beforeunload', this.leaveSession);
			this.$router.push('/unity');
		},

		updateMainVideoStreamManager (stream) {
			if (this.data.mainStreamManager === stream) return;
			this.data.mainStreamManager = stream;
		},

		getToken (roomName) {
			return this.createSession(roomName).then(sessionId => this.createToken(sessionId));
		},

		createSession (sessionId) {
			return new Promise((resolve, reject) => {
				axios
					.post(`${OPENVIDU_SERVER_URL}/openvidu/api/sessions`, JSON.stringify({
						customSessionId: sessionId,
					}), {
						auth: {
							username: 'OPENVIDUAPP',
							password: OPENVIDU_SERVER_SECRET,
						},
					})
					.then(response => response.data)
					.then(data => resolve(data.id))
					.catch(error => {
						if (error.response.status === 409) {
							resolve(sessionId);
						} else {
							console.warn(`No connection to OpenVidu Server. This may be a certificate error at ${OPENVIDU_SERVER_URL}`);
							if (window.confirm(`No connection to OpenVidu Server. This may be a certificate error at ${OPENVIDU_SERVER_URL}\n\nClick OK to navigate and accept it. If no certificate warning is shown, then check that your OpenVidu Server is up and running at "${OPENVIDU_SERVER_URL}"`)) {
								location.assign(`${OPENVIDU_SERVER_URL}/accept-certificate`);
							}
							reject(error.response);
						}
					});
			});
		},

		createToken (sessionId) {
			return new Promise((resolve, reject) => {
				axios
					.post(`${OPENVIDU_SERVER_URL}/openvidu/api/sessions/${sessionId}/connection`, {}, {
						auth: {
							username: 'OPENVIDUAPP',
							password: OPENVIDU_SERVER_SECRET,
						},
					})
					.then(response => response.data)
					.then(data => resolve(data.token))
					.catch(error => reject(error.response));
			});
		},

		// Chat
		send(sendMessage, sendTime) {
			this.msgTime = sendTime
			this.data.session.signal({
				data: sendMessage,
				to: [],
				type: 'my-chat'
			})
			.catch(error => {
					console.error(error);
			});
		},

		updateStream(type) {
			if(type == 1) {
				this.data.setting.publishAudio = !this.data.setting.publishAudio;
				this.data.publisher.publishAudio(this.data.setting.publishAudio);
			} else {
				this.data.setting.publishVideo = !this.data.setting.publishVideo;
				this.data.publisher.publishVideo(this.data.setting.publishVideo);
			}
		}
	}
}
</script>

<style lang="scss" scoped>
@import '../../styles/WebCam.scss';
</style>