<template>
  <div>
    <Navbar/>
    <div class="id-card" v-if="profilename == username">
      <div class="job">
        <h3 v-if="teachable === '1'" class="job-text">TUTEE ID</h3>
        <h3 v-else class="job-text">TUTOR ID</h3>
      </div>
      <div class="container grid grid-cols-1 md:grid-cols-6">
        <div class="profile">
          <img :src="require('@/assets/class1.jpeg')" class="user-image" alt="">
          <div class="profile-info">
            <button class="edit" @click="changemodal">
              <svg xmlns="http://www.w3.org/2000/svg" width="1.3rem" height="1.3rem" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
              </svg>
            </button>
            <h4>{{ username }}</h4>
            <h4>{{ birth }}</h4>
            <h4>{{ phone }}</h4>
          </div>
        </div>
        <div class="class-info">
          <h2 v-if="teachable === '0'">수강내역</h2>
          <h2 v-else>강의정보</h2>
          <div v-if="!lecture">아직 강의가 없어요😢</div>
          <div v-for="lecture, idx in lectures" :key="idx" class="lecture">
            {{ lecture }}
          </div>
        </div>
      </div>
    </div>
    <UpdateProfile
      v-if="modal && profilename == username"
      :modal="modal"
      @close="changemodal"
    />
    <div v-if="profilename != username" class="to-main-box center">
      <div class="to-main-text">
        권한이 없습니다.
      </div>
      <button class="to-main-btn" @click="toMain">To Main</button>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import UpdateProfile from '@/components/UpdateProfile'

export default {
  name: "Profile",
  data() {
    return {
      profilename: this.$route.params.username,
      modal: false,
    }
  },
  components: {
    Navbar,
    UpdateProfile,
  },
  created() {
    this.$store.dispatch('userStore/FETCH_PROFILE', this.profilename)
  },
  computed: {
    teachable() {
      return this.$store.getters['userStore/getUserTeachable']
    },
    username() {
      return this.$store.getters['userStore/getUsername'] 
    },
    birth() {
      return  this.$store.getters['userStore/getUserBirth'] 
    },
    phone() {
      return this.$store.getters['userStore/getUserPhone'] 
    },
    lectures() {
      return this.$store.getters['userStore/getUserLectures'] 
    },
  },
  methods: {
    changemodal() {
      this.modal = !this.modal
    },
    toMain() {
      this.$router.push({ name: 'Main'})
    },
  }
}
</script>

<style scoped>
.box
{
  display: flex;
  align-items: center;
  height: 100vh;
}
.id-card {
  height: 70vh;
  position: relative;
  background-color: white;
  width: 70%;
  max-width: 1500px;
  margin: 3rem auto;
  box-shadow: 1px 1px 20px 2px rgba(0,0,0,.3);
  border-radius: 20px;
  display: flex;
}
.container {
  width: 100%;
  position: absolute;
  top: 10vh;
  display: flex;
  text-align: center;
}
.job{
  width: 100%;
  background-color: #8D3DA5;
  height: 13vh;
  position: absolute;
  border-radius: 20px 20px 0 0;
  border-top: 5px solid rgba(153, 97, 160, 0.9);
  text-align: right;
}
.job-text {
  margin-right: 2rem;
  margin-top: 5vh;
  color: white;
  font-size: 3vh;
  font-weight: bold;
  text-align: right;
}
.profile {
  margin: 0 3rem;
  height: 51vh;
  font-weight: bold;
  font-size: 1.2rem;
}
.user-image {
  width: 20vw;
  height: 20vw;
  max-width: 200px;
  max-height: 200px;
  box-shadow: 1px 3px 10px 3px rgba(158, 158, 158, 0.3);
  margin: 1rem;
  border-radius: 100%;
}
.class-info {
  margin: 5vh 3rem 0 0;
  width: 100%;
  background-color: #d6c3db;
  padding: 1rem;
  border-radius: 10px;
  height: 50vh;
  overflow: scroll;
}
.lecture {
  margin: 1rem 0;
}
button {
  background-color: transparent !important;
  border: none;
  cursor: pointer;
}
.profile-info
{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.profile-info > h4, svg
{
  margin: 0.5rem 0;
}
.to-main-box
{
  position: absolute;
  top: 45vh;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.to-main-btn {
  width: 30%;
  height: 30px;
  margin: 0.5rem 12px;
  margin-bottom: 16px;
  border-radius: 30px;
  border: none;
  font-weight: bold;
  color: #ffffff;
  cursor: pointer;
  background-color: #8D3DA5 !important;
}
</style>