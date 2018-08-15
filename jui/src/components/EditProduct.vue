<template>
<div>
    <h1>Edit Product</h1>
    <b-container fluid>
        <b-form @submit.prevent="onSubmit">
            <b-container fluid>
                <b-row>
                    <b-col>
                        <label for="txtDescription">Description</label>
                    </b-col>
                    <b-col>
                        <b-input id="txtDescription" placeholder="Product description" v-model="product.description"/>
                    </b-col>
                </b-row>
                <b-row>
                    <b-col>
                        <label for="txtBrand">Brand</label>
                    </b-col>
                    <b-col>
                        <b-input id="txtBrand" placeholder="Product Brand" v-model="product.brand"/>
                    </b-col>
                </b-row>
                <b-row>
                    <b-col>
                        <label for="txtModel">Model</label>
                    </b-col>
                    <b-col>
                        <b-input id="txtModel" placeholder="Product Model" v-model="product.model"/>
                    </b-col>
                </b-row>
            </b-container>

            <div style="padding-top: 15px">
                <b-button type="submit" variant="primary">Save</b-button>
                <b-button type="reset" variant="danger" @click="onReset">Cancel</b-button>
            </div>
        </b-form>
    </b-container>
</div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'EditProduct',
    data () {
        return {
            product: {
                id: '',
                description: '',
                brand: '',
                model: ''
            }
        }
    },
    methods: {
        onSubmit () {
            axios({
                method: 'post',
                url: 'http://localhost:5000/api/products',
                auth: {
                    username: 'test',
                    password: 'test'
                },
                data: this.product 
            })
            .then(function(response) {
                console.log(response.data);
                console.log(response.headers['Authorization']);
            }).catch(err => console.log(err));

            this.$router.push({ path: '/'});
        },
        onReset () {
            this.$router.push({ path: '/'});
        },
    }
}
</script>

<style scoped>

</style>
