import { createRouter, createWebHistory } from 'vue-router'
import Main from '../views/Main.vue'

import Login from '../views/Login.vue'
import Singup from '../views/Singup.vue'
import Profile from '../views/Profile.vue'
import Category from '../views/Category.vue'
import ClassDetail from '../views/ClassDetail.vue'

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
  {
    path : '/classdetail',
    name : 'ClassDetail',
    component : ClassDetail,
    
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
