<template>
  <div class="keep">
  <div v-for="keep in keeps" v-bind:key="keep._id">
    {{keep.name}}
    </div>
  </div>
</template>

<script>
export default {
  name: 'Keep',
  data () {
    return {
    // vault:{}
    }
  },
  mounted() {
  this.$store.dispatch('getKeeps')
  },
  computed:{
      keeps(){
        return this.$store.state.keeps
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
