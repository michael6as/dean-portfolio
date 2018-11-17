<template>
  <div class="calls-panel-wrapper">
    <div class="header-md">Call To:</div>
    <div class="call-form">
          <input type="text" placeholder="Enter Number to call" name="phoneNum" v-model="phoneNum"/>          
          <div class="execute-btn" @click="execute">Call</div>                    
        </div>  
  </div>
</template>
<script>
import {mapMutations,mapState} from 'vuex'

export default {
  props: ['user'],
  data () {
    return {            
      phoneNum:null,
    }
  },
  computed: {
    ...mapState(['currentUser'])
  },
  methods:{
      ...mapMutations(['getUserInfo','sendRequest']),
      execute: function() {
        sendRequest(ctrlName,{'actionName': actionName, 'phoneNum': phoneNum})
      }      
    }      
}
</script>

<style lang="scss" scoped>

</style>
