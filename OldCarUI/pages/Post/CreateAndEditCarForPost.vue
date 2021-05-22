<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <TheCreateAndEditCarForPost
      v-if="carversionUpdate && carUpdate"
      :passCarverion="carversionUpdate"
      :passCar="carUpdate" 
      :accountname_valid="null"
      :accountpassword_valid="null"
    />
  </div>
</template>
<script>
import TheCreateAndEditCarForPost from "~/components/Post/TheCreateAndEditCarForPost";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "PostCRUD",
  components: {
    Domain,
    TheCreateAndEditCarForPost,
  },
  props: {
    // Carid: {
    //   type: Object,
    //   default: () => [],
    // },
  },
  data() {
    return {
      carversionUpdate: {},
      carUpdate: {},
      items: [
        {
          text: "Quản lí bài đăng",
          to: "/Post/Post",
        },
        {
          text: "Tạo bài đăng mới",
          active: true,
        },
      ],
    };
  },
  mounted() {
    this.carversionUpdate = {
      Carversion_id: 0,
      Carversion_name: "",
      Carversion_date: "",
      Carversion_style: "",
      Carversion_edition: "",
      Carversion_option: "",
      Carversion_ManufacturerName: "",
      Carversion_ManufacturerLogo: "",
    };
    this.carUpdate = {
      Car_id: 0,
      Car_carversion_id: "",
      Car_trans: "",
      Car_fuel: "",
      Car_engine: "",
      Car_seats: "",
      Car_maxmomen: "",
      Car_maxspeed: "",
      Car_maxpower: "",
      Car_loadweight: "",
      Car_doors: "",
      Car_drivetype: "",
      Car_totaldimens: "",
      Car_baselength: "",
      Car_turnradius: "",
      Car_height: "",
      Car_cylcapacity: "",
      Car_brakesystem: "",
      Car_fuelsystem: "",
      Car_airnums: "",
    };
  },
};
</script>

