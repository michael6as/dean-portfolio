<template>
    <div class="panel-wrapper">        
        <div class="header-md">Balance Is:  {{ balance }}  </div>      

        <div class="tranfer-form">
          <input type="text" placeholder="Enter value to withdraw" name="amount" v-model="amount"/>          
          <div class="execute-btn" @click="execute">Withdraw</div>                    
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
      actionName: 'withdraw',
      amount:0
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
        sendRequest(ctrlName,{'actionName': actionName, 'amount': amount})
      }      
    }      
}
</script>

<style lang="scss" scoped>

</style>
