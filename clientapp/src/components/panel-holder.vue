<template>
  <div class="app-wrapper">
    <div class="logo-main">
      <h1> LOGO HERE</h1>
      <div class="login-holder">
        <input type="text" placeholder="Enter username" name="username" v-model="currentUser.Name"/>
    </div>
    </div>        
    <div class="apps-nav">
        <div class="nav-wrapper">
            <div class="app-item" v-for="app in apps" v-on:click="current = app.panel">
            <img :src="app.logo" :title="app.name"/>
            </div>
        </div>      
      <div class="comp-holder">
      <component :is="current"></component>
    </div>
    </div>    
    </div>
</template>

<script>
import HomePanel from './home-panel'
import BalancePanel from './balance-panel'
import TransferPanel from './transfer-panel'
import WithdrawPanel from './withdraw-panel'
import CallsPanel from './calls-panel'

import {mapState} from 'vuex'

const apps =
  [
    { 'actionName': 'home',
      'logo': require('@/assets/apps/all.svg'),
      'panel': 'HomePanel'},
    { 'actionName': 'balance',
      'logo': require('@/assets/apps/files.svg'),
      'panel': 'BalancePanel'},
    { 'actionName': 'withdraw',
      'logo': require('@/assets/apps/files.svg'),
      'panel': 'WithdrawPanel'},
    { 'actionName': 'transfer',
      'logo': require('@/assets/apps/files.svg'),
      'panel': 'TransferPanel'},
    { 'name': 'calls',
      'logo': require('@/assets/apps/photos.svg'),
      'panel': 'CallsPanel'}    
  ]

export default {
  data () {
    return {
      apps,
      current: 'HomePanel'
    }
  },
  components: {
    HomePanel,
    WithdrawPanel,
    BalancePanel,
    TransferPanel,
    CallsPanel
  },
  computed: {
    ...mapState(['currentUser'])
}
}
</script>

<style lang="scss" scoped>

 .app-wrapper{
    width: 100%;
    background-color: #f5f7fa;
    display: flex;
    flex-direction: column;

    .logo-main {
        display: flex;
        height: 40%;
        width: 100%;
        padding-bottom: 1%;
        align-items: center;

        .login-holder {
            margin-right: auto;
            margin-left: auto;
            height: 100%;
            position: relative;
          
          input {
            bottom: 0;
            position: absolute;
          }
        }
    }

    .apps-nav {
        display: flex;
        height: 100%;
        align-items: center;
        border: solid 1px #e6e9f2;

        .nav-wrapper {
            padding-left: 1%;
            width: 10%;            
            height: 100%;
            border: solid 1px #e6e9f2;
            overflow-y: auto;
            overflow-x: hidden;            

            .app-item {
                width: 200px;
                height: 150px;
                position: relative;
                display: inline-block;
                overflow: hidden;
                margin: 0;

                img {
                    display: block;
                    position: absolute;
                    top: 50%;
                    left: 50%;
                    min-height: 100%;
                    min-width: 100%;
                    transform: translate(-50%, -50%);
                }
            }            
        }

        .comp-holder {
            margin-right: auto;
            margin-left: auto;
            height: 100%;
            width: 50%;
        }
    }
 }

</style>
