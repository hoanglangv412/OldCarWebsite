<template>
  <CSidebar fixed :minimize="minimize" :show.sync="show">
    <CSidebarBrand
      :img-full="{
        width: 118,
        height: 46,
        alt: 'Logo',
        src: 'img/brand/coreui-base-white.svg',
      }"
      :img-minimized="{
        width: 118,
        height: 46,
        alt: 'Logo',
        src: 'img/brand/coreui-signet-white.svg',
      }"
      :wrapped-in-link="{ href: 'https://coreui.io/', target: '_blank' }"
    />
    <CRenderFunction flat :content-to-render="navAdmin" v-if="Role == 0" />
    <CRenderFunction
      flat
      :content-to-render="navCustomer"
      v-else-if="Role == 1"
    />
    <CRenderFunction flat :content-to-render="navNormaluser" v-else />
    <CSidebarMinimizer
      class="d-md-down-none"
      @click.native="minimize = !minimize"
    />
  </CSidebar>
</template>

<script>
import navAdmin from "./_navAdmin";
import navNormaluser from "./_navCommonUser";
import navCustomer from "./_navCustomer";

export default {
  name: "TheSidebar",
  data() {
    return {
      minimize: false,
      navAdmin,
      navCustomer,
      navNormaluser,
      show: "responsive",
      Role: null,
    };
  },
  created() {
    console.log("3", this.$auth.$storage.getUniversal("userInfo"));
    this.Role =
      this.$auth.$storage.getUniversal("userInfo") == null
        ? 2
        : this.$auth.$storage.getUniversal("userInfo").Account_role;
    console.log(this.Role);
  },
  mounted() {
    this.$root.$on("toggle-sidebar", () => {
      const sidebarOpened = this.show === true || this.show === "responsive";
      this.show = sidebarOpened ? false : "responsive";
    });
    this.$root.$on("toggle-sidebar-mobile", () => {
      const sidebarClosed = this.show === "responsive" || this.show === false;
      this.show = sidebarClosed ? true : "responsive";
    });
  },
};
</script>
