<template>
  <div id="app" class="container">
    <!-- <Error></Error> -->
    <!-- <Message></Message> -->
    <!-- <div class="temp-div">
      <p>Welcome {{currentUser.username}}</p>
      <p>Current User: {{currentUser}}</p>
      <p>User Keeps: {{userKeeps}}</p>
      <p>User Vaults: {{userVaults}}</p>
      <p>Current Vault: {{currentVault}}</p>
      <p>Current Vaults Keeps: {{currentVaultKeeps}}</p>
    </div> -->
    <LogoBar></LogoBar>
    <router-view/>

  </div>
</template>

<script>
  import Error from './components/Error'
  import Message from './components/Message'
  import LogoBar from './components/LogoBar'
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    mounted() {
      // this.$store.dispatch('authenticate')
    },
    components: {
      Error,
      Message,
      LogoBar
    },
    methods: {

    },
    computed: {
      currentUser() {
        return this.$store.state.currentUser
      },
      userKeeps() {
        return this.$store.state.userKeeps
      },
      userVaults() {
        return this.$store.state.userVaults
      },
      currentVault() {
        return this.$store.state.currentVault
      },
      currentVaultKeeps() {
        return this.$store.state.currentVaultKeeps
      }
    }
  }
</script>

<style>
  #app {
    min-height: 100vh;
  }

  .hand-cursor:hover {
    cursor: pointer;
  }
</style>