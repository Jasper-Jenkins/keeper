<template>
  <div id="Compass" class="container-fluid compass">
    <div class="row">
      <div class="col-12 titleFormat">
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
 
.titleFormat{
  background-color:aquamarine;
}
.compass{
  background-color:aquamarine;
  border: 2px solid black;
  height: 17vh;
}

</style>
