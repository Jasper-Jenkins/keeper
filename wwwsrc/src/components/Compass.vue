<template>
  <div id="Compass" class="row compass">
    <div class="col-12 compassFormat">
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
 
.compassFormat{
  background-color:aquamarine;
  border: 10px solid burlywood;
  border-radius: 15%;
}
.compass{
  width: 30vw;
  /* background-color:aquamarine; */
  border: 2px solid black;
  padding: 5px;
  border-radius: 15%;
  height: auto;
}

</style>
