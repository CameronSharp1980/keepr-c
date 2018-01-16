<template>
    <div class="dashboard">
        <div class="row">
            <div class="col-sm-12">
                <div class="dash-message-bar">
                    <span>Hello {{currentUser.firstName}} {{currentUser.lastName}}, Here you may post your own keeps, manage your
                        vaults, and be awesome!</span>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading dash-heading">
                        <span>My Dashboard</span>
                        <div class="dash-buttons pull-right">
                            <span @click="makeVaultKeep('keep')" class="active-button dash-button fa fa-xing" v-if="makingKeep"></span>
                            <span @click="makeVaultKeep('keep')" class="dash-button fa fa-xing" v-else></span>
                            <span @click="makeVaultKeep('vault')" class="active-button dash-button fa fa-vimeo" v-if="makingVault"></span>
                            <span @click="makeVaultKeep('vault')" class="dash-button fa fa-vimeo" v-else></span>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="submit-form" v-if="makingKeep">
                            <h3>Create New Keep</h3>
                            <form class="form" @submit.prevent="submitKeep">
                                <div class="form-group">
                                    <input class="form-control" type="text" name="name" placeholder="Name" v-model='makeKeep.name' required>
                                </div>
                                <div class="form-group">
                                    <input class="form-control" type="" name="description" placeholder="Description" v-model='makeKeep.description' required>
                                </div>
                                <div class="form-group">
                                    <input class="form-control" type="url" name="imageurl" placeholder="Image URL" v-model='makeKeep.imageUrl' required>
                                </div>
                                <div class="form-group">
                                    <label for="public">Mark as Public?</label>
                                    <input type="checkbox" name="public" v-model='makeKeep.public'>
                                </div>
                                <div class="form-group">
                                    <button type="submit" class="pink-button wide-button pull-left">Create Keep</button>
                                    <button class="grey-button center-button pull-left" data-toggle="modal" data-target="#keepManageModal">Manage Keeps</button>
                                    <button @click="resetForms" class="purple-button wide-button pull-right">Reset</button>
                                </div>
                            </form>
                        </div>
                        <div class="submit-form" v-if="makingVault">
                            <h3>Create New Vault</h3>
                            <form class="form" @submit.prevent="submitVault">
                                <div class="form-group">
                                    <input class="form-control" type="text" name="name" placeholder="Name" v-model='makeVault.name' required>
                                </div>
                                <div class="form-group">
                                    <input class="form-control" type="" name="description" placeholder="Description" v-model='makeVault.description' required>
                                </div>
                                <div class="form-group">
                                    <button type="submit" class="pink-button wide-button pull-left">Create Vault</button>
                                    <button class="grey-button center-button pull-left" data-toggle="modal" data-target="#vaultManageModal">Manage Vaults</button>
                                    <button @click="resetForms" class="purple-button wide-button pull-right">Reset</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- VAULT MANAGEMENT MODAL -->
        <div class="modal fade" id="vaultManageModal" tabindex="-1" role="dialog" aria-labelledby="vaultManageModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">Vault Manager</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12" v-for="vault in userVaults">
                                <div class="row">
                                    <div class="col-sm-10 height-100 text-center manager-thumb-div">
                                        <span class="manager-title">{{vault.name}}</span>
                                    </div>
                                    <!-- <div class="col-sm-7 height-100 text-center manager-title-div">
                                        <span class="manager-title">{{vault.description}}</span>
                                    </div> -->
                                    <div class="col-sm-2 height-100 text-center manager-controls-div">
                                        <i @click="removeVault(vault)" class="fa fa-ban manager-controls"></i>
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
        <!-- VAULT MANAGEMENT MODAL END -->


        <!-- KEEP MANAGEMENT MODAL -->
        <div class="modal fade" id="keepManageModal" tabindex="-1" role="dialog" aria-labelledby="keepManageModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">Keep Manager</h4>
                    </div>
                    <div class="modal-body max-height-80vh">
                        <div class="row">
                            <div class="col-sm-12" v-for="keep in userKeeps">
                                <div class="row">
                                    <div class="col-sm-3 height-100 text-center manager-thumb-div">
                                        <img class="manager-thumb" :src="keep.imageUrl" :alt="keep.name">
                                    </div>
                                    <div class="col-sm-7 height-100 text-center manager-title-div">
                                        <span class="manager-title">{{keep.name}}</span>
                                    </div>
                                    <div class="col-sm-2 height-100 text-center manager-controls-div">
                                        <i @click="removeKeep(keep)" class="fa fa-ban manager-controls"></i>
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
        <!-- KEEP MANAGEMENT MODAL END -->









    </div>
