<template>
  <div class="keeps container-fluid bgFormat">
    <div class="row">
      <div class="col-12">
        <compass></compass>
      </div>
  </div>
  <div class="row justify-content-center">
    <div class="col-12">
<form>
  <div class="form-row">
    <!-- <div class="form-group col-md-6">
      <label for="inputEmail4">Email</label>
      <input type="email" class="form-control" id="inputEmail4" placeholder="Email">
    </div> -->
    <!-- <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
      <input type="password" class="form-control" id="inputPassword4" placeholder="Password">
    </div>-->
  </div> 
  <div class="form-group">
    <label for="inputAddress">Address</label>
    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
  </div>
  <div class="form-group">
    <label for="inputAddress2">Address 2</label>
    <input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor">
  </div>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="form-group col-md-4">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control">
        <option selected>Choose...</option>
        <option>...</option>
      </select>
    </div>
    <div class="form-group col-md-2">
      <label for="inputZip">Zip</label>
      <input type="text" class="form-control" id="inputZip">
    </div>
  </div>
  <div class="form-group">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" id="gridCheck">
      <label class="form-check-label" for="gridCheck">
        Check me out
      </label>
    </div>
  </div>
  <button type="submit" class="btn btn-primary">Sign in</button>
</form>





      <form class="align-content-center" v-on:submit.prevent="createKeep(newkeep)">
        
        <input class="input" type="text" name="keepname" placeholder="Name" id="name" v-model="newkeep.Name">
        <input class="input" type="text" name="keepdescription" placeholder="Description" id="description" v-model="newkeep.Description">
        <input class="input" type="text" name="keepimage" placeholder="Image Url" id="image" v-model="newkeep.ImageUrl">
        <button class="btn btn-primary" type="submit">Create Keep</button>
      </form>
    </div>

  <div class="col-lg-3 col-md-4 col-sm-10" v-for="keep in keeps" v-bind:key="keep._id">
    <!-- <p>{{keep.name}}</p> -->
    <p class="alert alert-success" role="alert">{{keep.name}}</p> 
    <p>{{keep.description}}</p>
    <img class="img-fluid" :src="keep.imageUrl" alt="Images">
    <div>
      <span>Shares {{keep.share}}</span>
      <span>Views: {{keep.view}}</span>
    </div>
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
