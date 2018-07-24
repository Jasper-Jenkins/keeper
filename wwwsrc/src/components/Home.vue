<template>
  <div class="home container-fluid">

      <compass></compass>
    <div class="row">
      <div class="col-12">
      <p>Welcome to the home page {{user.username}}</p>
 
      
      
      <!-- <button @click="logout">Logout</button>
      <router-link :to="{name: 'Keep' }">
          <button class="btn btn-primary">Keeps</button>
      </router-link> -->
        <form v-on:submit.prevent="addVault">
            <input class="input" type="text" name="name" placeholder="Vault-Name" id="vaultName" v-model="vault.Name">
            <input class="input" type="text" name="description" placeholder="Description" id="vaultDescription" v-model="vault.Description">
            <button class="btn btn-primary btn-danger" type="submit">Add new Vault</button>
        </form>
      </div>
    </div>
    <div class="row d-flex justify-content-center">
      <div class="col-12">
        <h5>Choose a vault you would like to look inside of.</h5>
      </div>
      <div class="col-2" v-for="vault in vaults" v-bind:key="vault._id">
      <!-- <a @click="showKeeps(vault)"> 
        <router-link @click.native="setActiveVault(vault)" :to="{name: 'Vault', params: {id: vault._id}}" :key="vault._id">
          {{vault.description}}
        </router-link>
      </a> -->
    
      <button class="btn btn-primary" @click="setActiveVault(vault)">{{vault.name}}</button>
      </div>
    </div>
  <vault></vault>
  <!-- <keep></keep> -->

  </div>
</template>

<script>
import router from "../router"
import vault from "./Vault"
import compass from "./Compass"
// import keep from "./Keep"
export default {
  name: 'Home',
  data () {
    return {
    //   msg: 'Welcome to Your Vue.js App'
     user: {},
     
     vault:{
        //  type:Object,
          Name: '',
          Description: '',
      },
  //    activeKeep: this.$store.state.activeVault 
    }
  },
  components:{
    vault,
    compass
  //  keep
  },
  mounted() {
  

    this.user = this.$store.state.user;
   
    if(!this.$store.state.user.id)
    {
        router.push({name: "Login"})
    }
   // debugger
    this.$store.dispatch("getUserVaults")
    this.$store.dispatch('getKeeps')
    // this.$store.dispatch('getVaultKeeps')
  }, 
  computed: {
    vaults(){
      return this.$store.state.userVaults
    }

  },
  methods: {

    addVault(){
      this.$store.dispatch('createUserVault', this.vault)
    },
    setActiveVault(vault){
    //  debugger
      this.$store.dispatch('setActiveVault', vault)

    },
    showKeeps(vault){
      this.$store.dispatch('getVaultKeeps')

    },
   
    logout(){
      this.$store.dispatch('logout')
    }
  } 
 

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home {
  background-color:aquamarine;
}

</style>
