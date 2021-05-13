<template>
  <div class="index">
    <TheHome
      :dataPosts="dataPosts"
      :dataPostSorts="dataPostSorts"
      @getPost="getPost"
      :searchFlag="searchFlag"
    />
  </div>
</template>

<script>
import TheHome from "~/components/Home/TheHome";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Home",
  components: {
    TheHome,
    Domain,
  },
  data() {
    return {
      auth: false,
      dataPostSorts: [],
      dataPosts: [],
      domain: Domain,
      searchFlag: true,
    };
  },
  mounted() {
    this.getPost();
  },
  methods: {
    getPost() {
      axios.get(this.domain + "Post/Get").then((res) => {
        this.dataPosts = res.data;
        console.log($appName);
      });
      axios.get(this.domain + "Post/Selectalldatasortbydate").then((res) => {
        console.log('hhiihihihihih', this.dataPostSorts);
        this.dataPostSorts = res.data;
        console.log($appName);
      });
    },
  },
};
</script>

