<template>
  <div class="index">
    <TheCarversion :dataCarversions="dataCarversions" @getCarversion="getCarversion" />
  </div>
</template>

<script>
import TheCarversion from "~/components/Carversion/TheCarversion";
import axios from "axios";
import {Domain} from "@/constant/constant";
export default {
  name: "Carversion",
  components: {
    TheCarversion,
    Domain
  },
  data() {
    return {
      auth:false,
      dataCarversions: [],
      domain:Domain
    };
  },
  mounted() {
    this.getCarversion();
  },
  methods: {
    getCarversion() {
       axios.get(this.domain + "Carversion/").then((res) => {
          this.dataCarversions = res.data;
        });
    },
  }
};
</script>

