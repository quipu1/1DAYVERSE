<template>
  <div>
    <div class="id-card">
      <div class="job">
        <h3 v-if="userjob === 'student'" class="job-text">STUDENT ID</h3>
        <h3 v-else class="job-text">PROFESSOR ID</h3>
      </div>
      <div class="container">
        <div class="profile">
          <img src="http://veloxsites.com/images/team/danielle.jpg" alt="Danielle Bastien"/>
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
        <div class="class-info">
          <h2 v-if="userjob === 'student'">수강내역</h2>
          <h2 v-else>강의정보</h2>
          <div v-for="lecture, idx in lectures" :key="idx" class="lecture">
            {{ lecture }}
          </div>
        </div>
      </div>
    </div>
    <UpdateProfile
      v-if="modal"
    />
  </div>
</template>

<script>
import UpdateProfile from '@/components/UpdateProfile'

export default {
  data() {
    return {
      userjob: 'stud',
      username: 'amy',
      birth: '1990.01.01',
      phone: '1234567890',
      lectures: [
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas sequi corporis fugit nesciunt nobis quam quidem animi molestias vero ad doloribus aperiam expedita alias recusandae, non impedit, odio cum provident.',
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas sequi corporis fugit nesciunt nobis quam quidem animi molestias vero ad doloribus aperiam expedita alias recusandae, non impedit, odio cum provident.',
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas sequi corporis fugit nesciunt nobis quam quidem animi molestias vero ad doloribus aperiam expedita alias recusandae, non impedit, odio cum provident.',
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas sequi corporis fugit nesciunt nobis quam quidem animi molestias vero ad doloribus aperiam expedita alias recusandae, non impedit, odio cum provident.',
        'Developer',
        'Developer',
        'Developer',
      ],
      modal: false,
    }
  },
  components: {
    UpdateProfile
  },
  methods: {
    changemodal() {
      this.modal = !this.modal
      console.log(this.modal)
    }
  }
}
</script>

<style scoped>
img {
  width: 200px; 
  box-shadow: 1px 3px 10px 3px rgba(158, 158, 158, 0.3);
  margin: 1rem;
  border-radius: 100%;
}
.id-card {
  height: 70vh;
  position: relative;
  background-color: white;
  width: 70%;
  max-width: 1500px;
  margin: 20px auto;
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
  background-color: rgba(153, 97, 160, 0.9);
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
}
.class-info {
  margin: 5vh 3rem 0 0;
  width: 100%;
  background-color: bisque;
  height: 53vh;
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

</style>