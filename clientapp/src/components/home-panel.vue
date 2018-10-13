<template>
    <div class="welcome-wrapper">

        <div class="header-md">Welcome To Dean's Portfolio</div>
        <div class="header-md">Here You can select stuff and it will mail them</div>
    </div>
</template>

<script>

export default {
  computed: {
  },
  methods: {
  }
}
</script>

<style lang="scss" scoped>

.right-panel-wrapper{
    border-left: solid 1px #d0d4e4;
    background-color: #f5f7fa;
    flex:0 0 calc(270px -30px);
    padding:30px;
    overflow: hidden;
}

.recent-users-wrapper{
    display: grid;
    grid-gap: 30px;
    grid-template-columns: repeat(3, 1fr);
    margin-top: 30px;
    margin-bottom: 50px;

    .recent-user{
        position: relative;
        width: 50px;
        height:50px;

        .badge{
            width: 10px;
            height: 10px;
            border-radius: 100%;
            background-color: #ff5575;
            border: solid 2px #f5f7fa;
            right:0;
            position: absolute;
        }

        img{
            border-radius: 100%;
            height: 100%;
            width:100%;
        }
    }
}

.recent-photos-wrapper{
    display: grid;
    grid-gap: 20px;
    grid-template-columns: repeat(3,60px);
    grid-auto-rows: 85px;
    margin-top: 30px;

    img{
       height: calc(100% - 8px); //minus border
       width: calc(100% - 8px); //minus border
       border: solid 4px #fff;
       box-shadow: 0 1px 6px 0 rgba(0, 0, 0, 0.1);

        &:nth-child(1n+0){
            grid-column: 1 / 3;
            grid-row:span 2;
        }

        &:nth-child(2n+0),&:nth-child(3n+0),&:nth-child(5n+0){
            grid-column: initial;
            grid-row: initial;
        }

        &:nth-child(4n+0){
            grid-column: 1 / 3;
            grid-row: initial;
        }
    }
}

</style>
