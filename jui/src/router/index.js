import Vue from 'vue'
import Router from 'vue-router'
import ProductsList from '@/components/ProductsList'
import EditProduct from '@/components/EditProduct'
import Login from '@/components/Login'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/ProductsList',
      name: 'ProductsList',
      component: ProductsList
    },
    {
      path: '/EditProduct',
      name: 'EditProduct',
      component: EditProduct
    },
    {
      path: '/',
      name: 'Login',
      component: Login
    }
  ]
})
