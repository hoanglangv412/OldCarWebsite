<template>
  <div class="index">
    <TheCustomer :dataCustomers="dataCustomers" @getListCustomers="getData" />
  </div>
</template>

<script>
import TheCustomer from "~/components/customer/TheCustomer";
import axios from "axios";
export default {
  name: "Customer",
  components: {
    TheCustomer,
  },
  data() {
    return {
      dataCustomers: [],
    };
  },
  methods: {
    getData() {
      axios.get("https://localhost:44343/OldCar/Customer/").then((res) => {
        this.dataCustomers = res.data;
      });
    },
  },
  mounted() {
    this.getData();
  },
};
</script>

