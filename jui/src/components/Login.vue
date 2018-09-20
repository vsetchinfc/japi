<template>
  <div>
    <h1>Login</h1>
    <form v-on:submit.prevent="onSubmit">
      <input type="username" name="username" v-model="username">
      <input type="password" name="password" v-model="password">
      <input type="submit" name="submit" value="Login">
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Login',
    data() {
        return {
            username: '',
            password: ''
        }
    },
    methods: {
        onSubmit(){
            axios.post('http://localhost:5000/api/auth/login', {
                username: this.username,
                password: this.password
            })
            .then(res=>{
                this.$cookie.set('token',res.data.token);
                this.$router.push({ path: '/ProductsList'});
            })
            .catch(err=>{
                console.log(err);
            });
        }
    }
}
</script>