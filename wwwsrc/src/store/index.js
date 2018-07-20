import vue from 'vue'
import vuex from 'vuex'
// @ts-ignore
import axios from 'axios'
import router from '../router'
//var production = !window.location.host.includes('localhost');
//var baseUrl = production ? 'https://i-be-trippin.herokuapp.com' : 'http://localhost:5000';
vue.use(vuex)

var baseUrl = "//localhost:5000";
//var baseUrl = "https://keeper-1.herokuapp.com"
// Google places API Key: AIzaSyA2l-r77x24uatF20-TRoAEceNL_fRKjcg

var server = axios.create({
  baseURL: baseUrl,
  timeout: 3000,
  withCredentials: true
})

export default new vuex.Store({
  state: {
    user: {},
    userVaults: [],
    activeVault: {},
    keeps: [],
    vaultKeeps: [],
    userKeeps: [],
    activeKeep: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setUserVaults(state, vaults) {
      state.userVaults = vaults
    },
    addVault(state, vault) {
      state.userVaults.unshift(vault)
    },
    setActiveVault(state, vault) {
      state.activeVault = vault
    },
    setKeep(state, keep) {
      state.keeps = keep
    },
    addVaultKeep(state, vaultKeep) {
      state.userKeeps.unshift(vaultKeep)
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    },
    removeVaultKeep(state, vaultkeep) {
      state.vaultKeeps = vaultkeep
    },
    viewKeep(state, keep){
      state.activeKeep = keep
    }

    // setApiResults(state, results) {
    //   state.apiResults = results
    // },
    // setUserResults(state, results) {
    //   state.userResults = results
    // },
    // setDestinations(state, destinations) {
    //   state.destinations = destinations
    // },
    // setActiveDest(state, destination) {
    //   state.activeDest = destination
    // },
    // setUserTodos(state, todos) {
    //   state.userTodos = todos
    // },
    // setGoogleTodos(state, todos) {
    //   state.googleTodos = todos
    // },
    // setNewTodo(state, todo) {
    //   state.userTodos.unshift(todo)
    // },
    // setComment(state, todo) {
    //   var index = state.userTodos.findIndex(item => {
    //     return item._id == todo._id
    //   })
    //   state.userTodos.splice(index, 1)
    //   state.userTodos.unshift(todo)
    // },
    // setUserTrips(state, trips) {
    //   state.userTrips = trips
    // },
    // setActiveTrip(state, trip) {
    //   state.activeTrip = trip
    // },
    // setRemoveTodo(state, todo) {
    //   var index = state.userTodos.findIndex(item => {
    //     return item._id == todo._id
    //   })
    //   state.userTodos.splice(index, 1);
    // },
    // setTodos(state, todos){
    //   state.todos = todos
    // },
    // setEditDestination(state, destination){
    //   var index = state.destinations.findIndex(t => {
    //     return t._id == destination._id
    //   })
    //   state.destinations.splice(index, 1, destination)                  
    // },
    // setEditTrip(state, trip) {
    //   var index = state.userTrips.findIndex(t => {
    //     return t._id == trip._id
    //   })
    //   state.userTrips.splice(index, 1, trip)
    // }
  },
  actions: {
    login({ dispatch, commit }, payload) {
      server.post('/account/login/', payload)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Home' })
          console.log(res.data)

          //  dispatch('authenticate')
        })
        .catch(res => {
          console.log(res.data)
        })
    },
    register({ dispatch, commit }, payload) {
      server.post('/account/register/', payload)
        .then(
          res => {
            commit('setUser', res.data)
            router.push({ name: 'Home' })
          })
        .catch(res => {
          console.log(res, "error")
        })
    },
    authenticate({ commit, dispatch }, bool) {
      server.get('/account/authenticate')
        .then(res => {
          //    debugger 
          commit('setUser', res.data)
          router.push({name: 'Home'})
        })
        .catch(res => {
          console.log(res)
        })
    },
    signOut({ commit, dispatch, state }) {
      server.delete('/logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'Login' })
        })
        .catch(res => {
          console.log(res.data)
        })
    },
    createUserVault({ commit, dispatch }, vault) {
      server.post('/api/vault', vault)
        .then(res => {
          commit('addVault', res.data)
        })
    },
    setActiveVault({ commit, dispatch }, vault) {
      commit('setActiveVault', vault)
    },
    deleteVault({commit, dispatch, state}, deletevault){
    //  debugger
      var temp = deletevault
      server.delete('/api/vault/delete/'+deletevault.id + "/author/" + deletevault.authorId)
      .then(res=>{
        dispatch('deleteVaultKeepsByVault', temp)
        router.push({name: "Home"})
        state.activeVault = {}
        console.log(res)
      }).catch(res=>{
        console.log(res)
      })
    },

    getUserVaults({ commit, dispatch }) {
      server.get('/api/vault')
        .then(res => {
          //    debugger
          console.log(res)
          commit('setUserVaults', res.data)
        })
    },
    createKeep({ commit, dispatch }, keep) {
    //  debugger
      server.post('/api/keep', keep)
        .then(res => {
          console.log(res)
          dispatch('getKeeps')
         // commit('setKeep', res.data)
        })
    },
    getKeeps({ commit, dispatch }) {
      // debugger
      server.get('/api/keep')
        .then(res => {
          commit('setKeep', res.data)
          console.log(res)
        })
    },
    
    deleteKeep({commit, dispatch}, keep){
    // debugger
      server.delete('/api/keep/'+ keep.id)
      .then(res=>{
        dispatch('getKeeps')
        console.log(res)
      })
      .catch(res => {
        console.log(res.data)
      })
    },
    viewKeep({commit, dispatch}, keep){
      server.put('/api/keep/view/'+keep.id, keep)
      commit('viewKeep', keep)
      router.push({ name: 'ActiveKeep' })
    },

    // BUG: creates an asscosiated table, but if you delete a keep it no longer appears if anyone 
    // has it in their vault. The aoociated table entry stays and cant be deleted or viewed by user. 
    // Needd to create a table with 
    createVaultKeep({ commit, dispatch }, vaultKeep) {
  //  debugger
      server.post('/api/vaultkeep/' + vaultKeep.id, vaultKeep)
        .then(res => {
     //     debugger
          commit('addVaultKeep', res.data)

        })
        .catch(res => {
          console.log(res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      //  debugger
      server.get('/api/vaultkeep/' + vaultId)
        .then(res => {
            //  debugger
          //  dispatch('setVaultKeeps', res)
          commit('setVaultKeeps', res.data)
        })
        .catch(res => {
          console.log(Response)
        })
    },
    setVaultKeeps({ commit, dispatch }, keeps) {
      // debugger
      server.get('/api/vaultkeep/keeps', keeps)
        .then(res => {
          commit('setKeep', res.data)
          console.log(res)
        })
    },
    deleteVaultKeepsByVault({commit, dispatch}, vault){
   //   debugger
      server.delete('/api/vaultkeep/delete/vault/'+vault.id)
      .then(res=>{
        console.log(res)
      })
    },
    deleteVaultKeep({ commit, dispatch }, vaultkeep) {
   //   debugger
      server.delete('/api/vaultkeep/delete/' + vaultkeep.vaultId + '/' + vaultkeep.id)
        .then(res => {
          //  debugger
          // commit("removeVaultKeep", vaultkeep.id)
          dispatch("getVaultKeeps", vaultkeep.vaultId)
        })
        .catch(res => { console.log(res) })
    },
    publishKeep({ commit, dispatch }, keep) {
      server.put('/api/keep/publish/' + keep.id, keep)
        .then(res => {
          console.log(res)
        })
        .catch(res => {
          console.log(res)
        })
    },
    logout({ commit, dispatch, state }) {
      //  debugger
      server.delete('/account/logout/' + state.user.id)
        .then(res => {
          state.user = {}
          state.userVaults = []
          state.activeVault =  {}
          state.keeps = []
          state.vaultKeeps = [] 
          state.userKeeps = []
          state.activeKeep = {}
          router.push({ name: 'Login' })
          console.log(res)
        })
    }


  }
})

