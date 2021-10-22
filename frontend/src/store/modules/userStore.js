// import axios from "axios"

const userStore = {
  namespaced: true,
  state: {},
  getters: {},
  mutations: {},
  actions: {
    CREATE_TUTEE({ commit }, userinfo) {
      console.log(userinfo)
      console.log(commit)
      // return new Promise((resolve, reject) => {
      //   const USER_CREATE_URL = '/user/signup'
      //   axios.post(USER_CREATE_URL, userinfo)
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
      //   const USER_CREATE_URL = '/user/signup'
      //   axios.post(USER_CREATE_URL, userinfo)
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
  }
}

export default userStore