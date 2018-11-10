<template>
  <div id="app">
    <panel-holder/>
  </div>
</template>

<script>
import PanelHolder from './components/panel-holder'

export default {
  name: 'App',
  components: {
    PanelHolder
  }
}
</script>

<style lang="scss">
html,body{
  height: 100%;
  width:100%;
  margin:0;
  padding:0;
}

#app {
  font-family: OpenSans, 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  height:100%;
  display: flex;
}

.logo-main{
  padding-left: 1%;
  position: absolute;
}
input{
  height: 30px;
  border-radius: 5px;
  box-shadow: 0 1px 6px 0 rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
  border: solid 1px #e6e9f2;
  padding-left:12px;
  font-size: 12px;

  &.error{
    border: solid 1px rgb(255,0,0);
  }
}

input::placeholder{
  color: #a5a8b5;
}

.header-md{
  font-size: 16px;
  font-weight: bold;
}
</style>
