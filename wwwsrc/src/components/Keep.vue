<template>
    <div class="keep">
        <div class="single-keep-div text-center thumbnail">
            <div class="image-div">
                <img class="full-width keep-img" :src="keepProp.imageUrl" alt="Image Url">
                <span data-toggle="modal" :data-target="'#keep-modal' + keepProp.id" class="image-button keep-button fa fa-xing"></span>
                <span @click="incrementViews" data-toggle="modal" :data-target="'#viewModal' + keepProp.id" class="image-button view-button fa fa-vimeo"></span>
            </div>
            <div class="keep-caption-div">
                <span>
                    <i class="fa fa-xing"></i>:{{keepProp.keeps}}
                </span>
                <span>
                    <i class="fa fa-share"></i>:{{keepProp.shares}}
                </span>
                <span>
                    <i class="fa fa-eye"></i>:{{keepProp.views}}
                </span>
            </div>
            <div class="keep-caption-div keep-title">
                {{keepProp.name}}
            </div>
        </div>


        <!-- KEEP (Add to vualt) MODAL -->
        <div class="modal fade" :id="'keep-modal' + keepProp.id" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">{{keepProp.name}}</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="row">
                                    <div class="col-sm-3 height-100 text-center manager-thumb-div">
                                        <img class="manager-thumb" :src="keepProp.imageUrl" :alt="keepProp.name">
                                    </div>
                                    <div class="col-sm-7 height-100 text-center manager-title-div">
                                        <span class="manager-title">{{keepProp.name}}</span>
                                    </div>
                                    <div class="col-sm-2 height-100 text-center manager-controls-div">
                                        <i @click="" class="fa fa-ban manager-controls"></i>
                                        <!-- <i class="fa fa-arrow-circle-o-up manager-controls"></i> -->
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div> -->
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <!-- KEEP (Add to vualt) MODAL END -->


        <!-- VIEW MODAL -->
        <div class="modal fade" :id="'viewModal' + keepProp.id" tabindex="-1" role="dialog" aria-labelledby="viewModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">{{keepProp.name}}</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12 view-modal-img-div modal-div text-center">
                                <img class="manager-thumb height-100" :src="keepProp.imageUrl" :alt="keepProp.name">
                            </div>
                            <!-- <div class="col-sm-12 modal-div view-modal-title text-center">
                                <span class="manager-title">{{keepProp.name}}</span>
                            </div> -->
                            <div class="col-sm-12 modal-div text-center">
                                <p>{{keepProp.description}}</p>
                            </div>

                        </div>
                    </div>
                    <!-- <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div> -->
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <!-- KEEP MODAL END -->



    </div>
</template>

<script>
    export default {
        name: 'Keep',
        props: ["keepProp"],
        data() {
            return {

            }
        },
        mounted() {
            // this.$store.dispatch('getKeeps')
        },
        methods: {
            incrementViews() {
                this.$store.dispatch('incrementViews', { keep: this.keepProp })
            }
        },
        computed: {
            // keeps() {
            //     return this.$store.state.keeps
            // }
            currentUser() {
                return this.$store.state.currentUser
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

    .image-div {
        position: relative;
    }

    .keep-img:hover {
        opacity: .5;
    }

    .image-button {
        position: absolute;
        display: none;
    }

    .image-div:hover span.image-button {
        display: block;
    }

    .keep-button {
        font-size: 1.5em;
        padding: 10px;
        background-color: #fd0090;
        color: white;
        top: 2%;
        right: 2%;
    }

    .view-button {
        font-size: 1.5em;
        padding: 10px;
        background-color: #9854bb;
        color: white;
        top: 2%;
        left: 2%;
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

    .max-height-80vh {
        max-height: 80vh;
        overflow: auto;
    }

    .view-modal-img-div {
        height: 150px;
    }

    .height-100 {
        height: 100%;
    }

    .modal-div {
        border-bottom: 1px solid #F5F5F4;
        padding: 5px;
        margin-bottom: 5px;
        margin-top: 5px;
    }

    .view-modal-title {
        font-weight: bold;
    }
</style>