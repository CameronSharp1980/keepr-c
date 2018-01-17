<template>
    <div class="keep-display">
        <div class="row">
            <div v-for="(keep, i) in keeps" v-if="keep.public">
                <!-- <div class="keeps-div col-sm-3" v-if="i == 0">
                    1
                    <Keep :keepProp="keep"></Keep>
                </div>
                <div v-else-if="i % 4 == 0">
                    <div class="row">
                        2
                        <div class="keeps-div col-sm-3">
                            <Keep :keepProp="keep"></Keep>
                        </div>
                    </div>
                </div>
                <div class="keeps-div col-sm-3" v-else>
                    3
                    <Keep :keepProp="keep"></Keep>
                </div> -->

                <div class="keeps-div col-xs-3">
                    <Keep :keepProp="keep"></Keep>
                </div>
            </div>

            <!-- <div class="keeps-div col-xs-3">
                    <Keep :keepProp="keep"></Keep>
                </div>
                <div class="clearfix visible-xs-12" v-if="i % 4 === 0 && i != 0"></div>
            </div> -->
        </div>
    </div>
    </div>
</template>

<script>
    import Keep from './Keep'
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
            Keep
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