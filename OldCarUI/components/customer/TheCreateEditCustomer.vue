<template>
  <div>
    <CRow>
      <CCol col="12" class="p-5">
        <CForm class="form-insert-update m-5">
          <CCard>
            <CCardHeader>
              <h4>Cập nhật tài khoản</h4>
            </CCardHeader>
            <CCardBody>
              <CRow>
                <CCol col="12" xl="3" lg="3" md="12" sm="12" class="">
                  <div class="d-flex justify-content-center w-100">
                    <CImg
                      v-if="this.photoFlag"
                      class="rounded-circle position-relative avatar_img"
                      style="height: 250px; width: 250px"
                      :src="takePhoto(customerData.Customer_avatar)"
                    />
                    <CImg
                      v-else
                      class="rounded-circle position-relative avatar_img"
                      style="height: 250px; width: 250px"
                      :src="this.customerAvatarDisplay"
                    />
                  </div>
                  <input
                    type="file"
                    id="id_file"
                    hidden
                    @change="onFileChange"
                  />
                  <CButton
                    color="light"
                    class="float-right mr-4 mb-5"
                    @click="updateAvatar(customerData)"
                  >
                    <CIcon :content="$options.freeSet.cilPencil"
                  /></CButton>
                </CCol>
                <CCol>
                  <!-- <CInput v-model.trim="customerData.Customer_id" hidden /> -->
                  <CRow>
                    <CCol class="col-5">
                      <h1 class="mb-5">
                        Xin chào, {{ customerData.Customer_name }}
                      </h1>
                    </CCol>
                    <CCol>
                      <CButton
                        color="light"
                        @click="updatePassword(customerData)"
                      >
                        Đổi mật khẩu
                      </CButton>
                      <CModal
                        :title="ModalTitle"
                        color="info"
                        size="sm"
                        :show.sync="infoModal"
                      >
                        <TheUpdatePassword
                          :updatePasswordData="updatePasswordData"
                          @closeModal="closeModal"
                        />
                        <div slot="footer" class="w-100 d-none"></div>
                      </CModal>
                    </CCol>
                  </CRow>
                  <CInput
                    @keydown.space.prevent
                    type="date"
                    label="Ngày sinh"
                    horizontal
                    v-model.trim="customerData.Customer_birth" />
                  <CInput
                    type="text"
                    label="Địa chỉ"
                    list="cityNames"
                    horizontal
                    v-model.trim="customerData.Customer_address" />
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
                    label="Số điện thoại"
                    horizontal
                    v-model.trim="customerData.Customer_phone" />
                  <CInput
                    v-model.trim="customerData.Account_role"
                    value="1"
                    hidden />
                  <CInput
                    v-model.trim="customerData.Customer_begindate"
                    value="0"
                    hidden />
                  <CInput
                    v-model.trim="customerData.Account_lastLogin"
                    value="0"
                    hidden />
                  <CInput
                    v-model.trim="customerData.Customer_avatar"
                    value="kieu.jpg"
                    hidden />
                  <CInput
                    v-model.trim="customerData.Account_name"
                    value="0"
                    hidden />
                  <CInput v-model.trim="customerData.Customer_email" hidden />
                  <CInput v-model.trim="customerData.Account_password" hidden
                /></CCol>
              </CRow>
            </CCardBody>
            <CCardFooter class="text-center">
              <CButton color="info" @click="updateClick(customerData)">
                Cập nhật
              </CButton>
              <CButton type="reset" color="danger"> Reset </CButton>
            </CCardFooter>
          </CCard>
        </CForm>
      </CCol>
    </CRow>
  </div>
</template>

<style>
.avatar_img :hover h1 .modal-header {
  display: none !important;
}
</style>
<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
import TheUpdatePassword from "~/components/customer/TheUpdatePassword";
export default {
  freeSet,
  name: "TheCreateEditCustomer",
  props: {
    customerData: {
      type: Object,
      default: () => {},
    },
    // accountname_valid: Boolean,
    // accountpassword_valid: Boolean,
  },
  data() {
    return {
      photoFlag: true,
      customerAvatarDisplay: null,
      filesToSave: { name: null, file: null },
      updatePasswordData: {},
      selected: [], // Must be an array reference!
      show: true,
      domain: Domain,
      ModalTitle: null,
      infoModal: false,
      horizontal: { label: "col-3", input: "col-9" },
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
    };
  },
  components: {
    TheUpdatePassword,
  },
  methods: {
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.customerAvatarDisplay = URL.createObjectURL(files[0]);
      this.customerData.Customer_avatar = files[0].name;
      this.filesToSave.file = files[0];
      this.photoFlag = false;
      if (this.filesToSave.file != null) {
        let formData = new FormData();
        formData.append("fileAvatar", this.filesToSave.file);
        axios
          .post(this.domain + "Customer/SaveFile", formData, {
            headers: {
              "Content-Type": this.filesToSave.type,
            },
          })
          .then((response) => {
            console.log(response);
          });
      }
    },
    updateAvatar(val) {
      $("#id_file").click();
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
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    closeModal(val) {
      this.infoModal = val;
    },
    updateClick(val) {
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      axios.put(this.domain + "Customer/Put", val).then((res) => {
        if (res != null) {
          swal.fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          });
          this.$emit("closeModal", false);
        }
      });
    },
    // },
    updatePassword(value) {
      this.updatePasswordData = {
        Customer_id: value.Customer_id,
        Customer_avatar: value.Customer_avatar,
        Customer_name: value.Customer_name,
        Customer_birth: value.Customer_birth.split("T")[0],
        Customer_email: value.Customer_email,
        Customer_address: value.Customer_address,
        Customer_phone: value.Customer_phone,
        Customer_begindate: value.Customer_begindate,
        Account_name: value.Account_name,
        Account_password: value.Account_password,
        Account_role: value.Account_role,
        Account_lastLogin: value.Account_lastLogin,
      };
      (this.infoModal = true), (this.ModalTitle = "Cập nhật mật khẩu");
    },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getdata");
    },
  },
};
</script>
