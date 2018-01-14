<template>
  <div id="app">
    <Error></Error>
    <Message></Message>
    <router-view/>
  </div>
</template>

<script>
  import Error from './components/Error'
  import Message from './components/Message'
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
      Message
    },
    methods: {

    },
    computed: {

    }
  }
</script>

<style>
  #app {
    min-height: 100vh;
  }
</style>