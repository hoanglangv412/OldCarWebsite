<template>
  <div class="index">
    <TheHome :dataPosts="dataPosts" @getPost="getPost" />
  </div>
</template>

<script>
import TheHome from "~/components/Home/TheHome";
import axios from "axios";
import {Domain} from "@/constant/constant";
export default {
  name: "Home",
  components: {
    TheHome,
    Domain
  },
  data() {
    return {
      auth:false,
      dataPosts: [],
      domain:Domain
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
    },
  }
};
</script>

