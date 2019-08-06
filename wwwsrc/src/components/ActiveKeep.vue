<template>
  <div class="row activeKeep bgFormat">
    <div class="col-12">
      <compass></compass>
    </div>
    <div class="col-12">
      <img :src="keep.imageUrl" alt="Fun fun">
      <p>{{keep.name}}</p> 
      <p>{{keep.description}}</p>
      <p>Shares: {{keep.share}}</p>
      <p>Views: {{keep.view}}</p>
    </div>
    <div class="col-12 vaultKeeps">
      <button class="btn btn-success" v-if="!keep.publish && keep.authorId == user.id" @click="publishKeep(keep)">Make Public</button>
      <!-- <button class="btn btn-warning" v-if="keep.publish && keep.authorId == user.id" @click="publishKeep(keep)">Make Private</button> -->
      <!-- <button class="btn btn-info" @click="viewKeep(keep)">View</button> -->
      <button class="btn btn-danger" v-if="keep.authorId == user.id" @click="deleteKeep(keep)">Delete</button>
    </div>
    <div class="col-12">
      <p>Choose a vault</p>
      <form>
      <select v-model="vault" required> 
        <!-- <option disabled value=''>Add Keep to vault: </option> -->
        <option v-for="vault in vaults" :key="vault._id" :value="vault">{{vault.name}}</option>
      </select>
      <button v-if="vault" class="btn btn-primary" @click="createVaultKeep(keep)">Add to vault: </button>
      </form>
    </div>
    <div class="col-12">
      <!-- <vaultkeep :keep="keep"></vaultkeep> -->
    </div>
  </div>
</template>

<script>
import compass from './Compass'
// import vaultkeep from './VaultKeep'

export default {
  name: 'ActiveKeep',
  data () {
    return {
      vault: ""
    }
  },
  components: {
    compass,
    // vaultkeep
  },
//   mounted() {
//       this.$store.dispatch('getKeeps')
//   },
  computed:{
      keep(){
       return this.$store.state.activeKeep
      },
      user(){
        return this.$store.state.user
      },
      vaults(){
        return this.$store.state.userVaults
      },
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
      //  this.$store.dispatch('getKeeps')
      },

  }
  

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.bgFormat {
  background-color:aquamarine;
}

</style>
