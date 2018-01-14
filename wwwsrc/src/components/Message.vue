<template>
    <div class="message-box" v-if="message">
        Message: {{message}}
    </div>
</template>

<script>
    export default {
        name: 'message',
        computed: {
            message() {
                return this.$store.state.message
            }
        }
    }
</script>

<style scoped>
</style>