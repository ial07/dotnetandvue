import { createStore } from 'vuex'
import axios from "axios";

export default createStore({
  state: {
    app: {
      name: "Client With VueJS 3",
    },
    token: null,
  },
  getters: {},
  mutations: {
    setToken(state, token) {
      state.token = token;
    },
  },
  actions: {
    login({ commit }, credentials) {
      return axios
        .post("https://localhost:44361/api/user/login", credentials)
        .then((response) => {
          const token = JSON.stringify(response.data);
          commit("setToken", token);
          localStorage.setItem("token", token);
          return response;
        })
        .catch((error) => {
          alert(error.response.data.title);
        });
    },

    logout() {
      localStorage.removeItem("token");
      window.location.href = "/login";
    },
  },
  modules: {},
});
