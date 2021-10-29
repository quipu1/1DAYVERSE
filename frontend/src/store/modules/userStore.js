import axios from "axios"
const ACCOUNT_URL = 'http://localhost:8000/od/accounts/'

const userStore = {
  namespaced: true,
  state: {
    userid: null,
    username: null,
    teachable: null,
    email: null,
    birth: null,
    phone: null,
    lectures: null,
    character: null,
    profile_img: null,
  },
  getters: {
    getUsername(state) {
      return state.username
    },
    getUserTeachable(state) {
      return state.teachable
    },
    getUserBirth(state) {
      return state.birth
    },
    getUserPhone(state) {
      return state.phone
    },
    getUserLectures(state) {
      return state.lectures
    },
    getUserId(state) {
      return state.userid
    },
  },
  mutations: {
    SET_USER(state, usersetting) {
      state.username = usersetting[0]
      state.teachable = usersetting[1]
    },
    RESET_STATE(state) {
      state.userid = null
      state.username = null
      state.email = null
      state.birth = null
      state.phone = null
      state.teachable = null
      state.lectures = null
      state.character = null
      state.profile_img = null
    },
    FETCH_PROFILE(state, userinfo) {
      state.userid = userinfo.id
      state.username = userinfo.username
      state.email = userinfo.email
      state.birth = userinfo.birth_day
      state.phone = userinfo.phone_number
      state.teachable = userinfo.teachable
      state.character = userinfo.character
      state.profile_img = userinfo.profile_image
    },
    FETCH_LECTURES(state, lectures) {
      state.lectures = lectures
    }
  },
  actions: {
    CREATE_USER({ commit }, userinfo) {
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
    async AUTH_USER({ commit }, userinfo) {
      return new Promise((resolve, reject) => {
        const AUTH_USER_URL =  ACCOUNT_URL + 'login/'
        axios.post(AUTH_USER_URL, userinfo)
          .then((res) => {
            commit('FETCH_PROFILE', res.data.user)
            resolve()
          })
          .catch((err) => {
            console.log(err)
            reject()
          })
      })
    },
    LOGOUT({ commit }) {
      // const LOGOUT_URL = ACCOUNT_URL + 'logout/'
      // axios.post(LOGOUT_URL)
      //   .then((res) => {
      //     console.log(res)
        commit('RESET_STATE')
        // })
        // .catch((err) => {
        //   console.log(err)
        // })
    },
    FETCH_PROFILE({ commit }, username) {
      const FETCH_PROFILE_URL = ACCOUNT_URL + `profile/${username}/`
      axios.get(FETCH_PROFILE_URL)
        .then((res) => {
          commit('FETCH_PROFILE', res.data.profile)
          commit('FETCH_LECTURES', res.data.lectures)
        })
        .catch((err) => {
          console.log(err)
        })
    },
    async UPDATE_PROFILE({ commit }, info) {
      return new Promise((resolve, reject) => {
        const userinfo = info[0]
        const username = info[1]
        const UPDATE_USER_URL = ACCOUNT_URL + `profile/${username}/`
        axios.put(UPDATE_USER_URL, userinfo)
          .then((res) => {
            commit('FETCH_PROFILE', res.data)
            resolve()
          })
          .catch((err) => {
            console.log(err)
            reject()
          })
      })
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