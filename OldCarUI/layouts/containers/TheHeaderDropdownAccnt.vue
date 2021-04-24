<template>
  <CDropdown
    in-nav
    class="c-header-nav-items"
    placement="bottom-end"
    add-menu-classes="pt-0"
    v-if="$auth.loggedIn"
  >
    <template #toggler>
      <CHeaderNavLink>
        <div class="c-avatar">
          <img src="@/assets/img/kaikaikiki.jpg" class="c-avatar-img" />
        </div>
      </CHeaderNavLink>
    </template>
    <CDropdownHeader tag="div" class="text-center" color="light">
      <strong>"Tên"</strong>
    </CDropdownHeader>
    <CDropdownItem> <CIcon name="cil-bell" /> Quản lí tài khoản </CDropdownItem>
    <CDropdownItem>
      <CIcon name="cil-envelope-open" /> Quản lí bài đăng
    </CDropdownItem>
    <CDropdownItem class="border-top d-flex justify-content-center">
      <button class="btn btn-outline-danger text-black-100" @click="logOut()">
        Đăng xuất
      </button>
    </CDropdownItem>
  </CDropdown>
  <div v-else>
    <CButton class="btn btn-primary" @click="signinClick('signin')"
      >Đăng nhập</CButton
    >
    <CButton class="btn btn-warning" @click="signupClick('signup')"
      >Đăng kí</CButton
    >
    <!-- Modal signin, signup -->
    <CModal :title="ModalTitle" color="info" size="lg" :show.sync="infoModal">
      <TheSignin
        @closeModal="closeModal"
        :buttonText="this.ModalTitle"
        :submitForm="loginUser"
        :registerFlag="this.registerFlagCheck"
      />
      <div slot="footer" class="w-100 d-none"></div>
    </CModal>
  </div>
</template>

<script>
import TheSignin from "~/components/TheSignin";
export default {
  components: {
    TheSignin,
  },
  name: "TheHeaderDropdownAccnt",
  props: {},
  data() {
    return {
      infoModal: false,
      modalFlag: null,
      ModalTitle: null,
      registerFlagCheck: Boolean,
    };
  },
  // updated() {
  //   this.Session = sessionStorage.getItem("jwt");
  //   console.log(this.Session);
  // },
  // beforeMount() {
  //   this.Session = sessionStorage.getItem("jwt");
  //   console.log(this.Session);
  // },
  methods: {
    loginUser(loginInfo) {
      this.$auth.loginWith("local", { data: loginInfo });
    },
    // logOut() {
    //   sessionStorage.setItem("jwt", "null");
    //   this.Session = sessionStorage.getItem("jwt");
    //   console.log(sessionStorage.getItem("jwt"));
    //   this.$router.go();
    // },
    signinClick(val) {
      (this.modalFlag = val),
        (this.registerFlagCheck = false),
        (this.infoModal = true),
        (this.ModalTitle = "Đăng nhập");
    },
    signupClick(val) {
      (this.modalFlag = val),
        (this.registerFlagCheck = true),
        (this.infoModal = true),
        (this.ModalTitle = "Đăng kí");
    },
    // signupClick(val) {
    //   console.log(this.Session);
    //   (this.modalFlag = val),
    //     (this.infoModal = true),
    //     (this.ModalTitle = "Đăng kí");
    // },
    // closeModal(val) {
    //   sessionStorage.setItem("jwt", "null");
    //   this.infoModal = val;
    //   // this.$emit("getListAccounts");
    // },
  },
};
</script>

<style scoped>
.c-icon {
  margin-right: 0.3rem;
}
</style>
