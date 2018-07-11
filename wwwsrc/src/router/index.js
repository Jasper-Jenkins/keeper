import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Login from '@/components/Login'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Login  ',
      component: Login
    }
  ]
})
