import Vue from 'vue'
import Router from 'vue-router'
import Keepr from '@/components/keepr'
import Dashboard from '@/components/dashboard'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Keepr',
      component: Keepr
    }, {
      path: '/dashboard',
      name: 'Dashboard',
      component: Dashboard
    }
  ]
})
