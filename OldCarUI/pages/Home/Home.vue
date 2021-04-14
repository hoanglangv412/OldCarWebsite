<template>
  <div class="index">
    <TheHome/>
  </div>
</template>

<script>
import TheHome from "~/components/Home/TheHome";
import axios from "axios";
export default {
  name: "Home",
  components: {
    TheHome,
  },
};
</script>

