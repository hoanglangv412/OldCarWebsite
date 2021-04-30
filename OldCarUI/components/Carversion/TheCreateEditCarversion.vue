<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <CInput v-model.trim="passCarverion.Carversion_id" hidden />
          <CInput
            type="text"
            placeholder="Nhập tên dòng xe"
            label="Tên dòng xe"
            horizontal
            invalid-feedback="Điền ít nhất 5 kí tự không chứa dấu cách"
            :is-valid="accountname_valid"
            v-model.trim="passCarverion.Carversion_name"
          />
          <CInput
            type="text"
            label="Tên hãng sản xuất"
            placeholder="Nhập tên hãng sản xuất"
            list="ManufacturerNames"
            horizontal
            v-model.trim="passCarverion.Carversion_ManufacturerName"
          />
          <datalist id="ManufacturerNames">
            <option
              v-for="item in Manufacturers"
              :key="item"
              :value="item"
            ></option>
          </datalist>
          <CInput
            @keydown.space.prevent
            placeholder="Nhập đời xe"
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
          <div role="group" class="form-group form-row">
            <CCol sm="3">
              <label>Kiểu dáng</label>
            </CCol>
            <CCol sm="9">
              <select
                class="custom-select"
                v-model="passCarverion.Carversion_style"
              >
                <option v-for="item in options" :key="item" :value="item">
                  {{ item }}
                </option>
              </select>
            </CCol>
          </div>
          <CInput
            type="text"
            label="Phiên bản"
            horizontal
            v-model.trim="passCarverion.Carversion_edition"
          />
          <div role="group" class="form-group form-row">
            <CCol sm="3">
              <label>Option</label>
            </CCol>
            <CCol sm="9">
              <div
                role="group"
                class="form-check"
                v-for="(option, optionIndex) in CarOptions"
                :key="optionIndex"
              >
                <input
                  :id="option + optionIndex"
                  type="radio"
                  name="CarOption"
                  class="form-check-input"
                  :value="optionIndex"
                  v-model="passCarverion.Carversion_option"
                /><label :for="option + optionIndex" class="form-check-label">
                  {{ option }}
                </label>
              </div>
              <!-- <input type="radio" name="Car option" :value="optionIndex" /> -->
            </CCol>
          </div>
          <input
            id="idphotoselector"
            type="file"
            label="Logo"
            horizontal
            @change="onFileChange"
          />
          <input
            id="idcarphotoselector"
            type="file"
            label="Ảnh dòng xe"
            horizontal
            @change="onCarFileChange"
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
import { Domain } from "@/constant/constant";
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
      filesToSave: { name: null, file: null },
      domain: Domain,
      selected: [], // Must be an array reference!
      show: true,
      horizontal: { label: "col-3", input: "col-9" },
      CarOptions: ["Standard", "Advance", "Full option"],
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
      Manufacturers: [
        "Acura",
        "Alfa Romeo",
        "Audi",
        "BMW",
        "Bentley",
        "Buick",
        "Cadillac",
        "Chevrolet",
        "Chrysler",
        "Dodge",
        "Fiat",
        "Ford",
        "GMC",
        "Genesis",
        "Honda",
        "Hyundai",
        "Infiniti",
        "Jaguar",
        "Jeep",
        "Kia",
        "Land Rover",
        "Lexus",
        "Lincoln",
        "Lotus",
        "Maserati",
        "Mazda",
        "Mercedes-Benz",
        "Mercedes-Benz AMG",
        "Mercury",
        "Mini",
        "Mitsubishi",
        "Nikola",
        "Nissan",
        "Polestar",
        "Pontiac",
        "Porsche",
        "Ram",
        "Rivian",
        "Rolls-Royce",
        "Saab",
        "Saturn",
        "Scion",
        "Smart",
        "Subaru",
        "Suzuki",
        "Tesla",
        "Toyota",
        "Volkswagen",
        "Volvo",
        "Vinfast",
      ],
    };
  },
  methods: {
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.passCarverion.Carversion_ManufacturerLogo = files[0].name;
      this.filesToSave.file = files[0];
    },
    onCarFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.passCarverion.Carversion_photo = files[0].name;
      this.filesToSave.file = files[0];
    },
    insertClick(value) {
      if (value.Carversion_edition == null) {
        value.Carversion_edition = "Edition 1";
      }
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      axios.post(this.domain + "Carversion/post", value).then((res) => {
        var photoPath = "";
        swal.fire({
          position: "center",
          icon: res.data.split("-")[0] == "1" ? "success" : "error",
          title: res.data.split("-")[1],
          showConfirmButton: false,
          timer: 1500,
        });
        let formData = new FormData();
        formData.append("file", this.filesToSave.file);
        if (formData != null) {
          photoPath += "logo~";
        }
        if (document.getElementById("idcarphotoselector").files.length > 0) {
          photoPath += "Carversion~";
        }
        if (photoPath != "") {
          formData.append("FilePath", photoPath);
          axios
            .post(this.domain + "Carversion/SaveFile", formData, {
              headers: {
                "Content-Type": this.filesToSave.type,
              },
            })
            .then((response) => {
              console.log(response);
            });
        }
        this.$emit("closeModal", false);
      });
      // }
    },
    updateClick(value) {
      if (value.Carversion_edition == null) {
        value.Carversion_edition = "Edition 1";
      }
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      axios.put(this.domain + "Carversion/put", value).then((res) => {
        var photoPath = "";
        swal.fire({
          position: "center",
          icon: res.data.split("-")[0] == "1" ? "success" : "error",
          title: res.data.split("-")[1],
          showConfirmButton: false,
          timer: 1500,
        });
        let formData = new FormData();
        formData.append("file", this.filesToSave.file);
        if (document.getElementById("idphotoselector").files.length > 0) {
          photoPath += "logo~";
        }

        if (document.getElementById("idcarphotoselector").files.length > 0) {
          photoPath += "Carversion~";
        }
        formData.append("FilePath", photoPath);
        axios
          .post(this.domain + "Carversion/SaveFile", formData, {
            headers: {
              "Content-Type": this.filesToSave.type,
            },
          })
          .then((response) => {
            console.log(response);
          });
        this.$emit("closeModal", false);
      });
      // }
    },
  },
};
</script>
