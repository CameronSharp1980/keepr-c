<template>
    <div class="keep-display">
        <div class="row">
            <div class="keep-div thumbnail col-sm-3" v-for="keep in keeps">
                <img :src="keep.imageUrl" alt="Image Url">
                <p>Name: {{keep.name}}</p>
                <p>Description: {{keep.description}}</p>
                <p>Views: {{keep.views}}</p>
                <p>Keeps: {{keep.keeps}}</p>
                <p>Shares: {{keep.shares}}</p>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'KeepDisplay',
        data() {
            return {

            }
        },
        mounted() {
            this.$store.dispatch('getKeeps')
        },
        methods: {

        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            }
        },
        components: {

        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>