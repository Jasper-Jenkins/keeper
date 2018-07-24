<template>
    <!-- <button @click="createVaultKeep(keep)">Add keep</button> -->
  
      
    <div class="row vaultKeeps">
      <div class="col-12">
        <button class="btn btn-success" v-if="!keep.publish && keep.authorId == user.id" @click="publishKeep(keep)">Make Public</button>
         <!-- <button class="btn btn-warning" v-if="keep.publish && keep.authorId == user.id" @click="publishKeep(keep)">Make Private</button> -->
        <button class="btn btn-info" @click="viewKeep(keep)">View</button>
        <button class="btn btn-danger" v-if="keep.authorId == user.id" @click="deleteKeep(keep)">Delete</button>
      </div>
      <div class="col-12">
        <p>Choose a vault</p>
          <form>
            <select v-model="vault" required> 
              <option disabled value=''>Vault</option>
              <option v-for="vault in vaults" :key="vault._id" :value="vault">{{vault.name}}</option>
            </select>
          <button v-if="vault" class="btn btn-primary" @click="createVaultKeep(keep)">To the Vault</button>
        </form>
      </div>
    </div>

</template> 

<script>
export default {
  name: 'VaultKeep',
  props: {
      keep:{
          type:Object,
          required: true
      },
     // vault: ""
  
  },
  data () {
    return {
    
   vault: ""
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
      },
      user(){
        return this.$store.state.user
      },
      activeVault(){
          this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id);
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
 
      // this.$store.dispatch('getKeeps')
      var author = this.$store.state.user.id
      //  keep.AuthorId = author;
      debugger
       keep["vaultId"] = this.vault.id
      this.$store.dispatch('createVaultKeep', keep)
      // this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id);
      },
      publishKeep(keep){
     // debugger
      keep.publish = !keep.publish
      this.$store.dispatch('publishKeep', keep)

      },
      deleteKeep(keep){
        this.$store.dispatch('deleteKeep', keep)
        this.$store.dispatch('getKeeps')
      },
      viewKeep(keep){
        this.$store.dispatch('viewKeep', keep)
      }
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.vaultKeeps {
  border: 1px solid black;

}
</style>
