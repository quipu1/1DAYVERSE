import { createStore } from 'vuex'
import userStore from '././modules/userStore'
import createPersistedState from "vuex-persistedstate";
import axios from 'axios'

axios.defaults.baseURL = 'http://127:0.0.1:8000/'

export default createStore({
  plugins: [createPersistedState({
      paths: ['userStore'],
    })
  ],
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    userStore
  }
})
