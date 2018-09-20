<template>
  <div>
    <h1>Products</h1>
    <b-container fluid>
      <!-- User Interface controls -->
      <b-row>
        <b-col md="6" class="my-1">
          <b-form-group horizontal label="Filter" class="mb-0">
            <b-input-group>
              <b-form-input v-model="filter" placeholder="Type to Search" />
              <b-input-group-append>
                <div style="padding-left: 10px;">
                  <b-btn :disabled="!filter" @click="filter = ''">Clear</b-btn>
                </div>
                <div style="padding-left: 10px;">
                  <b-btn @click="createNewProduct">New</b-btn>
                </div>
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>
      </b-row>
    </b-container>
    <b-table striped hover :items="products" :fields="fields" :filter="filter">
      <template slot="actions" slot-scope="row">
        <b-button size="sm" @click.stop="editProduct(row.item, row.index, $event.target)" class="mr-1">
          Edit
        </b-button>
        <b-button size="sm" @click.stop="deleteProduct(row.item, row.index, $event.target)" class="mr-1">
          Delete
        </b-button>
      </template>
    </b-table>
  </div>  
</template>

<script>
import axios from 'axios';

export default {
  name: 'ProductsList',
  beforeCreate()
  {
    console.log("Before create.");
  },
  created ()
  {
    axios({
      method: 'get',
      headers: { 'Authorization': this.$cookie.get('token') },
      url: 'http://localhost:5000/api/products', 
    })
    .then(response => {
        console.log(response.data);
        console.log(response.headers['Authorization']);
        this.products = response.data;
    }).catch(err => console.log(err));
  },
  beforeMount()
  {
    console.log("Before Mount.");
  },
  mounted()
  {
    console.log("mounted.");
  },
  beforeUpdate()
  {
    console.log("Before Update.");
  },
  updated()
  {
    console.log("updated.");
  },
  beforeDestroy()
  {
    console.log("Before Destroy.");
  },
  destroyed()
  {
    console.log("destroyed.");
  },
  data () {
    return {
      fields: ['description','model','brand','actions'],
      products: [],
      filter: null
    }
  },
  methods: {
    editProduct (item, index, button) {
      console.log("Edit Product");
      console.log(item);
      // this.modalInfo.title = `Row index: ${index}`
      // this.modalInfo.content = JSON.stringify(item, null, 2)
      // this.$root.$emit('bv::show::modal', 'modalInfo', button)
    },
    deleteProduct (item, index, button) {
      console.log("Delete Product");
      // this.modalInfo.title = `Row index: ${index}`
      // this.modalInfo.content = JSON.stringify(item, null, 2)
      // this.$root.$emit('bv::show::modal', 'modalInfo', button)
    },
    createNewProduct (){
      this.$router.push({ path: '/EditProduct'});
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
