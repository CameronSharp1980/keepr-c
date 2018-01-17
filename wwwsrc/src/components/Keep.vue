<template>
    <div class="keep">
        <div class="single-keep-div text-center thumbnail">
            <div class="image-div">
                <img class="full-width keep-img" :src="keepProp.imageUrl" alt="Image Url">
                <span data-toggle="modal" :data-target="'#keep-modal' + keepProp.id" class="hand-cursor image-button keep-button fa fa-xing" v-if="currentUser.username"></span>
                <span data-toggle="modal" data-target="#pleaseLoginModal" class="hand-cursor image-button keep-button fa fa-xing" v-else></span>
                <!-- WHEN YOU ADD SHARING, ADD ANOTHER BUTTON HERE TO ACCOUNT FOR USER LOGGED IN / OUT -->
                <span data-toggle="modal" :data-target="'#share-modal' + keepProp.id" class="hand-cursor image-button share-button fa fa-share"></span>
                <span @click="incrementViews" data-toggle="modal" :data-target="'#viewModal' + keepProp.id" class="hand-cursor image-button view-button fa fa-vimeo"></span>
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
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">Add to Vault</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-6">
                                <h4>Available Vaults:</h4>
                                <div class="row">
                                    <div class="col-sm-12" v-for="vault in userVaults">
                                        <div class="row">
                                            <div @click="setCurrentVaultAndKeeps(vault)" class="col-sm-12 height-100 text-center manager-thumb-div">
                                                <span class="manager-title">{{vault.name}}</span>
                                            </div>
                                            <!-- <div class="col-sm-7 height-100 text-center manager-title-div">
                                                        <span class="manager-title">{{vault.description}}</span>
                                                    </div> -->
                                            <!-- <div class="col-sm-2 height-100 text-center manager-controls-div">
                                                <i @click="" class="fa fa-ban manager-controls"></i> -->
                                            <!-- <i class="fa fa-arrow-circle-o-up manager-controls"></i> -->
                                            <!-- </div> -->

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <h4>Keeps in Selected Vault:</h4>
                                <div class="row">
                                    <div class="col-sm-12" v-for="(keep, i) in currentVaultKeeps" v-if="currentVaultKeeps.length > 0">
                                        <div class="row">
                                            <div class="col-sm-2 vault-keep-entry">
                                                <img class=" vault-keep-entry-thumb" :src="keep.imageUrl" :alt="keep.name">
                                            </div>
                                            <div class="vault-keep-entry grey col-sm-10" v-if="i % 2 == 0">
                                                <span>{{keep.name}}</span>
                                            </div>
                                            <div class="vault-keep-entry col-sm-10" v-else>
                                                <span>{{keep.name}}</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <span @click="submitKeepToVault(); incrementKeeps();" type="button" class="hand-cursor btn btn-primary">Keep!</span>
                    </div>
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
        <!-- VIEW MODAL END -->

        <!-- PLEASE LOGIN MODAL -->
        <div class="modal fade" id="pleaseLoginModal" tabindex="-1" role="dialog" aria-labelledby="pleaseLoginModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">Login Required</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12 view-modal-img-div modal-div text-center">
                                <p>You must login to save Keeps</p>
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
        <!-- PLEASE LOGIN MODAL END -->


        <!-- SHARE MODAL -->
        <div class="modal fade" :id="'share-modal' + keepProp.id" tabindex="-1" role="dialog" aria-labelledby="shareModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">Sharing Coming Soon!</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12 view-modal-img-div modal-div text-center">
                                <p>Check back later for this exciting new feature!</p>
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
        <!-- SHARE MODAL END -->




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
            },
            incrementKeeps() {
                this.$store.dispatch('incrementKeeps', { keep: this.keepProp })
            },
            setCurrentVaultAndKeeps(vault) {
                this.$store.dispatch('setCurrentVault', vault)
                this.$store.dispatch('getKeepsInVault', vault.id)
            },
            submitKeepToVault() {
                var vaultKeep = {
                    vaultId: this.currentVault.id,
                    keepId: this.keepProp.id,
                    userId: this.currentUser.id
                }
                this.$store.dispatch('submitKeepToVault', { currentUser: this.currentUser, vaultKeep: vaultKeep, vaultId: this.currentVault.id })
            }
        },
        computed: {
            // keeps() {
            //     return this.$store.state.keeps
            // }
            currentUser() {
                return this.$store.state.currentUser
            },
            userVaults() {
                return this.$store.state.userVaults
            },
            currentVaultKeeps() {
                return this.$store.state.currentVaultKeeps
            },
            currentVault() {
                return this.$store.state.currentVault
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

    .share-button {
        font-size: 1.5em;
        padding: 10px;
        background-color: #000000;
        color: white;
        top: 2%;
        left: 43%;
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

    .manager-thumb-div {
        background-color: #fd0090;
    }

    .manager-title {
        font-size: 2em;
        line-height: 100px;
        color: #ffffff;
    }

    .vault-keep-entry {
        font-size: 1.25em;
        height: 50px;
        line-height: 50px;
    }

    .vault-keep-entry-thumb {
        height: 100%;
    }

    .grey {
        background-color: #F5F5F4;
        color: #000000;
    }
</style>