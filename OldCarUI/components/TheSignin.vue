<template>
  <div>
    <CRow>
      <CCol md="8">
        <CForm class="form-insert-update">
          <CCardBody v-if="registerFlag">
            <CInput
              type="text"
              v-model.trim="registForm.Customer_id"
              hidden
            />
            <CInput
              type="text"
              placeholder="Nhập họ tên"
              label="Họ tên"
              horizontal
              v-model.trim="registForm.Customer_name"
            />
            <CInput
              @keydown.space.prevent
              type="date"
              label="Ngày sinh"
              placeholder=""
              horizontal
              v-model.trim="registForm.Customer_birth"
            />
            <CInput
              @keydown.space.prevent
              type="email"
              placeholder="Nhập email"
              label="Email"
              horizontal
              v-model.trim="registForm.Customer_email"
            />
            <CInput
              type="text"
              label="Address"
              placeholder="Nhập địa chỉ"
              list="cityNames"
              horizontal
              v-model.trim="registForm.Customer_address"
            />
            <datalist id="cityNames">
              <option
                v-for="item in cityNames"
                :key="item"
                :value="item"
              ></option>
            </datalist>
            <CInput
              @keydown.space.prevent
              type="text"
              label="Điện thoại"
              placeholder="Nhập số điện thoại"
              v-model.trim="registForm.Customer_phone"
              horizontal
            />

            <CInput
              @keydown.space.prevent
              type="text"
              placeholder="Tài khoản"
              label="Tên tài khoản"
              horizontal
              v-model.trim="registForm.Account_name"
            />
            <CInput
              @keydown.space.prevent
              type="password"
              label="Mật khẩu"
              placeholder="Mật khẩu"
              horizontal
              v-model.trim="registForm.Account_password"
            />
          </CCardBody>
          <CCardBody v-else>
            <CInput
              @keydown.space.prevent
              type="text"
              placeholder="Tài khoản"
              label="Tên tài khoản"
              horizontal
              v-model.trim="userInfo.Username"
            />
            <CInput
              @keydown.space.prevent
              type="password"
              label="Mật khẩu"
              placeholder="Mật khẩu"
              horizontal
              v-model.trim="userInfo.Password"
            />
          </CCardBody>
          <CCardFooter class="text-center">
            <CButton
              color="info"
              @click="registerForm(registForm)"
              v-if="registerFlag"
            >
              {{ buttonText }}
            </CButton>
            <CButton color="info" @click="submitForm(userInfo)" v-else>
              {{ buttonText }}
            </CButton>
          </CCardFooter>
        </CForm>
      </CCol>
      <CCol md="4">
        <div class="h-75 w-75">
          <img src="@/assets/img/logobrand.jpg" class="c-avatar-img" />
        </div>
      </CCol>
    </CRow>
  </div>
</template>
<style>
label {
  color: black;
}
</style>
<script>
import axios from "axios";
import swal from "sweetalert2";
export default {
  name: "TheSignin",
  props: ["submitForm", "buttonText", "registerFlag","registerForm"],
  data() {
    return {
      userInfo: {
        Username: "",
        Password: "",
        grant_type: "password",
      },
      registForm: {
        Customer_id: null,
        Customer_avatar: "",
        Customer_name: "",
        Customer_birth: "",
        Customer_email: "",
        Customer_address: "",
        Customer_phone: "",
        Customer_begindate: "",
        Account_name: "",
        Account_password: "",
        Account_role: "",
        Account_lastLogin: "",
      },
      cityNames: [
        "An Giang",
        "Bà Rịa - Vũng Tàu",
        "Bắc Giang",
        "Bắc Kạn",
        "Bạc Liêu",
        "Bắc Ninh",
        "Bến Tre",
        "Bình Định",
        "Bình Dương",
        "Bình Phước",
        "Bình Thuận",
        "Cà Mau",
        "Cao Bằng",
        "Đắk Lắk",
        "Đắk Nông",
        "Điện Biên",
        "Đồng Nai",
        "Đồng Tháp",
        "Gia Lai",
        "Hà Giang",
        "Hà Nam",
        "Hà Tĩnh",
        "Hải Dương",
        "Hậu Giang",
        "Hòa Bình",
        "Hưng Yên",
        "Khánh Hòa",
        "Kiên Giang",
        "Kon Tum",
        "Lai Châu",
        "Lâm Đồng",
        "Lạng Sơn",
        "Lào Cai",
        "Long An",
        "Nam Định",
        "Nghệ An",
        "Ninh Bình",
        "Ninh Thuận",
        "Phú Thọ",
        "Quảng Bình",
        "Quảng Nam",
        "Quảng Ngãi",
        "Quảng Ninh",
        "Quảng Trị",
        "Sóc Trăng",
        "Sơn La",
        "Tây Ninh",
        "Thái Bình",
        "Thái Nguyên",
        "Thanh Hóa",
        "Thừa Thiên Huế",
        "Tiền Giang",
        "Trà Vinh",
        "Tuyên Quang",
        "Vĩnh Long",
        "Vĩnh Phúc",
        "Yên Bái",
        "Phú Yên",
        "Cần Thơ",
        "Đà Nẵng",
        "Hải Phòng",
        "Hà Nội",
        "TP Hồ Chí Minh",
      ],
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
    //       "https://localhost:44343/Api/Customer/CheckExistAccount/" +
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
