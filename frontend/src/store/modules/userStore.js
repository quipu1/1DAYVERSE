import axios from "axios"

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
    CREATE_USER({ commit }, userinfo) {
      console.log(userinfo)
      console.log(commit)
      return new Promise((resolve, reject) => {
        const CREATE_USER_URL = 'http://localhost:8000/od/accounts/signup/'
        axios.post(CREATE_USER_URL, userinfo)
          .then(() => {
            // commit('SIGNUP_EMAIL', userinfo.email)
            console.log('회원가입 완료')
            resolve()
          })
          .catch((err) => { 
            console.log(err)
            reject()
          })
      })
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