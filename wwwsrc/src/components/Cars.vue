<template>
  <div class="Cars">
    <form @submit.prevent="createCar()">
      <div class="form-group">
        <label for="make">Make</label>
        <input
          type="text"
          name="make"
          class="form-control"
          placeholder="Enter make...."
          v-model="newCar.make"
        />
      </div>
      <div class="form-group">
        <label for="model">Model</label>
        <input
          type="text"
          name="model"
          class="form-control"
          placeholder="Enter model...."
          v-model="newCar.model"
        />
      </div>
      <div class="form-group">
        <label for="year">year</label>
        <input
          type="number"
          name="year"
          class="form-control"
          placeholder="Enter year...."
          v-model="newCar.productionYear"
        />
      </div>
      <div class="form-group">
        <label for="price">price</label>
        <input
          type="number"
          name="price"
          class="form-control"
          placeholder="Enter price...."
          v-model="newCar.price"
        />
      </div>
      <div class="form-group">
        <label for="imgUrl">imgUrl</label>
        <input
          type="text"
          name="imgUrl"
          class="form-control"
          placeholder="Enter imgUrl...."
          v-model="newCar.imgUrl"
        />
      </div>
      <div class="form-group">
        <label for="body">body</label>
        <input
          type="text"
          name="body"
          class="form-control"
          placeholder="Enter body...."
          v-model="newCar.body"
        />
      </div>
      <button type="submit" class="btn btn-primary">Add Car</button>
    </form>
    <div class="row justify-content-center">
      <div class="col-3 m-3 border rounded" v-for="car in cars" :key="car.id">
        <h1>{{car.make}}</h1>
        <h2>{{car.model}}</h2>
        <img :src="car.imgUrl" class="img-fluid" alt srcset />
        <h2>{{car.price}}</h2>
        <h2>{{car.year}}</h2>
        <h2>{{car.body}}</h2>
        <button class="btn btn-danger btn-block" @click="deleteCar(car.id)">Delete</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Cars",
  data() {
    return {
      newCar: {}
    };
  },
  mounted() {
    this.$store.dispatch("getCars");
  },
  computed: {
    cars() {
      return this.$store.state.cars;
    }
  },
  methods: {
    createCar() {
      this.newCar.productionYear = +this.newCar.productionYear;
      this.newCar.price = +this.newCar.price;
      this.$store.dispatch("createCar", this.newCar);
    },
    deleteCar(carId) {
      this.$store.dispatch("deleteCar", carId);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>