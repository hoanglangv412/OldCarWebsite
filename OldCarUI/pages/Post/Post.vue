<template>
  <div class="index">
    <CBreadcrumb :items="items" />
    <ThePost :dataPosts="dataPosts" @getPost="getPost" />
  </div>
</template>

<script>
import ThePost from "~/components/Post/ThePost";
import axios from "axios";
import { Domain } from "@/constant/constant";
export default {
  name: "Post",
  components: {
    ThePost,
    Domain,
  },
  data() {
    return {
      auth: false,
      dataPosts: [],
      domain: Domain,
      items: [
        {
          text: "Post Manager",
          active: true,
        },
      ],
    };
  },
  mounted() {
    this.getPost(this.$auth.user);
  },
  methods: {
    getPost(value) {
      axios
        .get(this.domain + "Post/SelectDataByCustomerId/" + value)
        .then((res) => {
          this.dataPosts = res.data;
        });
    },
  },
};
</script>

