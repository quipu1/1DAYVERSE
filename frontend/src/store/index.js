import { createStore } from 'vuex'
import userStore from '././modules/userStore'
import createPersistedState from "vuex-persistedstate";


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
