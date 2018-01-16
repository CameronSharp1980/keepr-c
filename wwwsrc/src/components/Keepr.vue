<template>
  <div class="keepr">
    <KeepDisplay></KeepDisplay>
  </div>
</template>

<script>
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
      KeepDisplay
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>