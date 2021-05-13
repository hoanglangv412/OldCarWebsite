<template>
  <div class="index">
    <TheHome
      :dataPosts="dataPosts"
      :searchFlag="searchFlag"
      :dataPostSorts="dataPostSorts"
    />
  </div>
</template>
<script>
import TheHome from "~/components/Home/TheHome";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "CarCRUD",
  components: {
    Domain,
    TheHome,
  },
  props: {
    // Carid: {
    //   type: Object,
    //   default: () => [],
    // },
  },
  data() {
    return {
      domain: Domain,
      dataPosts: [],
      dataPostSorts: [],
      searchFlag: false,
    };
  },
  mounted() {
    if (this.$route.params.id != null) {
      axios
        .get(
          "https://localhost:44343/Api/Carversion/SelectDataByManufacturerName/" +
            this.$route.params.id
        )
        .then((res) => {
          this.dataPosts = res.data;
          axios
            .get(this.domain + "Post/Selectalldatasortbydate")
            .then((res) => {
              this.dataPostSorts = res.data;
            });
        });
    }
  },
};
</script>

