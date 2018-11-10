// import _ from 'lodash'
// import uuid from 'uuid'
import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const myApi = axios.create({
  baseURL: 'http://localhost:1995/',
  withCredentials: true,
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

export default new Vuex.Store({
  state: {
    username: 'Dean'
    // shownApp: { 'name': 'home',
    //   'logo': require('@/assets/apps/all.svg'),
    //   'panel': HomePanel}
  },
  mutations: {
    getUserInfo (ctrlname, username) {
      let reqUri = 'api/' + ctrlname + '/' + username
      myApi.get(reqUri).then(res => {
        if (res.data.Succeed) {
          console.log('success')
        } else {
          console.log(res.data)
        }
      }).catch(e => {
        alert('Got error while fetching users from server ' + e.message)
      })
      return 8000
    },
    sendRequest (ctrlname, username, dataObj) {
      let reqUri = 'api/' + ctrlname + '/' + username
      myApi.get(reqUri, dataObj).then(res => {
        if (res.data.Succeed) {
          console.log('success')
        } else {
          console.log(res.data)
        }
      }).catch(e => {
        alert('Got error while fetching users from server ' + e.message)
      })
    }
  }
})
