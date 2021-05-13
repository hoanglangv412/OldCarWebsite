<template>
  <div class="TheCustomer">
    <CRow>
      <CCol>
        <fieldset class="border p-2">
          <legend class="ml-2" style="width: 0">
            <h4>Đổi mật khẩu</h4>
          </legend>
          <CInput v-model="updatePasswordData.Customer_id" hidden />
          <CInput v-model="updatePasswordData.Customer_avatar" hidden />
          <CInput v-model="updatePasswordData.Customer_name" hidden />
          <CInput v-model="updatePasswordData.Customer_birth" hidden />
          <CInput v-model="updatePasswordData.Customer_email" hidden />
          <CInput v-model="updatePasswordData.Customer_address" hidden />
          <CInput v-model="updatePasswordData.Customer_begindate" hidden />
          <CInput v-model="updatePasswordData.Account_name" hidden />
          <CInput v-model="updatePasswordData.Account_role" hidden />
          <CInput v-model="updatePasswordData.Account_lastLogin" hidden />
          <CInput
            type="password"
            label="Nhập mật khẩu cũ"
            @keydown.space.prevent
            id="id_oldpassword"
          />
          <CInput
            type="password"
            label="Nhập mật khẩu mới"
            @keydown.space.prevent
            id="id_newpassword"
          />
          <CInput
            type="password"
            id="id_renewpassword"
            label="Nhập lại mật khẩu mới"
            @keydown.space.prevent
          />
          <CButton
            class="btn btn-info float-right mt-2"
            @click="updatePassword(updatePasswordData)"
            >Cập nhật</CButton
          >
        </fieldset>
      </CCol>
    </CRow>
  </div>
</template>
<script>
import { freeSet } from "@coreui/icons";
import axios from "axios";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
export default {
  name: "TheCustomer",
  freeSet,
  props: {
    updatePasswordData: {},
  },
  components: {},
  data() {
    return {
      domain: Domain,
    };
  },
  updated() {
    $("input").val("");
  },
  methods: {
    updatePassword(value) {
      console.log("ahahahahahha", value);
      if (
        $("#id_oldpassword").val() == value.Account_password &&
        $("#id_renewpassword").val() == $("#id_newpassword").val()
      ) {
        value.Account_password = $("#id_renewpassword").val();
        axios.put(this.domain + "Customer/Put", value).then((res) => {
          swal.fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          });
          this.$emit("closeModal", false);
        });
      } else {
        swal.fire({
          position: "center",
          icon: "error",
          title: "Sai tài khoản hoặc mật khẩu",
          showConfirmButton: false,
          timer: 1500,
        });
        this.$emit("closeModal", false);
      }
    },
  },
};
</script>