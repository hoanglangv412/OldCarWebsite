<template>
  <div class="index">
    <TheCustomerContact :customerContact="customerContact" />
  </div>
</template>

<script>
import TheCustomerContact from "~/components/customer/TheCustomerContact";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Customer",
  components: {
    TheCustomerContact,
    Domain,
  },
  data() {
    return {
      customerContact: {},
      domain: Domain,
    };
  },
  methods: {
    getData() {
      axios
        .get(this.domain + "Customer/GetDataById/" + this.$route.params.id)
        .then((res) => {
          this.customerContact = {
            Customer_id: res.data[0].Customer_id,
            Customer_avatar: res.data[0].Customer_avatar,
            Customer_name: res.data[0].Customer_name,
            Customer_birth: res.data[0].Customer_birth,
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
    },
  },
  mounted() {
    this.getData();
  },
};
</script>

