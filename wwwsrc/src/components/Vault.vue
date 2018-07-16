<template>
  <div class="vault">
    {{activeVault.name}}
    {{activeVault.description}}
    <div v-for="keeps in vaultKeepers" v-bind:key="keeps._id">
    {{keeps.id}}
    {{keeps.name}}
    {{keeps.description}}
    {{keeps.share}}
    <button @click="deleteVaultKeep(keeps)">Delete VK</button>
    </div>
  </div>
</template>

<script>
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
    //     debugger
    //    this.$store.dispatch("getVaultKeeps", this.vault.id)
  },
  computed: {
    activeVault() {
      //  debugger
      this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id);
      return this.$store.state.activeVault;
      //   this.$store.dispatch("getVaultKeeps", this.vault.id)
    },
    vaultKeepers() {
      debugger
      var keeps = this.$store.state.keeps;
      var vaultkeeps = this.$store.state.vaultKeeps;
      var returnVK = [];
      if(vaultkeeps.length != 0){
      for(var i in keeps){
        for(var j in vaultkeeps){
          if(keeps[i].id == vaultkeeps[j].keepId){
            returnVK.push(keeps[i])
          }
        }
      }
      return returnVK;
  }else{
    return null;
  }
      
    },
    getVaultKeep() {
      //    debugger
      this.$store.dispatch("getVaultKeeps", this.vault.id);
    }
  },
  methods:{
    deleteVaultKeep(keep){
      debugger
      keep["vaultId"] = this.$store.state.activeVault.id
      this.$store.dispatch('deleteVaultKeep', keep)
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
