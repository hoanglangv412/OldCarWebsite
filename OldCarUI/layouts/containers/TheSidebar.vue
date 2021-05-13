<template>
  <CSidebar
    fixed
    :minimize="minimize"
    :show.sync="show"
    style="background-color: #303c54"
  >
    <CSidebarBrand>
      <CButton to="/Home/Home">
        <img src="@/assets/img/logobrand.jpg" class="c-avatar-img" />
      </CButton>
    </CSidebarBrand>
    <CRenderFunction
      style="background-color: #263047"
      flat
      :content-to-render="navAdmin"
      v-if="Role == 0 && this.$auth.loggedIn"
    />
    <CRenderFunction
      style="background-color: #263047"
      flat
      :content-to-render="navCustomer"
      v-else-if="Role == 1 && this.$auth.loggedIn"
    />
    <CRenderFunction
      flat
      :content-to-render="navNormaluser"
      style="background-color: #263047"
      v-else
    />
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
