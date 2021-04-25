<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <CInput v-model.trim="passCarverion.Carversion_id" hidden />
          <CInput
            @keydown.space.prevent
            type="text"
            placeholder="Nhập tên dòng xe"
            label="Tên dòng xe"
            horizontal
            invalid-feedback="Điền ít nhất 5 kí tự không chứa dấu cách"
            :is-valid="accountname_valid"
            v-model.trim="passCarverion.Carversion_name"
          />
          <CInput
            @keydown.space.prevent
            maxlength="4"
            step="100"
            type="number"
            label="Đời"
            horizontal
            :is-valid="accountpassword_valid"
            min="1799"
            max="2999"
            v-model.trim="passCarverion.Carversion_date"
          />
          <CSelect
            @keydown.space.prevent
            label="Kiểu dáng"
            horizontal
            :options="options"
            placeholder="Please select"
            v-model.trim="passCarverion.Carversion_style"
          />
          <CInput
            @keydown.space.prevent
            type="text"
            label="Class"
            horizontal
            v-model.trim="passCarverion.Carversion_class"
          />
          <CInput
            @keydown.space.prevent
            type="text"
            label="Option"
            horizontal
            v-model.trim="passCarverion.Carversion_option"
          />
          <CInput
            @keydown.space.prevent
            type="text"
            label="Tên hãng sản xuất"
            list="ManufacturerNames"
            horizontal
            v-model.trim="passCarverion.Carversion_ManufacturerName"
          />
          <datalist id="ManufacturerNames">
            <option value="Edge"></option>
            <option value="Firefox"></option>
            <option value="Chrome"></option>
            <option value="Opera"></option>
            <option value="Safari"></option>
          </datalist>

          <CInput
            @keydown.space.prevent
            type="text"
            label="Logo"
            horizontal
            :is-valid="accountpassword_valid"
            v-model.trim="passCarverion.Carversion_ManufacturerLogo"
          />
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton
            color="info"
            v-if="passCarverion.Carversion_id == 0"
            @click="insertClick(passCarverion)"
          >
            Thêm
          </CButton>
          <CButton
            color="info"
            v-if="passCarverion.Carversion_id != 0"
            @click="updateClick(passCarverion)"
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
import Datepicker from "vuejs-datepicker";
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";
export default {
  name: "TheCreateEditCarversion",
  components: {
    Datepicker,
  },
  props: {
    passCarverion: {
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
      options: [
        "Micro",
        "Sedan",
        "CUV",
        "SUV",
        "Hatchback",
        "Roadster",
        "Pickup",
        "Coupe",
        "Supercar",
        "Cabriolet",
        "Minivan",
      ],
    };
  },
  methods: {
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    // insertClick() {
    //   this.accountname_valid = this.validator(this.passAccount.Account_name);
    //   this.accountpassword_valid = this.validator(
    //     this.passAccount.Account_password
    //   );
    //   if (this.accountname_valid && this.accountpassword_valid) {
    //     axios
    //       .post("https://localhost:44343/Api/Account/", this.passAccount)
    //       .then((res) => {
    //         swal.fire({
    //           position: "center",
    //           icon: res.data.split("-")[0] == "1" ? "success" : "error",
    //           title: res.data.split("-")[1],
    //           showConfirmButton: false,
    //           timer: 1500,
    //         });
    //         this.$emit("closeModal", false);
    //       });
    //   }
    // },
    // updateClick() {
    //   this.accountname_valid = this.validator(this.passAccount.Account_name);
    //   this.accountpassword_valid = this.validator(
    //     this.passAccount.Account_password
    //   );
    //   if (this.accountname_valid && this.accountpassword_valid) {
    //     axios
    //       .put("https://localhost:44343/Api/Account/", this.passAccount)
    //       .then((res) => {
    //         swal.fire({
    //           position: "center",
    //           icon: res.data.split("-")[0] == "1" ? "success" : "error",
    //           title: res.data.split("-")[1],
    //           showConfirmButton: false,
    //           timer: 1500,
    //         });
    //         this.$emit("closeModal", false);
    //       });
    //   }
    // },
  },
};
</script>
