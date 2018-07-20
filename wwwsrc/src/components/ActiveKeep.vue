<template>
  <div class="activeKeep bgFormat">
    <compass></compass>
    <img :src="keep.imageUrl" alt="Fun fun">
    <p>{{keep.name}}</p> 
    <p>{{keep.description}}</p>
    <p>Shares: {{keep.share}}</p>
    <p>Views: {{keep.view}}</p>
  </div>
</template>

<script>
import compass from './Compass'
export default {
  name: 'ActiveKeep',
  data () {
    return {}
  },
  components: {
    compass
  },
//   mounted() {
//       this.$store.dispatch('getKeeps')
//   },
  computed:{
      keep(){
       return this.$store.state.activeKeep
      }
  },
  methods: {}
  

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.bgFormat {
  background-color:aquamarine;
}
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
