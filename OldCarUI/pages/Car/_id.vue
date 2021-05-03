<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <TheCreateAndEditCar
      :passCar="carUpdate"
      :passLength="passLength"
      :passWidth="passWidth"
      :passHeight="passHeight"
    />
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
      passLength: {},
      passWidth: {},
      passHeight: {},
      items: [
        {
          text: "Car Manager",
          to: "/Car/Car",
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
      axios
        .get(
          "https://localhost:44343/Api/Car/GetDataById/" + this.$route.params.id
        )
        .then((res) => {
          this.carUpdate = {
            Car_id: res.data[0].Car_id,
            Car_carversion_id: res.data[0].Car_carversion_id,
            Car_trans: res.data[0].Car_trans,
            Car_fuel: res.data[0].Car_fuel,
            Car_engine: res.data[0].Car_engine,
            Car_seats: res.data[0].Car_seats,
            Car_maxmomen: res.data[0].Car_maxmomen,
            Car_maxspeed: res.data[0].Car_maxspeed,
            Car_maxpower: res.data[0].Car_maxpower,
            Car_loadweight: res.data[0].Car_loadweight,
            Car_doors: res.data[0].Car_doors,
            Car_drivetype: res.data[0].Car_drivetype,
            Car_totaldimens: res.data[0].Car_totaldimens,
            Car_baselength: res.data[0].Car_baselength,
            Car_turnradius: res.data[0].Car_turnradius,
            Car_height: res.data[0].Car_height,
            Car_cylcapacity: res.data[0].Car_cylcapacity,
            Car_brakesystem: res.data[0].Car_brakesystem,
            Car_fuelsystem: res.data[0].Car_fuelsystem,
            Car_airnums: res.data[0].Car_airnums,
            Car_acceleration: res.data[0].Car_acceleration,
            Car_handbrake: res.data[0].Car_handbrake,
            Car_cityfuelconsump: res.data[0].Car_cityfuelconsump,
            Car_highwayfuelconsump: res.data[0].Car_highwayfuelconsump,
          };
          this.passLength = res.data[0].Car_totaldimens.split("x")[0].trim();
          this.passWidth = res.data[0].Car_totaldimens.split("x")[1].trim();
          this.passHeight = res.data[0].Car_totaldimens.split("x")[1].trim();
        });
      (this.infoModal = true), (this.ModalTitle = "Cập nhật xe");
    }
  },
};
</script>

