<template>
  <div class="base-wrapper">
  	<img :src="logo" :title="actionTitle"/>
    <div class="header-md">{{ actionTitle }}</div>
    <!--the appropriate input should go here-->
  </div>
</template>
<script>
export default {
  props: [ 'logo', 'actionTitle' ]
}
</script>
