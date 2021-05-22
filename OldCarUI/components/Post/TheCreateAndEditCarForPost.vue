<template>
  <div>
    <CCol md="12" v-if="flag_Customer_Carversion">
      <fieldset class="border p-2">
        <legend class="ml-2" style="width: 0">Tạo dòng xe</legend>
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
            <div role="group" class="form-group form-row">
              <CCol sm="3">
                <label>Logo</label>
              </CCol>
              <CCol sm="9">
                <input
                  id="idphotoselector"
                  type="file"
                  horizontal
                  @change="onFileChange"
                />
              </CCol>
            </div>
            <div role="group" class="form-group form-row">
              <CCol sm="3">
                <label>Ảnh dòng xe</label>
              </CCol>
              <CCol sm="9">
                <input
                  id="idcarphotoselector"
                  type="file"
                  horizontal
                  @change="onCarFileChange"
                />
              </CCol>
            </div>
          </CCardBody>
          <CCardFooter class="text-center d-flex justify-content-between">
            <CButton color="danger" to="/Post/CreateAndEditPost">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                class="bi bi-arrow-left"
                viewBox="0 0 16 16"
              >
                <path
                  fill-rule="evenodd"
                  d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"
                />
              </svg>
              Back
            </CButton>
            <CButton color="info" @click="nextCarversionClick(passCarverion)">
              Next
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                class="bi bi-arrow-right"
                viewBox="0 0 16 16"
              >
                <path
                  fill-rule="evenodd"
                  d="M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8z"
                />
              </svg>
            </CButton>
          </CCardFooter>
        </CForm>
      </fieldset>
    </CCol>
    <CCol md="12" v-if="flag_Customer_Car">
      <CForm class="form-insert-update">
        <CCardBody class="text-nowrap">
          <CRow>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border p-4">
                <legend style="width: 0">Thông số kĩ thuật</legend>
                <div role="group" class="form-group form-row">
                  <CCol>
                    <label>Dòng xe</label>
                    <input
                      class="form-control"
                      id="id_carversions"
                      disabled="true"
                    />
                  </CCol>
                </div>
                <CRow>
                  <CCol>
                    <label>Động cơ</label>
                    <input
                      class="form-control"
                      v-model.trim="passCar.Car_engine"
                  /></CCol>
                  <CCol>
                    <label>Dung tích xi lanh</label>
                    <input
                      class="form-control"
                      v-model.trim="passCar.Car_cylcapacity"
                  /></CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Hệ truyền động</label>
                    <select
                      class="custom-select form-control"
                      v-model.trim="passCar.Car_drivetype"
                    >
                      <option
                        v-for="item in Cardrivetypes"
                        :key="item"
                        :value="item"
                      >
                        {{ item }}
                      </option>
                    </select></CCol
                  >

                  <CCol
                    ><label>Hộp số</label>
                    <select
                      class="custom-select form-control"
                      v-model.trim="passCar.Car_trans"
                    >
                      <option
                        v-for="item in Cartrans"
                        :key="item"
                        :value="item"
                      >
                        {{ item }}
                      </option>
                    </select></CCol
                  >
                </CRow>
                <CRow>
                  <CCol>
                    <label>Momen xoắn cực đại</label>
                    <div class="input-group">
                      <input
                        class="form-control"
                        placeholder="(momen xoắn cực đại @ RPM)"
                        v-model.trim="passCar.Car_maxmomen"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >RPM</span
                        >
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Công suất cực đại</label>
                    <div class="input-group">
                      <input
                        class="form-control"
                        placeholder="(mã lực @ RPM)"
                        v-model.trim="passCar.Car_maxpower"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >RPM</span
                        >
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Vận tốc tối đa</label>
                    <div class="input-group">
                      <input
                        type="text"
                        class="form-control"
                        v-model.trim="passCar.Car_maxspeed"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >km/h</span
                        >
                      </div>
                    </div></CCol
                  >
                  <CCol>
                    <label>Tăng tốc</label>
                    <div class="input-group">
                      <input
                        type="text"
                        class="form-control"
                        v-model.trim="passCar.Car_acceleration"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >0-100km/h</span
                        >
                      </div>
                    </div></CCol
                  >
                </CRow>
              </fieldset>
              <fieldset class="border p-4">
                <legend style="width: 0">Hệ thống phanh</legend>
                <CRow>
                  <CCol>
                    <label>Hệ thống phanh chân(Trước/Sau)</label>
                    <select
                      class="custom-select form-control"
                      v-model.trim="passCar.Car_brakesystem"
                    >
                      <option
                        v-for="item in Carbrakes"
                        :key="item"
                        :value="item"
                      >
                        {{ item }}
                      </option>
                    </select></CCol
                  >
                  <CCol>
                    <label>Hệ thống phanh tay</label>
                    <select
                      class="custom-select form-control"
                      v-model.trim="passCar.Car_handbrake"
                    >
                      <option
                        v-for="item in Carhandbrakes"
                        :key="item"
                        :value="item"
                      >
                        {{ item }}
                      </option>
                    </select></CCol
                  >
                </CRow>
              </fieldset>
            </CCol>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border p-4">
                <legend style="width: 0">Kích thước xe</legend>
                <div role="group" class="form-group form-row">
                  <CCol sm="3">
                    <label>Kích thước xe(mm)</label>
                  </CCol>
                  <CCol sm="9">
                    <CRow>
                      <CCol>
                        <input
                          class="form-control"
                          placeholder="Dài"
                          id="idlength"
                      /></CCol>
                      <CCol>
                        <input
                          class="form-control"
                          placeholder="Rộng"
                          id="idwidth"
                      /></CCol>
                      <CCol>
                        <input
                          class="form-control"
                          placeholder="Cao"
                          id="idheight"
                      /></CCol>
                    </CRow>
                  </CCol>
                </div>
                <CRow>
                  <CCol>
                    <label>Chiều dài cơ sở(mm)</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_baselength"
                      min="0"
                      step="100"
                      max="10000"
                  /></CCol>
                  <CCol>
                    <label>Bán kính quay vòng(mm)</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_turnradius"
                      min="0"
                      step="100"
                      max="10000"
                  /></CCol>
                  <CCol>
                    <label>Khoảng sáng gầm xe(mm)</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_height"
                      min="0"
                      step="100"
                      max="10000"
                  /></CCol>
                </CRow>
              </fieldset>
              <fieldset class="border p-4">
                <legend style="width: 0">Nhiên liệu</legend>
                <CRow>
                  <CCol>
                    <label>Nhiên liệu</label>
                    <select
                      class="custom-select form-control"
                      v-model.trim="passCar.Car_fuel"
                    >
                      <option v-for="item in fuels" :key="item" :value="item">
                        {{ item }}
                      </option>
                    </select></CCol
                  >
                </CRow>
                <CRow>
                  <CCol>
                    <label>Mức tiêu thụ nhiên liệu trong đô thị</label>
                    <div class="row">
                      <div class="col-3 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-9 pr-0 pl-0">
                        <div class="input-group">
                          <input
                            class="form-control"
                            v-model.trim="passCar.Car_cityfuelconsump"
                          />
                          <div class="input-group-append">
                            <span class="input-group-text" id="basic-addon2"
                              >lít/100km</span
                            >
                          </div>
                        </div>
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Mức tiêu thụ nhiên liệu ngoài đô thị</label>
                    <div class="row">
                      <div class="col-3 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-9 pr-0 pl-0">
                        <div class="input-group">
                          <input
                            class="form-control"
                            v-model.trim="passCar.Car_highwayfuelconsump"
                          />
                          <div class="input-group-append">
                            <span class="input-group-text" id="basic-addon2"
                              >lít/100km</span
                            >
                          </div>
                        </div>
                      </div>
                    </div></CCol
                  >
                </CRow>
              </fieldset>
              <fieldset class="border p-4">
                <legend style="width: 0">Khác</legend>
                <CRow>
                  <CCol>
                    <label>Số ghế</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_seats"
                      min="0"
                      max="10"
                  /></CCol>
                  <CCol>
                    <label>Số cửa</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_doors"
                      min="0"
                      max="10"
                  /></CCol>
                  <CCol>
                    <label>Số túi khí</label>
                    <input
                      type="number"
                      class="form-control"
                      v-model.trim="passCar.Car_airnums"
                      min="0"
                      max="30"
                  /></CCol>
                  <CCol>
                    <label>Tải trọng</label>
                    <div class="row">
                      <div class="col-4 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-8 pr-0 pl-0">
                        <div class="input-group">
                          <input
                            type="text"
                            class="form-control"
                            v-model.trim="passCar.Car_loadweight"
                          />
                          <div class="input-group-append">
                            <span class="input-group-text" id="basic-addon2"
                              >Kg</span
                            >
                          </div>
                        </div>
                      </div>
                    </div>
                  </CCol>

                  <!-- <CInput
                type="text"
                label="Kích thước xe"
                horizontal
                v-model.trim="passCar.Car_totaldimens" /> -->
                  <CInput v-model.trim="passCar.Car_id" hidden />
                </CRow>
              </fieldset>
            </CCol>
          </CRow>
        </CCardBody>
        <CCardFooter class="text-center d-flex justify-content-between">
          <CButton color="danger" @click="backCarversionClick()">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="16"
              height="16"
              fill="currentColor"
              class="bi bi-arrow-left"
              viewBox="0 0 16 16"
            >
              <path
                fill-rule="evenodd"
                d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"
              />
            </svg>
            Back
          </CButton>
          <CButton
            color="info"
            v-if="passCar.Car_id == 0"
            @click="nextCarClick(passCar)"
          >
            Tạo xe +
          </CButton>
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
  name: "TheCreateEditCarForPost",
  components: {
    Datepicker,
  },
  props: {
    passCarverion: {
      type: Object,
      default: () => {},
    },
    passCar: {
      type: Object,
      default: () => {},
    },
    accountname_valid: Boolean,
    accountpassword_valid: Boolean,
  },
  mounted() {
    this.getCarversions();
  },
  updated() {
    this.setCarversion_id(this.carVersionToInsert);
  },
  data() {
    return {
      formData: null,
      photoPath: "",
      filesToSave: { name: null, file: null },
      photoToSave: { name: null, file: null },
      carVersionToInsert: {},
      carUpdate: {},
      Carversions: [],
      Cartrans: [
        "Hộp số sàn (MT)",
        "Hộp số tự động có cấp (AT)",
        "Hộp số tự động vô cấp (CVT)",
        "Hộp số tự động ly hợp kép (DCT)",
      ],
      Cardrivetypes: [
        "FWD (Front-Wheel Drive)",
        "RWD (Rear-Wheel Drive)",
        "AWD (All-Wheel Drive)",
        "4WD (4-Wheels Drive)",
      ],
      Carbrakes: [
        "Phanh đĩa/Phanh tang trống",
        "Phanh tang trống/Phanh đĩa",
        "Phanh đĩa/Phanh đĩa",
      ],
      Carhandbrakes: ["Phanh tay điện tử", "Phanh tay cơ"],
      fuels: ["Gasoline", "Diesel Fuel", "Bio-diesel", "Ethanol", "Electric"],
      flag_Customer_Carversion: true,
      flag_Customer_Car: false,
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
    getCarversions() {
      axios.get(this.domain + "Car/Get").then((res) => {
        this.Carversions = res.data;
      });
    },
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
      this.photoToSave.file = files[0];
    },
    async insertClick(value) {
      if (value.Carversion_edition == "") {
        value.Carversion_edition = "Edition 1";
      }
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      value.Carversion_adder = "Khách hàng";
      var result = await axios
        .post(this.domain + "Carversion/post", value)
        .then((res) => {
          if (this.photoPath != null) {
            axios
              .post(this.domain + "Carversion/SaveFile", this.formData, {
                headers: {
                  "Content-Type": this.filesToSave.type,
                },
              })
              .then((response) => {
                console.log(response);
              });
          }
        });
      return result;
      // }
    },
    nextCarversionClick(value) {
      if (document.getElementById("idphotoselector").files.length > 0) {
        this.photoPath += "logo~";
      }
      if (document.getElementById("idcarphotoselector").files.length > 0) {
        this.photoPath += "Carversion~";
      }
      if (this.photoPath != "") {
        this.formData = new FormData();
        this.formData.append("fileLogo", this.filesToSave.file);
        this.formData.append("filePhoto", this.photoToSave.file);
        this.formData.append("FilePath", this.photoPath);
      }
      this.flag_Customer_Carversion = false;
      this.flag_Customer_Car = true;
      this.carVersionToInsert = value;
    },
    backCarversionClick() {
      this.flag_Customer_Carversion = true;
      this.flag_Customer_Car = false;
      this.carVersionToInsert = {};
      this.formData = null;
    },
    setCarversion_id(value) {
      // console.log("hehehe", value);
      $("#id_carversions").val(
        value.Carversion_ManufacturerName +
          "_" +
          value.Carversion_name +
          "_" +
          (value.Carversion_edition == ""
            ? "Edition 1"
            : value.Carversion_edition) +
          "_" +
          value.Carversion_style +
          "_" +
          value.Carversion_date
      );
    },
    async nextCarClick(value) {
      await this.insertClick(this.carVersionToInsert);
      axios.get(this.domain + "Carversion/Selectlastdata").then((res) => {
        value.Car_totaldimens =
          $("#idlength").val() +
          " x " +
          $("#idwidth").val() +
          " x " +
          $("#idheight").val();
        value.Car_carversion_id = res.data[0].Carversion_id;
        value.Car_adder = "Khách hàng";
        axios.post(this.domain + "Car/post", value).then((res) => {
          swal.fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          });
        });
        this.$router.push(`/Post/customerFlag`);
        // }
      });
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
    },
  },
};
</script>
