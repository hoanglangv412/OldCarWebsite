<template>
  <div class="index">
    <TheReport
      :dataPosts="dataPosts"
      :dataPostCustomers="dataPostCustomers"
      :dataCustomers="dataCustomers"
      :soldCount="soldCount"
      :unsoldCount="unsoldCount"
      :mostLikeItem="mostLikeItem"
      :role="role"
    />
  </div>
</template>

<script>
import TheReport from "~/components/Report/TheReport";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Carversion",
  components: {
    TheReport,
    Domain,
  },
  data() {
    return {
      auth: false,
      dataPostCustomers: [],
      dataPosts: [],
      domain: Domain,
      dataCustomers: [],
      soldCount: null,
      unsoldCount: null,
      mostLikeItem: {},
      id: null,
      role: null,
    };
  },
  mounted() {
    this.id =
      this.$auth.$storage.getUniversal("userInfo") == null
        ? 2
        : this.$auth.$storage.getUniversal("userInfo").Customer_id;
    this.role =
      this.$auth.$storage.getUniversal("userInfo") == null
        ? 2
        : this.$auth.$storage.getUniversal("userInfo").Account_role;
    this.getData();
    this.getCarversion();
    this.SelectMostLike();
    this.getPost(this.id);
  },
  methods: {
    getCarversion() {
      axios.get(this.domain + "Post/Get").then((res) => {
        this.dataPosts = res.data;
      });
    },
    getData() {
      axios.get(this.domain + "Customer/Get").then((res) => {
        this.dataCustomers = res.data;
      });
    },
    getPost(value) {
      axios
        .get(this.domain + "Post/SelectDataByCustomerId/" + value)
        .then((res) => {
          this.dataPostCustomers = res.data;
        });
    },
    SelectMostLike() {
      axios.get(this.domain + "Post/SelectMostLike").then((res) => {
        this.mostLikeItem = {
          Post_id: res.data[0].Post_id,
          Post_customer_id: res.data[0].Post_customer_id,
          Post_car_id: res.data[0].Post_car_id,
          Post_title: res.data[0].Post_title,
          Post_car_price: res.data[0].Post_car_price,
          Post_car_origin: res.data[0].Post_car_origin,
          Post_car_incolor: res.data[0].Post_car_incolor,
          Post_car_outcolor: res.data[0].Post_car_outcolor,
          Post_car_tire: res.data[0].Post_car_tire,
          Post_car_plate: res.data[0].Post_car_plate,
          Post_car_province: res.data[0].Post_car_province,
          Post_car_km: res.data[0].Post_car_km,
          Post_car_detail: res.data[0].Post_car_detail,
          Post_car_kpl: res.data[0].Post_car_kpl,
          Post_car_cond: res.data[0].Post_car_cond,
          Post_car_anothercare: res.data[0].Post_car_anothercare,
          Post_car_frontpic: res.data[0].Post_car_frontpic,
          Post_car_replaceditems: res.data[0].Post_car_replaceditems,
          Post_car_date: res.data[0].Post_car_date,
          Car_camera: res.data[0].Car_camera,
          Car_doortype: res.data[0].Car_doortype,
          Car_mirror: res.data[0].Car_mirror,
          Car_seattype: res.data[0].Car_seattype,
          Car_sound: res.data[0].Car_sound,
          Car_technology: res.data[0].Car_technology,
          Post_car_like: res.data[0].Post_car_like,
          Post_car_sold: res.data[0].Post_car_sold,
        };
      });
    },
  },
};
</script>

