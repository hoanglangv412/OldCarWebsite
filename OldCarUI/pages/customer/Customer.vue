<template>
  <div class="index">
    <TheCustomer :dataCustomers="dataCustomers" @getListCustomers="getData" />
  </div>
</template>

<script>
import TheCustomer from "~/components/customer/TheCustomer";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Customer",
  components: {
    TheCustomer,
    Domain,
  },
  data() {
    return {
      dataCustomers: [],
      domain: Domain,
    };
  },
  methods: {
    getData() {
      axios.get(this.domain + "Customer/Get").then((res) => {
        this.dataCustomers = res.data;
      });
    },
  },
  mounted() {
    this.getData();
  },
};
</script>

