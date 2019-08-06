<template>
  <div class="container-fluid bgFormat">
   
        <compass></compass>

  <div class="row createKeepFormat justify-content-center">
    <form class="col-4-lg col-4-md col-8-sm cKForm" v-on:submit.prevent="createKeep(newkeep)">
      <div class="form-group">
        <input class="input form-control" type="text" name="keepname" placeholder="Name" id="name" v-model="newkeep.Name">
      </div>
      <div class="form-group">
        <input class="input form-control" type="text" name="keepdescription" placeholder="Description" id="description" v-model="newkeep.Description">
      </div>
      <div class="form-group">
        <input class="input form-control" type="text" name="keepimage" placeholder="Image Url" id="image" v-model="newkeep.ImageUrl">
      </div>
      <button class="btn btn-primary" type="submit">Create Keep</button>
    </form>
  </div>
  <div class="row">
    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 keepFormat" v-for="keep in keeps" v-bind:key="keep._id">
      <div class="card cK">
        <img class="card-img-top" :src="keep.imageUrl" alt="Images">
        <div class="card-body">
          <p class="card-title">{{keep.name}}</p> 
          <p class="card-text">{{keep.description}}</p>
          <p class="card-text">Shares: {{keep.share}}</p>
          <p class="card-text">Views: {{keep.view}}</p>
          <vaultkeep :keep="keep"></vaultkeep>
        </div>
      </div>
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
  background-color:rgb(19,148,73);
}
.keepFormat{
   border: 1px solid black;
   height:fit-content;
/*  margin: 1em auto;
  padding: 1em 1em;
  
 
  border-radius:5px; */
}
.cK{
    border: 1px solid black;
 /* margin: 1em 1em;  */
  /* padding: 1em 1em; */
  /* height:fit-content; */
 
  border-radius:5px;
  /* width:100%; */
}
p {
  /* text-align: left; */
  padding: 1px;
  margin:1px;
}
.card-body{
  background-color:grey;
  margin:0px;
}
.createKeepFormat{
 
  padding:10px;
  border-top: 10px solid black;
  border-bottom: 5px solid black;
  /* border-radius: 10px; */
}
.cKForm{
  background-color:cadetblue;
  border-radius:10px;
  margin:10px;
  padding:10px;
}
.form-group{
  margin:5px;

}
.form-group:hover{
  box-shadow: 0px 0px 5px 3px grey;
}
</style>
