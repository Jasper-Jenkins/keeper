<template>
  <div id="app" >
    <!-- <div class="row"> -->
      <!-- <div class="col-12 titleFormat"> -->
       
         <!-- <div>
    <router-link :to="{name: 'Home' }">
          <button class="btn btn-primary">Home</button>
    </router-link>
    <router-link :to="{name: 'Keep' }">
          <button class="btn btn-primary">Keeps</button>
    <button class="btn" @click="logout">Logout</button>
    
    </router-link>
    </div> -->
      <!-- </div> -->
    <!-- </div> -->
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App',
  
  mounted(){
    this.$store.dispatch("authenticate")
  },
  // computed:{
  //     logout(){
  //       this.$store.dispatch('logout')
  //     }
  //   }
}
</script>

<style>

.titleFormat{
  background-color:aquamarine;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 0px;
}
</style>
