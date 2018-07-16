<template>
  <div class="keep">
    <form v-on:submit.prevent="createKeep(keep)">
    <input class="input" type="text" name="keepname" placeholder="Name" id="name" v-model="keep.Name">
    <input class="input" type="text" name="keepdescription" placeholder="Decscription" id="description" v-model="keep.Description">
    <button class="btn btn-primary btn-danger" type="submit">Create Keep</button>
  </form>



  <div v-for="keep in keeps" v-bind:key="keep._id">
    {{keep.name}}
    <!-- <button @click="createVaultKeep(keep)">Add keep</button> -->
 <!-- <select v-model="vault"> 
       <option disabled value=''>Add Keep to vault: </option>
       <option v-for="vault in vaults" :key="vault._id" :value="trip">{{vault.name}}</option>
     </select>
     <button @click="createVaultKeep(keep)">Add to vault: </button> -->


     <vaultkeep :keep="keep"></vaultkeep> 
    </div>
  </div>
</template>

<script>
import vaultkeep from './VaultKeep'
export default {
  name: 'Keep',
  data () {
    return {
    keep:{
        Name: "",
        Description: "",

    },
    vault:{}
    }
  },
  components:{
      vaultkeep
  },
  mounted() {
      this.$store.dispatch('getKeeps')
  },
  computed:{
      keeps(){
      //  debugger     
       return this.$store.state.keeps
      },
      vaults(){
        return this.$store.state.userVaults
      }
    //   getKeeps(){
    //       this.$store.dispatch('getKeeps')
    //   }
    //   vaultkeeps(){
    //     return this.$store.state
    //   }
       
  },
  methods: {
      createKeep(keep){
        //  debugger
          var author = this.$store.state.user.id
          keep.AuthorId = author;
          this.$store.dispatch("createKeep", keep)
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
