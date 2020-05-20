import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    cars: []
  },
  mutations: {
    setCars(state, cars) {
      state.cars = cars
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async createCar({ commit, dispatch }, newCar) {
      let res = await api.post("cars", newCar)
      dispatch("getCars")
    },
    async getCars({ commit, dispatch }) {
      try {
        let res = await api.get("cars")
        commit("setCars", res.data)
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
    async deleteCar({ dispatch }, carId) {
      try {
        await api.delete("cars/" + carId)
        dispatch("getCars")
      } catch (error) {
        debugger
        alert(JSON.stringify(error.response.data));
      }

    }

  }
});
