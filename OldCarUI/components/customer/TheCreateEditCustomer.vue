<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <CInput v-model.trim="passCustomer.Customer_name" hidden />
          <CInput
            @keydown.space.prevent
            type="text"
            placeholder="Nhập tên"
            label="Họ tên"
            horizontal
            invalid-feedback="Điền ít nhất 5 kí tự không chứa dấu cách"
            :is-valid="accountname_valid"
            v-model.trim="passCustomer.Customer_name"
          />
          <CInput
            @keydown.space.prevent
            type="date"
            label="Ngày sinh"
            horizontal
            :is-valid="accountpassword_valid"
            v-model.trim="passCustomer.Customer_birth"
          />
          <div class="form-row form-group">
            <CCol sm="3">Quyền</CCol>
            <CCol sm="9">
              <CInputRadio
                v-for="(option, optionIndex) in radioOptions"
                :key="option"
                :label="option"
                type="radio"
                :value="optionIndex"
                :custom="true"
                name="usertype"
                @update:checked="passAccount.Account_role = optionIndex"
                :checked="optionIndex === passAccount.Account_role"
              />
            </CCol>
          </div>
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton
            color="info"
            v-if="passAccount.Account_id == 0"
            @click="insertClick(account)"
          >
            Thêm
          </CButton>
          <CButton
            color="info"
            v-if="passAccount.Account_id != 0"
            @click="updateClick(account)"
          >
            Cập nhật
          </CButton>
          <CButton type="reset" color="danger"> Reset </CButton>
        </CCardFooter>
      </CForm>
    </CCol>
  </div>
</template>

<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";

export default {
  name: "TheCreateEditCustomer",
  props: {
    passAccount: {
      type: Object,
      default: () => {},
    },
    accountname_valid: Boolean,
    accountpassword_valid: Boolean,
  },
  data() {
    return {
      selected: [], // Must be an array reference!
      show: true,
      horizontal: { label: "col-3", input: "col-9" },
      radioOptions: ["Admin", "Người dùng"],
    };
  },
  methods: {
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    insertClick() {
      this.accountname_valid = this.validator(this.passAccount.Account_name);
      this.accountpassword_valid = this.validator(
        this.passAccount.Account_password
      );
      if (this.accountname_valid && this.accountpassword_valid) {
        axios
          .post("https://localhost:44343/OldCar/Account/", this.passAccount)
          .then((res) => {
            swal.fire({
              position: "center",
              icon: res.data.split("-")[0] == "1" ? "success" : "error",
              title: res.data.split("-")[1],
              showConfirmButton: false,
              timer: 1500,
            });
            this.$emit("closeModal", false);
          });
      }
    },
    updateClick() {
      this.accountname_valid = this.validator(this.passAccount.Account_name);
      this.accountpassword_valid = this.validator(
        this.passAccount.Account_password
      );
      if (this.accountname_valid && this.accountpassword_valid) {
        axios
          .put("https://localhost:44343/OldCar/Account/", this.passAccount)
          .then((res) => {
            swal.fire({
              position: "center",
              icon: res.data.split("-")[0] == "1" ? "success" : "error",
              title: res.data.split("-")[1],
              showConfirmButton: false,
              timer: 1500,
            });
            this.$emit("closeModal", false);
          });
      }
    },
  },
};
</script>
