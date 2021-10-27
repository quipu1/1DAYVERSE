import { createStore } from 'vuex'
import userStore from '././modules/userStore'
import classStore from '././modules/classStore'

import createPersistedState from "vuex-persistedstate";

export default createStore({
  plugins: [createPersistedState({
      paths: ['userStore', "classStore"],
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
