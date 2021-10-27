import { createRouter, createWebHistory } from 'vue-router'
import Main from '../views/Main.vue'

import Login from '../views/Login.vue'
import Singup from '../views/Singup.vue'
import Profile from '../views/Profile.vue'
import Category from '../views/Category.vue'
import LectureDetail from '../views/LectureDetail.vue'
import LectureCreate from '../views/LectureCreate.vue'
import BuyDone from '../views/BuyDone.vue'
import BuyCancel from '../views/BuyCancel.vue'
import BuyFail from '../views/BuyFail.vue'

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
    path: '/category/:group',
    name: 'Category',
    component: Category,
    props : true,
    // params : {category : ""},
  },
  {
    path : '/lecture/detail/:lecture_id',
    name : 'LectureDetail',
    component : LectureDetail,
    props : true,
    
  },
  {
    path : '/lecture/create',
    name : 'LectureCreate',
    component : LectureCreate,
  },
  {
    path : '/buy/done',
    name : 'BuyDone',
    component : BuyDone,
  },
  {
    path : '/buy/cancel',
    name : 'BuyCancel',
    component : BuyCancel,
  },  
  {
    path : '/buy/fail',
    name : 'BuyFail',
    component : BuyFail,
  },
]


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