// ,
//     findDestination({ commit, dispatch }, destination) {
//       server.get('/api/locations/' + destination)
//         .then(res => {
//           console.log(res)
//           commit('setApiResults', res.data)
//           dispatch('getUserResults', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     getUserResults({ commit, dispatch }, searchResults) {
//       console.log(searchResults, 'search')
//       var search = searchResults[0]
//       server.get('/api/destinations/' + search.place_id + "/place")
//         .then(res => {
//           console.log(res.data)
//           commit('setUserResults', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     createTrip({ dispatch, commit, state }, trip) {
//       trip["author"] = state.user.displayName
//       server.post('/api/trips', trip)
//         .then(res => {
//           commit('addTrip', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     deleteTrip({ commit, dispatch, state }, trip) {
//       server.delete('/api/trips/' + trip._id)
//         .then(res => {
//           dispatch('getUsersTrips')
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     getUsersTrips({ dispatch, commit, state }) {
//       server.get('/api/trips/user/' + state.user._id)
//         .then(res => {
//           commit('setUserTrips', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     addDestination({ dispatch, commit, state }, destination) {
//       if (destination['geometry']) {
//         var newDestination = {
//           title: destination.name,
//           place_id: destination.place_id,
//           tripId: state.activeTrip._id,
//           long: destination.geometry.location.lng,
//           lat: destination.geometry.location.lat,
//           photo: destination.photo,
//           author: state.user.displayName
//         }
//       }
//       else {
//         var newDestination = {
//           title: destination.title,
//           place_id: destination.place_id,
//           tripId: state.activeTrip._id,
//           long: destination.long,
//           lat: destination.lat,
//           photo: destination.photo,
//           author: state.user.displayName
//         }
//       }
//       server.post('/api/destinations', newDestination)
//         .then(res => {
//           dispatch('getTripDestinations', res.data.tripId)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     deleteDest({ commit, dispatch, state }, dest) {
//       server.delete('/api/destinations/' + dest._id)
//         .then(res => {
//           console.log(res)
//           dispatch('getTripDestinations', dest.tripId)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     getTripDestinations({ dispatch, commit }, id) {
//       server.get('/api/trips/' + id + '/destinations')
//         .then(res => {
//           commit('setDestinations', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     editDest({commit, dispatch}, dest){
//       server.put('/api/destinations/'+ dest._id, dest)
//       .then(res=> {
//         commit('setEditDestination', res.data.destination)
//       })
//     },
//     selectActiveDest({ dispatch, commit }, dest) {
//       console.log('works', dest)
//       commit('setActiveDest', dest)
//     },
//     findTodos({ dispatch, commit, state }, category) {
//       server.get('/api/thingstodo/' + state.activeDest.place_id + '/' + category)
//         .then(res => {
//           commit('setTodos', res.data)
//           dispatch('getGoogleTodos', category)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     getGoogleTodos({ dispatch, commit, state }, category) {
//       var search = {
//         categories: category.replace(" ", "_"),
//         coords: state.activeDest.lat + ',' + state.activeDest.long
//       }
//       server.post('/api/nearby/places', search)
//         .then(res => {
//           console.log(res.data.results)
//           commit('setGoogleTodos', res.data.results)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     addTodo({ dispatch, commit, state }, todo) {
//       todo.destinationId = state.activeDest._id
//       todo.tripId = state.activeTrip._id
//       todo["author"] = state.user.displayName
//       todo.place_id = state.activeDest.place_id
//       server.post('/api/thingstodo', todo)
//         .then(res => {
//           commit('setNewTodo', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     addGoogleTodo({ dispatch, commit, state }, todo) {
//       var newTodo = {
//         place_id: state.activeDest.place_id,
//         title: todo.name,
//         categories: todo.types,
//         destinationId: state.activeDest._id,
//         tripId: state.activeTrip._id,
//         lat: todo.geometry.location.lat,
//         long: todo.geometry.location.lng
//       }
//       newTodo["author"] = state.user.displayName
//       server.post('/api/thingstodo', newTodo)
//         .then(res => {
//           commit('setNewTodo', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     selectActiveTrip({ dispatch, commit }, trip) {
//       commit("setActiveTrip", trip)
//     },
//     getDestTodos({ dispatch, commit }, id) {
//       server.get('/api/destinations/' + id + '/thingstodo')
//         .then(res => {
//           commit('setUserTodos', res.data)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     deleteTodo({ commit, dispatch }, todo) {
//       var temp = todo
//       server.delete('/api/thingstodo/' + todo._id)
//         .then(res => {
//           commit('setRemoveTodo', temp)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//     clearResults({ dispatch, commit }) {
//       commit('setApiResults', [])
//       commit('setUserResults', [])
//       commit('setGoogleTodos', [])
//       commit('setTodos', [])
//     },
//     editTodo({ dispatch, commit }, todo) {
//       server.put('/api/thingstodo/' + todo._id, todo)
//         .then(res => {
//           commit('setComment', res.data.thingtodo)
//         })
//         .catch(res => {
//           console.log(res)
//         })
//     },
//    deleteComment({dispatch, commit, state}, todo){
//       server.put('/api/thingstodo/' + todo._id, todo)
//       .then(res=>{
//         console.log(res.data.thingtodo)
//       })
//     },
//     editTrip({commit, dispatch}, trip) {
//       server.put("/api/trips/" + trip._id, trip)
//        .then(res => {
//          commit("setEditTrip", res.data.trip)
//        })
//     },
//     endDemo({ dispatch, commit, state }) {
//       if(state.user._id) {
//         server.delete('/end-demo/' + state.user._id)
//         .then(res => {
//           console.log(res)
//         })
//         .catch(err => {
//           console.log(err)
//         })
//       }
//     },
//     publishTrip({dispatch, commit}, trip) {
//       trip.published = !trip.published
//       var pub = {
//         published: !trip.published
//       }
//       server.put('/api/trip/publish/' + trip._id, pub)
//         .then(res => {
//           commit('setEditTrip', trip)
//         })
//         .catch(err => {
//           console.log(err)
//         })
//     }