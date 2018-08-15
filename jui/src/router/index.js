import Vue from 'vue'
import Router from 'vue-router'
import ProductsList from '@/components/ProductsList'
import EditProduct from '@/components/EditProduct'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'ProductsList',
      component: ProductsList
    },
    {
      path: '/EditProduct',
      name: 'EditProduct',
      component: EditProduct
    }
  ]
})
