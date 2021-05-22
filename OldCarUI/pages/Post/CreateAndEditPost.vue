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
  name: "PostCRUD",
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
      items: [
        {
          text: "Quản lí bài đăng",
          to: "/Post/Post",
        },
        {
          text: "Thêm bài đăng mới",
          active: true,
        },
      ],
    };
  },
  mounted() {
    (this.postUpdate = {
      Post_id: "",
      Post_customer_id: "",
      Post_car_id: "",
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
    }),
      (this.infoModal = true),
      (this.ModalTitle = "Thêm xe");
  },
};
</script>

