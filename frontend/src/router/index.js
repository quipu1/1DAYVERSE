import { createRouter, createWebHistory } from 'vue-router'
import Main from '../views/Main.vue'

import Login from '../views/Login.vue'
import Signup from '../views/Signup.vue'
import Profile from '../views/Profile.vue'
import Category from '../views/Category.vue'
import LectureDetail from '../views/LectureDetail.vue'
import LectureCreate from '../views/LectureCreate.vue'
import BuyDone from '../views/BuyDone.vue'
import BuyCancel from '../views/BuyCancel.vue'
import BuyFail from '../views/BuyFail.vue'
import Unity from '../views/Unity.vue'
import Live from '../views/LiveLecture.vue'
import Search from '../views/Search.vue'


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
    path: '/signup',
    name: 'Signup',
    component: Signup
  },
  {
    path: '/:username',
    name: 'Profile',
    component: Profile,
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
    path : '/buy/done/:lecture_id',
    name : 'BuyDone',
    component : BuyDone,
    props: true,
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
  {
    path: '/unity',
    name: 'Unity',
    component: Unity
  },
  {
    path: '/live',
    name: 'Live',
    component: Live
  },
  {
    path: '/search/:keyword',
    name: 'Search',
    component: Search,
    props : true,
  },
]


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
