<template>
  <div class="apps-panel-wrapper">
      <div class="app-panel-item" v-for="app in apps" :class="{selected:app === 'home'}" v-on:click="currentApp = app">
          <img :src="app.logo" :title="app.name"/>
      </div>
  </div>
</template>

<script>

import HomePanel from './home-panel'
import TransferPanel from './transfer-panel'
// import WithdrawPanel from './withdraw-panel'
// import CallsPanel from './calls-panel'
// import BalancePanel from './balance-panel'
import {mapState} from 'vuex'
const apps =
  [
    { 'name': 'home',
      'logo': require('@/assets/apps/all.svg'),
      'panel': HomePanel},
    { 'name': 'transfer',
      'logo': require('@/assets/apps/files.svg'),
      'panel': TransferPanel}
    // { 'name': 'withdraw',
    //   'logo': require('@/assets/apps/todo.svg'),
    //   'panel': WithdrawPanel},
    // { 'name': 'calls',
    //   'logo': require('@/assets/apps/photos.svg'),
    //   'panel': CallsPanel},
    // { 'name': 'balance',
    //   'logo': require('@/assets/apps/desktop.svg'),
    //   'panel': BalancePanel}
  ]
export default {
  data () {
    return {
      apps,
      currentApp: apps[0]
    }
  },
  computed: {
    ...mapState(['shownApp']),
  },
  watch: {
    currentApp (currentApp) {
      this.shownApp = currentApp
    }
  }
}
</script>

<style lang="scss" scoped>
.apps-panel-wrapper{
  flex:0 0 70px;
  background-color: #454c68;
  box-shadow: 0 0 8px 0 rgba(0, 0, 0, 0.08);
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-top: 20px;
}

.app-panel-item{
    width:40px;
    height:40px;
    border-radius: 50%;
    background-color: rgba(255, 255, 255, 0.2);
    margin-bottom: 25px;
    display:flex;
    align-items: center;
    justify-content: center;

    &.selected{
        background-color: #47a0f9;
        border: solid 1px #459bf3;
    }

    //cuz images are bad
    img{
        margin-left: 4px;
        margin-top:5px;
    }
}
</style>
