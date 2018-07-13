<template>
  <div class="vault">
   {{vault.name}}
   {{vault.description}}
    <!-- <div v-for="keeps in vault" v-bind:key="keeps._id">
    {{keeps.name}}
    </div> -->
  </div>
</template>

<script>
export default {
  name: 'Vault',
  data () {
    return {
    
   // vault:{}
    }
  },
  mounted() {
    //  this.vault = this.$store.state.activeVault
   
  },
  computed:{
      vault(){
        return this.$store.state.activeVault
      },
      vaultkeeps(){
        return this.$store.state
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
