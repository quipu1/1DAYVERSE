// import axios from "axios"

const userStore = {
  namespaced: true,
  state: {
    job: null,
    email: null,
    username: null,
    birth: null,
    phone: null,
    lectures: null,
  },
  getters: {
    // job 정보 가져오기
    getUserJob(state) {
      return state.job
    }
  },
  mutations: {
    FETCH_JOB(state, job) {
      state.job = job
    },
  },
  actions: {
    CREATE_TUTEE({ commit }, userinfo) {
      console.log(userinfo)
      console.log(commit)
      // return new Promise((resolve, reject) => {
      //   const CREATE_TUTEE_URL = '/user/signup'
      //   axios.post(CREATE_TUTEE_URL, userinfo)
      //     .then(() => {
      //       commit('SIGNUP_EMAIL', userinfo.email)
      //       resolve()
      //     })
      //     .catch((err) => {
      //       const signupError = err.response.data.data
      //       commit('SIGNUP_ERROR', signupError)
      //       reject()
      //     })
      // })
    },
    CREATE_TUTOR({ commit }, userinfo) {
      console.log(userinfo)
      console.log(commit)
      // return new Promise((resolve, reject) => {
      //   const CREATE_TUTOR_URL = '/user/signup'
      //   axios.post(CREATE_TUTOR_URL, userinfo)
      //     .then(() => {
      //       commit('SIGNUP_EMAIL', userinfo.email)
      //       resolve()
      //     })
      //     .catch((err) => {
      //       const signupError = err.response.data.data
      //       commit('SIGNUP_ERROR', signupError)
      //       reject()
      //     })
      // })
    },
    AUTH_TUTEE({ commit }, userinfo) {
      console.log(userinfo)
      console.log(userinfo)
      console.log(commit)
      // 로그인시 job 정보 저장
      commit('FETCH_JOB', 'Tutee')
    },
    AUTH_TUTOR({ commit }, userinfo) {
      console.log(userinfo)
      console.log(commit)
      // 로그인시 job 정보 저장
      commit('FETCH_JOB', 'Tutor')
    },
    FETCH_TUTEE({ commit }, username) {
      console.log(username)
      console.log('튜티')
      console.log(commit)
    },
    FETCH_TUTOR({ commit }, username) {
      console.log(username)
      console.log('튜터')
      console.log(commit)
    },
    UPDATE_PROFILE({ commit }, userinfo) {
      console.log(userinfo)
      console.log('update 프로필')
      console.log(commit)
    },
    DELETE_USER({ commit }) {
      console.log(commit)
    }
  }
}

export default userStore