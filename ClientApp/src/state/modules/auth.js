import { getFirebaseBackend } from '../../authUtils.js'

export const state = {
    currentUser: sessionStorage.getItem('authUser'),
}

export const mutations = {
    SET_CURRENT_USER(state, newValue) {
        state.currentUser = newValue
        saveState('auth.currentUser', newValue)
    },
}

export const getters = {
    // Whether the user is currently logged in.
    loggedIn(state) {
        return !!state.currentUser
    },
}

export const actions = {
    // This is automatically run in `src/state/store.js` when the app
    // starts, along with any other actions named `init` in other modules.
    // eslint-disable-next-line no-unused-vars
    init({ state, dispatch }) {
        dispatch('validate')
    },

    // Logs in the current user.
    logIn({ commit, dispatch, getters }, { email, password } = {}) {
        if (getters.loggedIn) return dispatch('validate')

        return getFirebaseBackend().loginUser(email, password).then((response) => {
            const user = response
            commit('SET_CURRENT_USER', user)
            return user
        });
    },

    // Logs out the current user.
    logOut({ commit }) {
        // eslint-disable-next-line no-unused-vars
        commit('SET_CURRENT_USER', null)
        return new Promise((resolve, reject) => {
            // eslint-disable-next-line no-unused-vars
            getFirebaseBackend().logout().then((response) => {
                resolve(true);
            }).catch((error) => {
                reject(this._handleError(error));
            })
        });
    },

    // register the user
    register({ commit, dispatch, getters }, { email, password } = {}) {
        if (getters.loggedIn) return dispatch('validate')

        return getFirebaseBackend().registerUser(email, password).then((response) => {
            const user = response
            commit('SET_CURRENT_USER', user)
            return user
        });
    },

    // register the user
    // eslint-disable-next-line no-unused-vars
    resetPassword({ commit, dispatch, getters }, { email } = {}) {
        if (getters.loggedIn) return dispatch('validate')

        return getFirebaseBackend().forgetPassword(email).then((response) => {
            const message = response.data
            return message
        });
    },

    // Validates the current user's token and refreshes it
    // with new data from the API.
    // eslint-disable-next-line no-unused-vars
    validate({ commit, state }) {
        if (!state.currentUser) return Promise.resolve(null)
        const user = getFirebaseBackend().getAuthenticatedUser();
        commit('SET_CURRENT_USER', user)
        return user;
    },
}

// ===
// Private helpers
// ===

function saveState(key, state) {
    window.localStorage.setItem(key, JSON.stringify(state))
}
