<template>
  <div class="home container-fluid">

      <compass></compass>
    <div class="row justify-content-center">
      <div class="col-12">
        <p>Welcome to the home page {{user.username}}</p>
      </div>
      <form class="col-4-lg col-4-md col-8-sm cVForm" v-on:submit.prevent="addVault">
        <div class="form-group">
          <input class="input form-control" type="text" name="name" placeholder="Vault-Name" id="vaultName" v-model="vault.Name">
        </div>
        <div class="form-group">
          <input class="input form-control" type="text" name="description" placeholder="Description" id="vaultDescription" v-model="vault.Description">
        </div>
        <button class="btn btn-primary" type="submit">Add New Vault</button>
      </form>
       
    </div>

    <div class="row justify-content-center vButtonsContainer">
      <div class="col-12">
        <p>Choose a vault you would like to look inside of.</p>
      </div>
      <div class="col-4 vButtons" v-for="vault in vaults" v-bind:key="vault._id">
      <!-- <a @click="showKeeps(vault)"> 
        <router-link @click.native="setActiveVault(vault)" :to="{name: 'Vault', params: {id: vault._id}}" :key="vault._id">
          {{vault.description}}
        </router-link>
      </a> -->
 
      <button class="btn btn-primary" @click="setActiveVault(vault)">{{vault.name}}</button>
      </div>
    </div>
  <vault></vault>
  <!-- Button trigger modal -->
<!-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
  Launch demo modal
</button> -->

<!-- Modal -->
<!-- <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalCenterTitle">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div> -->

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
    if(!this.user.id)
    {
        router.push({name: "Login"})
    }else{
     this.$store.dispatch("getUserVaults")
     this.$store.dispatch('getKeeps')
     }
    // debugger
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
  background-color:rgb(19,148,73);
  text-align:center;
}
.cVForm{
  background-color:cadetblue;
  border-radius:10px;
  margin:10px;
  padding:10px;
}
.vButtonsContainer{
  border: 5px solid black;
}
p {
  /* text-align: center; */
}
.vButtons{
  border: 5px solid black;
}
</style>
