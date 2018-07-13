<template>
  <div class="home">
   <p>Welcome to the home page {{user.username}}</p>
  <div>
   <form v-on:submit.prevent="addVault">
        <input class="input" type="text" name="name" placeholder="Vault-Name" id="vaultName" v-model="vault.Name">
        <input class="input" type="text" name="description" placeholder="Description" id="vaultDescription" v-model="vault.Description">
        <button class="btn btn-primary btn-danger" type="submit">Add new Vault</button>
    </form>
  </div>




   <div v-for="vault in vaults" v-bind:key="vault._id">
     <!-- <a @click="showKeeps(vault)"> 
       
      <router-link @click.native="setActiveVault(vault)" :to="{name: 'Vault', params: {id: vault._id}}" :key="vault._id">
        {{vault.description}}
      </router-link>
     </a> -->
   
     <button @click="setActiveVault(vault)">{{vault.description}}</button>
   </div>
  <vault></vault>
  <keep></keep>

  </div>
</template>

<script>
import router from "../router"
import vault from "./Vault"
import keep from "./Keep"
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
    }
  },
  components:{
    vault,
    keep
  },
  mounted() {
  

    this.user = this.$store.state.user;
   
    if(!this.$store.state.user.id)
    {
        router.push({name: "Login"})
    }
   // debugger
    this.$store.dispatch("getUserVaults")
   // this.$store.dispatch('getKeeps')

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
      this.$store.dispatch('setActiveVault', vault)
    },
    showKeeps(vault){
      this.$store.dispatch("getVaultKeeps")

    }
  } 
 

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
