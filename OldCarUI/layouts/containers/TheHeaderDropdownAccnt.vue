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
        <div
          class="c-avatar rounded-circle bg-light d-flex justify-content-center"
          style="display: block; height: 40px; width: 40px; position: relative"
        >
          <CImg
            style="position: absolute"
            class="div123"
            :src="
              takePhoto(
                $auth.$storage.getUniversal('userInfo') == null
                  ? ''
                  : $auth.$storage.getUniversal('userInfo').Customer_avatar
              )
            "
          />
          <!-- <img src="@/assets/avatar/kaikaikiki.jpg" class="c-avatar-img" /> -->
        </div>
      </CHeaderNavLink>
    </template>
    <CDropdownHeader tag="div" class="text-center" color="light">
      <strong>{{
        this.$auth.$storage.getUniversal("userInfo") == null
          ? ""
          : this.$auth.$storage.getUniversal("userInfo").Customer_name
      }}</strong>
    </CDropdownHeader>
    <CDropdownItem>
      <CButton
        class="text-black-100 text-center w-100"
        to="/customer/CreateAndEditCustomer"
      >
        Quản lí tài khoản
      </CButton>
    </CDropdownItem>
    <CDropdownItem class="border-top d-flex justify-content-center">
      <button class="btn btn-outline-danger text-black-100" @click="logOut()">
        Đăng xuất
      </button>
    </CDropdownItem>
  </CDropdown>
  <div v-else>
    <CButton class="btn btn-primary p-1" @click="signinClick('signin')"
      >Đăng nhập</CButton
    >
    <CButton class="btn btn-warning p-1" @click="signupClick('signup')"
      >Đăng kí</CButton
    >
    <!-- Modal signin, signup -->
    <CModal :title="ModalTitle" color="info" size="lg" :show.sync="infoModal">
      <TheSignin
        @closeModal="closeModal"
        :buttonText="this.ModalTitle"
        :submitForm="loginUser"
        :registerForm="signinUser"
        :registerFlag="this.registerFlagCheck"
      />
      <div slot="footer" class="w-100 d-none"></div>
    </CModal>
  </div>
</template>
<style scoped>
.div123 {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  box-shadow: 0 0 0 3px #e78267;
}
</style>
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
      // Name: null,
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
      // console.log(loginInfo);
      axios
        .post(
          "https://localhost:44343/api/Customer/CheckExist/" +
            loginInfo.Username +
            "," +
            loginInfo.Password
        )
        .then((res) => {
          if (res.data == false)
            swal.fire({
              position: "center",
              icon: "error",
              title: "Sai tài khoản hoặc mật khẩu",
              showConfirmButton: false,
              timer: 1500,
            });
        });
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
              this.$auth.data = this.customerInfo;
              this.$auth.$storage.setUniversal("userInfo", this.customerInfo);
              // localStorage.setItem("userInfo",this.customerInfo);
              // console.log("hehe",localStorage.getItem("userInfo"));
              // console.log("1", this.$auth.$storage.getUniversal("userInfo"));
              this.closeModal(false);
              this.$router.push("/Home/Home");
            });
          this.$router.go();
        });
    },
    signinUser(value) {
      value.Account_role = 1;
      value.Account_lastLogin = "2020/11/11";
      value.Customer_begindate = "2020/11/11";
      value.Customer_avatar = "123.jpg";
      axios
        .post("https://localhost:44343/api/Customer/Post", value)
        .then((res) => {
          swal.fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          });
          this.closeModal(false);
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
            this.$auth.logout().then((res) => {
              this.$auth.$storage.removeUniversal("userInfo");
              this.$router.go();
            });
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
    closeModal(val) {
      this.infoModal = val;
      // this.$emit("getCarversion");
    },
    takePhoto(value) {
      console.log("hahahahahaha", "@/assets/avatar/" + images);
      if (value) {
        var images;
        try {
          images = require("@/assets/avatar/" + value);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
  },
};
</script>

<style scoped>
.c-icon {
  margin-right: 0.3rem;
}
</style>
