<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <Car :dataCars="dataCars" @getCar="getCar" />
  </div>
</template>

<script>
import Car from "~/components/Car/TheCar";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Carversion",
  components: {
    Car,
    Domain,
  },
  data() {
    return {
      auth: false,
      dataCars: [],
      domain: Domain,
      items: [
        {
          text: "Quản lí xe",
          active:true
        },
      ],
    };
  },
  mounted() {
    this.getCar();
  },
  methods: {
    getCar() {
      axios.get(this.domain + "Car/Get").then((res) => {
        this.dataCars = res.data;
      });
    },
  },
};
</script>