</template>

<script>
    export default {
        name: 'Dashboard',
        data() {
            return {
                makingVault: false,
                makingKeep: true,
                makeKeep: {
                    userId: 0,
                    name: '',
                    description: '',
                    imageUrl: '',
                    views: 0,
                    keeps: 0,
                    shares: 0,
                    public: false
                },
                makeVault: {
                    userId: 0,
                    name: '',
                    description: ''
                }
            }
        },
        mounted() {
            this.$store.dispatch('authenticate')
        },
        methods: {
            resetForms() {
                this.makeKeep = {
                    userId: 0,
                    name: '',
                    description: '',
                    imageUrl: '',
                    views: 0,
                    keeps: 0,
                    shares: 0,
                    public: false
                },
                    this.makeVault = {
                        userId: 0,
                        name: '',
                        description: ''
                    }
            },
            makeVaultKeep(vaultOrKeep) {
                if (vaultOrKeep == "keep") {
                    this.makingVault = false
                    this.makingKeep = true
                } else if (vaultOrKeep == "vault") {
                    this.makingVault = true
                    this.makingKeep = false
                }
            },
            submitKeep() {
                this.makeKeep.userId = this.currentUser.id
                this.$store.dispatch('submitKeep', { currentUser: this.currentUser, keep: this.makeKeep })
                this.resetForms()
            },
            removeKeep(keep) {
                this.$store.dispatch('removeKeep', { currentUser: this.currentUser, keep: keep })
            },
            submitVault() {
                this.makeVault.userId = this.currentUser.id
                this.$store.dispatch('submitVault', { currentUser: this.currentUser, vault: this.makeVault })
                this.resetForms()
            },
            removeVault(vault) {
                this.$store.dispatch('removeVault', { currentUser: this.currentUser, vault: vault })
            }
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
            }
        },
        components: {
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .dash-message-bar {
        margin: auto;
        background-color: #9854bb;
        color: #ffffff;
        font-size: 1.25em;
        padding: .75em;
        margin-bottom: 20px;
    }

    .dash-heading {
        font-size: 2.5em;
        color: #52525c
    }

    .dash-button {
        font-size: .5em;
        background-color: #fd0090;
        color: #ffffff;
        padding: 10px;
        outline: 2px solid #fd0090;
    }

    .active-button {
        outline: 2px solid #9854bb;
    }

    .pink-button {
        background-color: #fd0090;
        outline: 1px solid #fd0090;
        border: none;
        color: #ffffff;
        padding: 5px 10px 5px 10px;
    }

    .purple-button {
        background-color: #9854bb;
        outline: 1px solid #9854bb;
        border: none;
        color: #ffffff;
        padding: 5px 10px 5px 10px;
    }

    .grey-button {
        background-color: #F5F5F4;
        outline: 1px solid #F5F5F4;
        border: none;
        color: #000000;
        padding: 5px 10px 5px 10px;
    }

    .wide-button {
        width: 33%;
        height: 40px;
    }

    .center-button {
        width: 34%;
        height: 40px;
    }

    .submit-form {
        width: 75%;
        margin: auto;
    }

    .panel {
        border-radius: 0;
    }

    .manager-thumb-div {
        background-color: #fd0090;
    }

    .manager-thumb {
        height: 85%;
        /* margin: auto; */
    }

    .manager-title-div {
        background-color: #9854bb;
    }

    .manager-title {
        font-size: 2em;
        line-height: 100px;
        color: #ffffff;
    }

    .manager-controls-div {
        background-color: #F5F5F4;
    }

    .manager-controls {
        font-size: 2em;
        line-height: 100px;
        color: #000000;
    }

    .height-100 {
        height: 100px;
    }

    .max-height-80vh {
        max-height: 80vh;
        overflow: auto;
    }
</style>