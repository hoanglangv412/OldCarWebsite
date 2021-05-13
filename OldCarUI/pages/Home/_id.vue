<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <TheDetail
      v-if="passPost && passCar && title"
      :passPost="passPost"
      :carName="title"
      :passCar="passCar"
      :contactFlag="contactFlag"
    />
  </div>
</template>
<script>
import TheDetail from "~/components/Home/TheDetail";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "CarCRUD",
  components: {
    Domain,
    TheDetail,
  },
  props: {},
  data() {
    return {
      contactFlag: true,
      domain: Domain,
      passPost: {},
      passCar: {},
      title: null,
      items: [
        {
          text: "Home",
          to: "/Home/Home",
        },
        {
          text: "Chi tiết xe",
          active: true,
        },
      ],
    };
  },
  methods: {
    getPostDetail(value) {
      axios.get(this.domain + "Post/GetDataById/" + value).then((res) => {
        this.passPost = {
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
        axios
          .get(this.domain + "Car/GetNameById/" + res.data[0].Post_car_id)
          .then((res) => {
            var carName =
              res.data[0].Carversion_ManufacturerName.trim() +
              " " +
              res.data[0].Carversion_name.trim() +
              " " +
              res.data[0].Carversion_date.trim();
            this.title = carName;
          });
        axios
          .get(this.domain + "Car/GetDataById/" + res.data[0].Post_car_id)
          .then((res) => {
            this.passCar = res.data[0];
          });
      });
    },
  },
  mounted() {
    if (this.$route.params.id != null) {
      this.getPostDetail(this.$route.params.id);
    }
  },
  // beforeUpdate() {
  //   if (this.$route.params.id != null) {
  //     console.log("ahahhahahaha");
  //     this.getPostDetail(this.$route.params.id);
  //   }
  // },
};
</script>

