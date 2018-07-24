<template>
    
    <div class="vault row">
      <div class="col-12">
      <button v-if="activeVault.id" class="btn btn-danger" @click="deleteVault(activeVault)">Delete Vault</button>
      <p>{{activeVault.name}}</p>
      <p>{{activeVault.description}}</p>
    </div>
        
        
        <div class="vaultKeepFormat col-4" v-for="keeps in vaultKeepers" v-bind:key="keeps._id">
        <img class="img-fluid" :src="keeps.imageUrl" alt="Fun fun">

        <p>{{keeps.name}}</p> 
        <p>{{keeps.description}}</p>
        <p>Shares: {{keeps.share}}</p>
        <p>Views: {{keeps.view}}</p>
        <button @click="deleteVaultKeep(keeps)">Delete VK</button>
        </div>
    </div>
  
</template>

<script>
// import 
export default {
  name: "Vault",
  data() {
    return {
      vault: {
        id: this.$store.state.activeVault.id
      }
    };
  },
  mounted() {
  },
  computed: {
    // deleteVault(vault){
    //   this.$store.dispatch('deleteVault', vault)
    // },
    activeVault() {
      this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id);
      return this.$store.state.activeVault;
    },
    vaultKeepers() {
      var keeps = []; 
      var vaultkeeps = this.$store.state.vaultKeeps;
      return vaultkeeps;
      // var returnVK = [];
  //     if(vaultkeeps.length != 0){
  //     keeps = this.$store.state.keeps;  
  //     for(var i in keeps){
  //       for(var j in vaultkeeps){
  //         if(keeps[i].id == vaultkeeps[j].keepId){
  //           returnVK.push(keeps[i])
  //         }
  //       }
  //     }
  //     return returnVK;

  // }else{
  //   return null;
  // }
     //activeVault();
    // },
    // getVaultKeep() {
      
     // debugger
      //this.$store.dispatch("getVaultKeeps", this.vault.id);
    },
    
  getKeeps(){
     this.$store.dispatch('getKeeps')
  }
  },
  methods:{
    deleteVaultKeep(keep){
     // debugger
      keep["vaultId"] = this.$store.state.activeVault.id
      this.$store.dispatch('deleteVaultKeep', keep)
     
    }, 
    deleteVault(vault){
      this.$store.dispatch('deleteVault',vault)
      
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.vaultKeepFormat{
  background-color: rgb(100, 170, 120);
  border-radius: 10%;
  border: 1px black solid;
  width: 80%;
  margin: 0 auto; 
}
h1,
h2 {
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
