import { userService } from '../../helpers/authservice/user.service';
import router from '../../router/index'

const user = JSON.parse(localStorage.getItem('user'));
export const state = user
    ? { status: { loggeduser: true }, user }
    : { status: {}, user: null };

export const actions = {
    // Logs in the user.
    // eslint-disable-next-line no-unused-vars
    login({ dispatch, commit }, { email, password }) {
        commit('loginRequest', { email });

        userService.login(email, password)
            .then(
                user => {
                    commit('loginSuccess', user);
                    router.push('/');
                },
                error => {
                    commit('loginFailure', error);
                    dispatch('notification/error', error, { root: true });
                }
            );
    },
    // Logout the user
    logout({ commit }) {
        userService.logout();
        commit('logout');
    },
    // register the user
    registeruser({ dispatch, commit }, user) {
        commit('registerRequest', user);
        userService.register(user)
            .then(
                user => {
                    commit('registerSuccess', user);
                    dispatch('notification/success', 'Registration successful', { root: true });

                    router.push('/login');

                },
                error => {
                    commit('registerFailure', error);
                    dispatch('notification/error', error, { root: true });
                }
            );
    }
};

export const mutations = {
    loginRequest(state, user) {
        state.status = { loggingIn: true };
        state.user = user;
    },
    loginSuccess(state, user) {
        state.status = { loggeduser: true };
        state.user = user;
    },
    loginFailure(state) {
        state.status = {};
        state.user = null;
    },
    logout(state) {
        state.status = {};
        state.user = null;
    },
    registerRequest(state) {
        state.status = { registering: true };
    },
    registerSuccess(state) {
        state.status = {};
    },
    registerFailure(state) {
        state.status = {};
    }
};

