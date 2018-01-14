import Axios from 'axios'
import Vue from 'vue'
import Vuex from 'vuex'
import router from '../router'

let auth = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/accounts/' : '/accounts/',
    timeout: 2000,
    withCredentials: true
})

let api = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/api/' : '/api/',
    timeout: 2000,
    withCredentials: true
})

Vue.use(Vuex)

var store = new Vuex.Store({
    state: {
        error: {},
        message: "",
        currentUser: {},
        keeps: [],
        userKeeps: [],
        userVaults: []
    },
    mutations: {

        handleError(state, err) {
            state.error = err
        },
        setCurrentUser(state, user) {
            state.currentUser = user
            // console.log(state.user)
        },
        setMessage(state, msg) {
            state.message = msg
        },
        setKeeps(state, keeps) {
            state.keeps = keeps
        },
        setUserKeeps(state, keeps) {
            state.userKeeps = keeps
        },
        setUserVaults(state, vaults) {
            state.userVaults = vaults
        }

    },
    actions: {

        //#region UserAuth

        submitRegister({ commit, dispatch }, newUser) {
            account.post('register', newUser)
                .then(res => {
                    if (res.data) {
                        commit('setCurrentUser', res.data)
                        // router.push({ name: "Home" })
                    } else {
                        // router.push({ name: "Login" })
                        //Line below might need to be res or err (Check after frontend auth ready)
                        commit('handleError', { message: 'Authentication failed!' })
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitLogin({ commit, dispatch }, user) {
            account.post('login', user)
                .then(res => {
                    if (res.data) {
                        commit('setCurrentUser', res.data)
                        // router.push({ name: "Home" })
                    } else {
                        // router.push({ name: "Login" })
                        //Line below might need to be res or err (Check after frontend auth ready)
                        commit('handleError', { message: 'Authentication failed!' })
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        logout({ commit, dispatch }) {
            account.delete('logout')
                .then(res => {
                    commit('setCurrentUser', {})
                    // router.push({ name: "Login" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        authenticate({ commit, dispatch }) {
            account('authenticate')
                .then(res => {
                    // console.log("Response @ auth: ", res.data)
                    if (res.data) {
                        commit('setCurrentUser', res.data)
                        // router.push({ name: "Home" })
                    } else {
                        // router.push({ name: "Login" })
                        //Line below might need to be res or err (Check after frontend auth ready)
                        commit('handleError', { message: 'Authentication failed!' })
                    }
                })
                .catch(() => {
                    commit('handleError', err)
                })
        },

        //#endregion

        //#region Vault Functions

        getUserVaults({ commit, dispatch }, currentUserId) {
            api(`vaults/${currentUserId}`)
                .then(res => {
                    console.log(res)
                    commit('setUserVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitVault({ commit, dispatch }, payload) {
            payload.vault.userId = payload.currentUser.id
            console.log(payload.vault)
            api.post('vaults', payload.vault)
                .then(res => {
                    if (res) {
                        //res = whole posting or res.data = whole posting?
                        commit('setMessage', `New Vault: ${payload.vault.name} posted successfully`)
                    } else {
                        commit('setMessage', `New Vault: ${payload.vault.name} Did NOT post successfully`)
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
                .then(res => {
                    dispatch('getUserVaults', payload.currentUser.id)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        updateVault({ commit, dispatch }, payload) {
            if (payload.currentUser.id == payload.vault.userId) {
                api.put(`vaults/${payload.vault.id}`)
                    .then(res => {
                        if (res) {
                            commit('setMessage', `Vault: ${payload.vault.name} updated successfully`)
                            return res
                        } else {
                            commit('setMessage', `Vault: ${payload.vault.name} was not updated successfully`)
                            return res
                        }
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
                    .then(res => {
                        dispatch('getUserVaults', payload.currentUser.id)
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
            } else {
                commit('handleError', { message: 'You are not the owner of that vault, and therefore not authorized to update it.' })
            }
        },
        removeVault({ commit, dispatch }, payload) {
            if (payload.currentUser.id == payload.vault.userId) {
                api.delete(`vaults/${payload.vault.id}`)
                    .then(res => {
                        if (res) {
                            commit('setMessage', `Vault: ${payload.vault.name} removed successfully`)
                            return res
                        } else {
                            commit('setMessage', `Vault: ${payload.vault.name} was not removed successfully`)
                            return res
                        }
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
                    .then(res => {
                        dispatch('getUserVaults', payload.currentUser.id)
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
            } else {
                commit('handleError', { message: 'You are not the owner of that vault, and therefore not authorized to remove it.' })
            }
        },

        //#endregion

        //#region Keep Functions

        getKeeps({ commit, dispatch }) {
            api(`keeps`)
                .then(res => {
                    console.log(res)
                    commit('setKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getUserKeeps({ commit, dispatch }, currentUserId) {
            api(`keeps/${currentUserId}`)
                .then(res => {
                    console.log(res)
                    commit('setUserKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitKeep({ commit, dispatch }, payload) {
            payload.keep.userId = payload.currentUser.id
            console.log(payload.keep)
            api.post('keeps', payload.vault)
                .then(res => {
                    if (res) {
                        //res = whole posting or res.data = whole posting?
                        commit('setMessage', `New Keep: ${payload.keep.name} posted successfully`)
                    } else {
                        commit('setMessage', `New Keep: ${payload.keep.name} Did NOT post successfully`)
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
                .then(res => {
                    dispatch('getKeeps')
                    dispatch('getUserKeeps', payload.currentUser.id)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        updateKeep({ commit, dispatch }, payload) {
            if (payload.currentUser.id == payload.keep.userId) {
                api.put(`keeps/${payload.keep.id}`)
                    .then(res => {
                        if (res) {
                            commit('setMessage', `Keep: ${payload.keep.name} updated successfully`)
                            return res
                        } else {
                            commit('setMessage', `Keep: ${payload.keep.name} was not updated successfully`)
                            return res
                        }
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
                    .then(res => {
                        dispatch('getKeeps')
                        dispatch('getUserKeeps', payload.currentUser.id)
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
            } else {
                commit('handleError', { message: 'You are not the owner of that keep, and therefore not authorized to update it.' })
            }
        },
        removeKeep({ commit, dispatch }, payload) {
            if (payload.currentUser.id == payload.keep.userId) {
                api.delete(`keeps/${payload.keep.id}`)
                    .then(res => {
                        if (res) {
                            commit('setMessage', `Keep: ${payload.keep.name} removed successfully`)
                            return res
                        } else {
                            commit('setMessage', `Keep: ${payload.keep.name} was not removed successfully`)
                            return res
                        }
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
                    .then(res => {
                        dispatch('getKeeps')
                        dispatch('getUserKeeps', payload.currentUser.id)
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
            } else {
                commit('handleError', { message: 'You are not the owner of that keep, and therefore not authorized to remove it.' })
            }
        },

        //#endregion

    }
})

export default store