<template>
  <div class="index">
    <TheHomeCarForPost :dataCars="dataCars" @getCar="getCar" />
  </div>
</template>

<script>
import TheHomeCarForPost from "~/components/Home/TheHomeCarForPost";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Home",
  components: {
    TheHomeCarForPost,
    Domain,
  },
  data() {
    return {
      auth: false,
      dataCars: [],
      domain: Domain,
      searchFlag: true,
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

