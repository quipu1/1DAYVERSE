import axios from "axios"
const ACCOUNT_URL = 'http://localhost:8000/od/accounts/'

const userStore = {
  namespaced: true,
  state: {
    username: null,
    teachable: null,
    email: null,
    birth: null,
    phone: null,
    lectures: null,
  },
  getters: {
    getUsername(state) {
      return state.username
    },
  },
  mutations: {
    FETCH_JOB(state, job) {
      state.job = job
    },
    SET_USER(state, username) {
      state.username = username
    },
    RESET_STATE(state) {
      state.username= null
      state.teachable= null
      state.email= null
      state.birth= null
      state.phone= null
      state.lectures= null
    }
  },
  actions: {
    CREATE_USER({ commit }, userinfo) {
      console.log(commit)
      return new Promise((resolve, reject) => {
        const CREATE_USER_URL = ACCOUNT_URL + 'signup/'
        axios.post(CREATE_USER_URL, userinfo)
          .then(() => {
            console.log(commit)
            resolve()
          })
          .catch((err) => { 
            console.log(err)
            reject()
          })
      })
    },
    async AUTH_USER({ commit }, info) {
      const userinfo = info[0]
      const username = info[1]
      return new Promise((resolve, reject) => {
        const AUTH_USER_URL =  ACCOUNT_URL + 'login/'
        axios.post(AUTH_USER_URL, userinfo)
          .then(() => {
            commit('SET_USER', username)
            resolve()
          })
          .catch((err) => {
            console.log(err)
            reject()
          })
      })
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
    DELETE_USER({ commit }, username) {
      const DELETE_USER_URL =  ACCOUNT_URL + `withdraw/${username}` 
        axios.delete(DELETE_USER_URL, username)
          .then((res) => {
            console.log(res)
            commit('RESET_STATE')
          })
          .catch((err) => {
            console.log(err)
          })
    },
  }
}


export default userStore