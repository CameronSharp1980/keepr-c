import Vue from 'vue'
import Router from 'vue-router'
import Keepr from '@/components/keepr'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Keepr',
      component: Keepr
    }
  ]
})
