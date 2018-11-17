<template>
    <div class="panel-wrapper">        
        <div class="header-md">Balance Is:  {{ currentUser }}  </div>        
    </div>
</template>

<script>
import {mapMutations,mapState} from 'vuex'

export default {
  props: ['user'],
  data () {
    return {            
      ctrlName: 'finance',
      actionName: 'balance'
    }
  },
  created: function() {
    this.getUserInfo(this.ctrlName)
  },
  computed: {
    ...mapState(['currentUser'])
  },
  methods:{
      ...mapMutations(['getUserInfo','sendRequest'])      
      }      
}
</script>

<style lang="scss" scoped>

</style>
