<template>
  <div class="keeps bgFormat">
     <div>
    <compass></compass>
    </div>
    <form v-on:submit.prevent="createKeep(newkeep)">
    <input class="input" type="text" name="keepname" placeholder="Name" id="name" v-model="newkeep.Name">
    <input class="input" type="text" name="keepdescription" placeholder="Description" id="description" v-model="newkeep.Description">
    <input class="input" type="text" name="keepimage" placeholder="Image Url" id="image" v-model="newkeep.ImageUrl">
    <button class="btn btn-primary" type="submit">Create Keep</button>
  </form>

  <!--Create keep needs to create a keep and a vault keep  --> 

  <div v-for="keep in keeps" v-bind:key="keep._id">
    
    
    <p>{{keep.name}}</p>
    <img :src="keep.imageUrl" alt="Images">
    <!-- 
      <button @click="createVaultKeep(keep)">Add keep</button>
      <select v-model="vault">  
        <option disabled value=''>Add Keep to vault: </option>
        <option v-for="vault in vaults" :key="vault._id" :value="trip">{{vault.name}}</option>
      </select>
      <button @click="createVaultKeep(keep)">Add to vault: </button> 
    -->

    <vaultkeep :keep="keep"></vaultkeep> 
    
  
  </div>
  </div>
</template>

<script>
import vaultkeep from "./VaultKeep";
import compass from "./Compass"

export default {
  name: "Keep",
  data() {
    return {
      newkeep: {
        Name: "",
        Description: "",
        ImageUrl: ""
      },
      vault: {}
    };
  },
  components: {
    vaultkeep,
    compass
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      //  debugger
      // this.$store.dispatch('getKeeps')
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.userVaults;
    }
    //   getKeeps(){
    //       this.$store.dispatch('getKeeps')
    //   }
    //   vaultkeeps(){
    //     return this.$store.state
    //   }
  },
  methods: {
    createKeep(keep) {
      //     debugger
      var author = this.$store.state.user.id;
      keep.AuthorId = author;
      this.$store.dispatch("createKeep", keep);
    //  this.$store.dispatch("getKeeps");
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.bgFormat {
  background-color:aquamarine;
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
