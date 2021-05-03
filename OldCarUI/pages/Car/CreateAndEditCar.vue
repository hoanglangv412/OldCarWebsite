<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <TheCreateAndEditCar :passCar="carUpdate" />
  </div>
</template>
<script>
import TheCreateAndEditCar from "~/components/Car/TheCreateAndEditCar";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "CarCRUD",
  components: {
    Domain,
    TheCreateAndEditCar,
  },
  props: {
    // Carid: {
    //   type: Object,
    //   default: () => [],
    // },
  },
  data() {
    return {
      carUpdate: {},
      items: [
        {
          text: "Car Manager",
          to: "/Car/Car",
        },
        {
          text: "Thêm xe mới",
          active: true,
        },
      ],
    };
  },
  mounted() {
    (this.carUpdate = {
      Car_id: "",
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
    }),
      (this.infoModal = true),
      (this.ModalTitle = "Thêm xe");
  },
};
</script>

