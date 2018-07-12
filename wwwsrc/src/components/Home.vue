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
     <a @click="showKeeps(vault)"> 
     {{vault.description}}
     </a>
   </div>
  
  

  </div>
</template>

<script>
import router from "../router"
export default {
  name: 'Home',
  data () {
    return {
    //   msg: 'Welcome to Your Vue.js App'
     user: {},
     
     vault:{
          Name: '',
          Description: '',
      }, 
    }
  },
  mounted() {
  

    this.user = this.$store.state.user;
   
    if(!this.$store.state.user.id)
    {
        router.push({name: "Login"})
    }
    this.$store.dispatch("getUserVaults")


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
