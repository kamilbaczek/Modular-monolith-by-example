import axios from "axios";

export const state = {
    todos: [],
};

export const getters = {
    allTodos: state => state.todos,
};

export const mutations = {
    setTodos(state, newValue) {
        state.todos = newValue
    },
};

export const actions = {
    fetchTodos({ commit }) {
        axios.get('https://jsonplaceholder.typicode.com/todos', {}).then(res => {
            commit('setTodos', res.data)
        })
    },
};
