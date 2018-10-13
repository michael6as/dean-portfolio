// import _ from 'lodash'
// import uuid from 'uuid'
import Vue from 'vue'
import Vuex from 'vuex'
import HomePanel from './components/home-panel'
// import axios from 'axios'

Vue.use(Vuex)

// const localStorage = window.localStorage

// function updateStorage (users) {
//   localStorage.setItem('users', JSON.stringify(users))
// }

export default new Vuex.Store({
  state: {
    shownApp: { 'name': 'home',
      'logo': require('@/assets/apps/all.svg'),
      'panel': HomePanel}
  },
  mutations: {
  }
})
