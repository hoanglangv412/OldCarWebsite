<template>
  <div class="index">
    <TheCreateEditCustomer :customerData="customerData" @getdata="getData" />
  </div>
</template>

<script>
import TheCreateEditCustomer from "~/components/customer/TheCreateEditCustomer";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Customer",
  components: {
    TheCreateEditCustomer,
    Domain,
  },
  data() {
    return {
      customerData: {},
      domain: Domain,
    };
  },
  methods: {
    getData() {
      if (this.$auth.$storage.getUniversal("userInfo") != null) {
        axios
          .get(
            this.domain +
              "Customer/GetDataById/" +
              this.$auth.$storage.getUniversal("userInfo").Customer_id
          )
          .then((res) => {
            this.customerData = {
              Customer_id: res.data[0].Customer_id,
              Customer_avatar: res.data[0].Customer_avatar,
              Customer_name: res.data[0].Customer_name,
              Customer_birth: res.data[0].Customer_birth.split("T")[0],
              Customer_email: res.data[0].Customer_email,
              Customer_address: res.data[0].Customer_address,
              Customer_phone: res.data[0].Customer_phone,
              Customer_begindate: res.data[0].Customer_begindate,
              Account_name: res.data[0].Account_name,
              Account_password: res.data[0].Account_password,
              Account_role: res.data[0].Account_role,
              Account_lastLogin: res.data[0].Account_lastLogin,
            };
          });
      }
    },
  },
  mounted() {
    this.getData();
  },
};
</script>

