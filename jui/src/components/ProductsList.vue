<template>
  <div>
    <h1>Products</h1>
    <b-button-toolbar aria-label="Button Toolbar">
      <b-button-group class="mx-3" style=" padding-bottom: 10px">
        <b-btn @click="CreateNewProduct">New</b-btn>
      </b-button-group>
    </b-button-toolbar>
    <b-table striped hover :items="products" :fields="fields"></b-table>
  </div>  
</template>

<script>
import axios from 'axios';

export default {
  name: 'ProductsList',
  created ()
  {
    axios({
      method: 'get',
      url: 'http://localhost:5000/api/products',
      auth: {
        username: 'test',
        password: 'test'
      }    
    })
    .then(response => {
        console.log(response.data);
        console.log(response.headers['Authorization']);
        this.products = response.data;
    }).catch(err => console.log(err));
  },
  data () {
    return {
      fields: ['description','model','brand'],
      products: [
        { id: 1, description: "Product 1", model: "Model 1", brand: 'Brand 1' },
        { id: 2, description: "Product 2", model: "Model 2", brand: 'Brand 2' },
        { id: 3, description: "Product 3", model: "Model 3", brand: 'Brand 3' },
        { id: 4, description: "Product 4", model: "Model 4", brand: 'Brand 4' }
      ]
    }
  },
  methods: {
    CreateNewProduct : function (){
      this.$router.push({ path: '/EditProduct'});
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
