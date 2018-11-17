<template>
  <div class="panel-wrapper">        
        <div class="header-md">Balance Is:  {{ balance }}  </div>

        <div class="tranfer-form">
          <input type="text" placeholder="Enter value for Tranfer" name="amountToTransfer" v-model="amountToTransfer"/>
          <input type="text" placeholder="Enter recipient name" name="recipient" v-model="recipient"/>
          <div class="execute-btn" @click="execute">Transfer</div>                    
        </div>        
    </div>
</template>
<script>
import {mapMutations,mapState} from 'vuex'

export default {
  props: ['user'],
  data () {
    return {            
      ctrlName: 'finance',
      actionName: 'transfer',
      amountToTransfer: 0,
      recipient:null
    }
  },
  computed: {
    ...mapState(['currentUser']),
    balance: function() {
        return this.getUserInfo(this.ctrlName)
    }
  },
  methods:{
      ...mapMutations(['getUserInfo','sendRequest']),
      execute: function() {
        sendRequest(ctrlName,{'actionName': actionName, 'recipient': recipient, 'amount': amountToTransfer})
      }      
    }      
}
</script>

<style>
  .sync-panel-wrapper {
    background-color: #f5f7fa;
    padding: 1%;
  }

  .sign-btn-wrapper {
    padding-top: 6%;
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .sign-btn {
    margin-top: 0.5%;
    width: 130px;
    height: 30px;
    border-radius: 4px;
    font-size: 13px;
    line-height: 1;
    color: #fff;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: dodgerblue
  }

  .signed-btn {
    background-color: aquamarine;
  }
</style>
