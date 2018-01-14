<template>
  <div class="keepr container">
    <LogoBar></LogoBar>
    <div class="temp-div">
      <p>Welcome {{currentUser.username}}</p>
      <p>Current User: {{currentUser}}</p>
    </div>
    <KeepDisplay></KeepDisplay>
  </div>
</template>

<script>
  import LogoBar from './LogoBar'
  import KeepDisplay from './KeepDisplay'
  export default {
    name: 'Keepr',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('authenticate')
    },
    methods: {

    },
    computed: {
      currentUser() {
        return this.$store.state.currentUser
      }
    },
    components: {
      LogoBar,
      KeepDisplay
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>