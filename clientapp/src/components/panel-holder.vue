<template>
  <div class="app-wrapper">
    <div class="logo-main">
      <h1> LOGO HERE</h1>
      <div class="login-holder">
        <input type="text" placeholder="Enter username" name="username" v-model="username"/>
    </div>
    </div>        
    <div class="apps-nav">
      <div class="app-item" v-for="app in apps" v-on:click="current = app.panel">
        <img :src="app.logo" :title="app.name"/>
      </div>
    </div>
    <div class="comp-holder">
      <component :is="current"></component>
    </div>
    </div>
</template>

<script>
import HomePanel from './home-panel'
import TransferPanel from './transfer-panel'
import BalancePanel from './balance-panel'
// import {mapState} from 'vuex'

const apps =
  [
    { 'actionName': 'home',
      'logo': require('@/assets/apps/all.svg'),
      'panel': 'HomePanel'},
    { 'actionName': 'transfer',
      'logo': require('@/assets/apps/files.svg'),
      'panel': 'TransferPanel'},
      { 'actionName': 'balance',
      'logo': require('@/assets/apps/files.svg'),
      'panel': 'BalancePanel'}
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
      current: 'HomePanel'
    }
  },
  components: {
    HomePanel,
    TransferPanel
  }
}
</script>

<style lang="scss" scoped>

.app-wrapper{
  // border: solid 1px #e6e9f2;
  // padding-top: 1%;
    flex:1;
    display: flex;
    flex-direction: column;
    background-color: #f5f7fa;

    .logo-main{
        // padding-left: 1%;
        // width:100%;
        // position: absolute;
    }


  .apps-nv{
    border: solid 1px #e6e9f2;
    margin-top: 6%;
    height: 100%;
    padding-left: 1%;
    position: absolute;
  }

  .im{
    height: 60px;
    width: 60px;
  }

  .cmp-holder{
    border: solid 1px #e6e9f2;
    margin-top: 6%;
    margin-left:auto;
    margin-right: auto;
    align-items: center;
  }
    .lgo{
        margin-top: 98px;
        margin-bottom: 74px;
        height:62px;
        width:200px;
    }
}

.usr-form{
    width:520px;
    display: flex;
    flex-direction: column;

    .user-details,.account-details{
        margin-top:20px;
    }

    .user-details{
        margin-bottom: 30px;
        display: grid;
        grid-gap: 20px;
        grid-template-columns: 1fr 1fr;

        .email-input{
            grid-column: 1 / 3;
        }

    }

    .account-details{
        display: grid;
        grid-gap: 20px;
        grid-template-columns: 1fr 144px;
        grid-template-rows: repeat(3, 1fr);

        .add-photo-wrapper{
            grid-row: 1 / 4;
            grid-column: 2 / 3;
            border-radius: 5px;
            box-shadow: 0 1px 6px 0 rgba(0, 0, 0, 0.1);
            background-color: #ffffff;
            border: solid 1px #e6e9f2;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-end;

            .add-photo-btn{
                margin-bottom: 12px;
                font-size: 12px;
                color: #9ba0b2;
                display: flex;
                align-items: center;
                padding: 5px;

                span{
                    margin-left: 10px;
                }
            }

            .current-photo{
                width:100px;
                height:92px;
                margin-bottom: -0.2px;
            }

        }
    }

    #fileUpload{
        display:none;
    }

    .actions{
        display: flex;
        margin-top: 41px;
        justify-content: flex-end;

        .clear-btn,.add-btn{
            width: 94px;
            height: 30px;
            border-radius: 4px;
            font-size: 13px;
            line-height: 1;
            color:#fff;
            display:flex;
            align-items: center;
            justify-content: center;
        }

        .clear-btn{
            background-color: #ff5575;
            margin-right: 20px;
        }

        .add-btn{
            background-color: #5891e2;
        }
    }
}
</style>
