<template>
  <div class="sync-panel-wrapper">
    <div class="header-md">Sync with external provider</div>
  </div>
</template>
<script>
import { mapState } from 'vuex'

export default {
  computed: {
    ...mapState(['shownApp'])
  },
  methods: {
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
