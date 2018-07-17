import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Login from '@/components/Login'
// @ts-ignore
import Home from '@/components/Home'
// @ts-ignore
import Vault from '@/components/Vault'
// @ts-ignore
import ActiveKeep from '@/components/ActiveKeep'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: '/vault/:id',
      name: 'Vault',
      component: Vault
    },
    {
      path: '/activekeep',
      name: 'ActiveKeep',
      component: ActiveKeep
    }



  ]
})
