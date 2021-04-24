<template>
  <div>
    <CRow>
      <CCol md="8">
        <CForm class="form-insert-update">
          <CCardBody>
            <CInput
              @keydown.space.prevent
              type="text"
              placeholder="Tài khoản"
              label="Tên tài khoản"
              horizontal
              v-model.trim="userInfo.Account_name"
            />
            <CInput
              @keydown.space.prevent
              type="password"
              label="Mật khẩu"
              placeholder="Mật khẩu"
              horizontal
              v-model.trim="userInfo.Account_password"
            />
          </CCardBody>
          <CCardFooter class="text-center">
            <CButton color="info" @click="submitForm(userInfo)"> {{buttonText}} </CButton>
          </CCardFooter>
        </CForm>
      </CCol>
      <CCol md="4">
        <div class="h-75 w-75">
          <img src="@/assets/img/kaikaikiki.jpg" class="c-avatar-img" />
        </div>
      </CCol>
    </CRow>
  </div>
</template>

<script>
import axios from "axios";
import swal from "sweetalert2";
export default {
  name: "TheSignup",
  props: ["submitForm","buttonText"],
  data() {
    return {
      userInfo: {
        Account_name: "",
        Account_password: "",
      },
      selected: [], // Must be an array reference!
      show: true,
      horizontal: { label: "col-3", input: "col-9" },
      radioOptions: ["Admin", "Người dùng"],
    };
  },
  methods: {
    // insertClick() {
    //   axios
    //     .get(
    //       "https://localhost:44343/OldCar/Customer/CheckExistAccount/" +
    //         this.account.Account_name +
    //         "/" +
    //         this.account.Account_password
    //     )
    //     .then((res) => {
    //       if (res.data[0]) {
    //         sessionStorage.setItem("jwt", res.data[0].Account_role);
    //         // console.log(sessionStorage.getItem('jwt'));
    //         swal.fire({
    //           position: "center",
    //           icon: "success",
    //           title: "Đăng nhập thành công",
    //           showConfirmButton: false,
    //           timer: 1500,
    //         });
    //         this.$emit("closeModal", false);
    //         // this.$router.push("/Home/Home");
    //       } else {
    //         sessionStorage.setItem("jwt","null");
    //         swal.fire({
    //           position: "center",
    //           icon: "error",
    //           title: "Tài khoản hoặc mật khẩu không đúng",
    //           showConfirmButton: false,
    //           timer: 1500,
    //         });
    //         this.$emit("closeModal", false);
    //       }
    //     });
    // },
  },
};
</script>
