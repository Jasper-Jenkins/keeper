<template>
  <div class="vault">
   {{activeVault.name}}
   {{activeVault.description}}
    <div v-for="keeps in vaultKeepers" v-if="keeps.vaultId == activeVault.id" v-bind:key="keeps._id">
    {{keeps.id}}
    </div>
  </div>
</template>

<script>
export default {
  name: 'Vault',
  data () {
    return {
    
   vault:{
       id: this.$store.state.activeVault.id
   }
    }
  },
  mounted() {
//     debugger
//    this.$store.dispatch("getVaultKeeps", this.vault.id)
   
  },
  computed:{
      activeVault(){
         debugger
        this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id)
        return this.$store.state.activeVault
     //   this.$store.dispatch("getVaultKeeps", this.vault.id)
      },
      vaultKeepers(){
        debugger
        return this.$store.state.vaultKeeps
      },
      getVaultKeep(){
      //    debugger
         this.$store.dispatch("getVaultKeeps", this.vault.id)
   
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
