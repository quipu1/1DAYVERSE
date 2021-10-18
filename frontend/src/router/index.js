import { createRouter, createWebHistory } from 'vue-router'
import Main from '../views/Main.vue'

import Login from '../views/Login.vue'
import Singup from '../views/Singup.vue'
import Profile from '../views/Profile.vue'
import Category from '../views/Category.vue'


const routes = [
  {
    path: '/',
    name : "Main",
    component : Main,

  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/singup',
    name: 'Singup',
    component: Singup
  },
  {
    path: '/profile',
    name: 'Profile',
    component: Profile
  },  
  {
    path: '/category',
    name: 'Category',
    component: Category,
    props : {category : ""},
    // params : {category : ""},
  },

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
