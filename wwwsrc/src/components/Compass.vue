<template>
  <div id="Compass" class="row justify-content-center">
      <div class="col-8 compass">
      <h1>Keeper</h1>
      <div>
        <router-link :to="{name: 'Home' }">
          <button class="btn btn-primary">Home</button>
        </router-link>
        <router-link :to="{name: 'Keep' }">
          <button class="btn btn-primary">Keeps</button>
        </router-link>
        <button class="btn" @click="logout">Logout</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Compass',
  data () {
    return {}
  },
  methods: {
      logout(){
        this.$store.dispatch('logout')
      }
    }
}
</script>

<style scoped>
 

.compass{
  background-color:aquamarine; 
  border-radius: 10px;
  /* width: 30vw;
  border: 2px solid black;
  padding: 5px;
  height: auto; */
  text-align:center;
}

</style>
