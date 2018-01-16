<template>
    <div class="keep-display">
        <div class="row">
            <div class="keeps-div col-sm-3" v-for="keep in keeps" v-if="keep.public">
                <div class="single-keep-div text-center thumbnail">
                    <img class="full-width keep-img" :src="keep.imageUrl" alt="Image Url">
                    <div class="keep-caption-div">
                        <span>
                            <i class="fa fa-xing"></i>:{{keep.keeps}}
                        </span>
                        <span>
                            <i class="fa fa-share"></i>:{{keep.shares}}
                        </span>
                        <span>
                            <i class="fa fa-eye"></i>:{{keep.views}}
                        </span>
                    </div>
                    <div class="keep-caption-div keep-title">
                        {{keep.name}}
                    </div>
                </div>
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
    .full-width {
        width: 100%;
    }

    .keep-img {
        margin-bottom: 20px;
    }

    .single-keep-div {
        margin: 5px;
    }

    .keep-caption-div {
        font-size: 1em;
        color: #919c9b;
        border-top: 1px solid #f1f1f0;
        /* border-bottom: 1px solid #f1f1f0; */
        width: 90%;
        margin: auto;
        padding: 20px;
    }

    .keep-title {
        font-family: sans-serif;
        font-size: 1.75em;
        font-weight: 100;
    }

    .thumbnail {
        padding: 0;
        border: 1px solid #f1f1f0;
        border-radius: 0;
    }
</style>