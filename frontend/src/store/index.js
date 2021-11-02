import { createStore } from 'vuex'
import userStore from '././modules/userStore'
import classStore from './modules/lectureStore'

import createPersistedState from "vuex-persistedstate";

export default createStore({
  plugins: [createPersistedState({
      paths: ['userStore', "lectureStore"],
    })
  ],
  state: {
  },
  mutations: {
  },
  actions: {
    
  },
  modules: {
    userStore,
    classStore
  }
})
