<template>
    <!-- <button @click="createVaultKeep(keep)">Add keep</button> -->
<div class="vaultKeeps">  
   <select v-model="vault"> 
       <option disabled value=''>Add Keep to vault: </option>
       <option v-for="vault in vaults" :key="vault._id" :value="vault">{{vault.name}}</option>
     </select>
     <button @click="createVaultKeep(keep)">Add to vault: </button>
  </div>
</template>

<script>
export default {
  name: 'VaultKeep',
  props: {
      keep:{
          type:Object,
          required: true
      }
  
  },
  data () {
    return {
    
    vault:{}
    }
  },
  mounted() {
   //   this.$store.dispatch('getKeeps')
  },
  computed:{
    //   keeps(){
    //     // debugger     
    //    return this.$store.state.keeps
    //   },
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
      createVaultKeep(keep){
       //   debugger
          var author = this.$store.state.user.id
        //  keep.AuthorId = author;
          keep.vaultId = this.vault.id
          this.$store.dispatch("createVaultKeep", keep)
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
