import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './index.css'
import Notifications from 'notiwind'

createApp(App).use(store).use(store).use(router).use(Notifications).mount('#app')