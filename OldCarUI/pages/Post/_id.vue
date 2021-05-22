<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <TheCreateAndEditPost v-if="postUpdate" :passPost="postUpdate" />
  </div>
</template>
<script>
import TheCreateAndEditPost from "~/components/Post/TheCreateAndEditPost";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "CarCRUD",
  components: {
    Domain,
    TheCreateAndEditPost,
  },
  props: {
    // Carid: {
    //   type: Object,
    //   default: () => [],
    // },
  },
  data() {
    return {
      postUpdate: {},
      domain:Domain,
      items: [
        {
          text: "Post Manager",
          to: "/Post/Post",
        },
        {
          text: "Cập nhật thông tin xe",
          active: true,
        },
      ],
    };
  },
  mounted() {
    if (this.$route.params.id != null) {
      console.log("hahahahahahaha", this.$route.params.id);
      if (this.$route.params.id == "customerFlag") {
        axios.get(this.domain + "Car/Selectlastdata").then((res) => {
          this.postUpdate = {
            Post_id: "",
            Post_customer_id: "",
            Post_car_id: res.data[0].Car_id,
            Post_title: "",
            Post_car_price: "",
            Post_car_origin: "",
            Post_car_incolor: "",
            Post_car_outcolor: "",
            Post_car_tire: "",
            Post_car_plate: "",
            Post_car_province: "",
            Post_car_km: "",
            Post_car_detail: "",
            Post_car_kpl: "",
            Post_car_cond: "",
            Post_car_anothercare: "",
            Post_car_frontpic: "",
            Post_car_replaceditems: "",
            Post_car_date: "",
            Car_camera: "",
            Car_doortype: "",
            Car_mirror: "",
            Car_seattype: "",
            Car_sound: "",
            Car_technology: "",
            Post_car_like: "",
            Post_car_sold: "",
          };
        });
      } else {
        axios
          .get(
            "https://localhost:44343/Api/Post/GetDataById/" +
              this.$route.params.id
          )
          .then((res) => {
            this.postUpdate = {
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
      }
    }
  },
};
</script>

