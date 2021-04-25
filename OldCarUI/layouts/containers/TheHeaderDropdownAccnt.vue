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
import axios from "axios";
import swal from "sweetalert2";
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
      customerInfo: {},
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
      this.$auth
        .loginWith("local", {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
            "Cache-Control": "no-cache",
          },
          withCredentials: true,
          crossDomain: true,
          data: $.param(loginInfo),
        })
        .then((res) => {
          axios
            .get(
              "https://localhost:44343/Api/Customer/GetDataById/" +
                this.$auth.user
            )
            .then((res) => {
              this.customerInfo = {
                Customer_id: res.data[0].Customer_id,
                Customer_avatar: res.data[0].Customer_avatar,
                Customer_name: res.data[0].Customer_name,
                Customer_birth: res.data[0].Customer_birth,
                Customer_email: res.data[0].Customer_email,
                Customer_address: res.data[0].Customer_address,
                Customer_phone: res.data[0].Customer_phone,
                Customer_begindate: res.data[0].Customer_begindate,
                Account_name: res.data[0].Account_name,
                Account_password: res.data[0].Account_password,
                Account_role: res.data[0].Account_role,
                Account_lastLogin: res.data[0].Account_lastLogin,
              };
              this.$auth.$storage.setUniversal("userInfo", this.customerInfo);
              this.$router.go();
            });
        });
    },
    logOut() {
      swal
        .fire({
          title: "Bạn muốn đăng xuất tài khoản này?",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Xác nhận",
          cancelButtonText: "Không",
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.$auth.$storage.removeUniversal("userInfo");
            this.$auth.logout();
            this.$router.go();
          }
        });
    },
    signinClick(val) {
      console.log(
        this.$auth.$storage.getUniversal("userInfo", this.customerInfo)
      );
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
    closeModal(val) {},
  },
};
</script>

<style scoped>
.c-icon {
  margin-right: 0.3rem;
}
</style>
