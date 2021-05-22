<template>
  <div>
    <CCol col="12" v-if="this.Role == 1">
      <CButton
        class="text-center pr-0 pl-0 btn btn-info"
        style="width: 100px"
        to="/Post/CreateAndEditCarForPost"
      >
        Tạo xe riêng
      </CButton></CCol
    >
    <CCol md="12">
      <CForm class="form-insert-update" id="TheCreateAndEditCarID">
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
                      list="listCarversions"
                      v-model="passCar.Car_carversion_id"
                    />
                    <datalist id="listCarversions">
                      <option
                        v-for="item in Carversions"
                        :key="item.Carversion_id"
                        :value="item.Carversion_id"
                      >
                        {{ item.Carversion_ManufacturerName }} _
                        {{ item.Carversion_name }} _
                        {{ item.Carversion_edition }} _
                        {{ item.Carversion_style }} _
                        {{ item.Carversion_date }}
                      </option>
                    </datalist>
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
                    <input
                      class="form-control"
                      placeholder="(momen xoắn cực đại @ RPM)"
                      v-model.trim="passCar.Car_maxmomen"
                  /></CCol>
                  <CCol>
                    <label>Công suất cực đại</label>
                    <input
                      class="form-control"
                      placeholder="(mã lực @ RPM)"
                      v-model.trim="passCar.Car_maxpower"
                  /></CCol>
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
                    <div class="input-group">
                      <input
                        class="form-control"
                        type="text"
                        v-model.trim="passCar.Car_cityfuelconsump"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >lít/100km</span
                        >
                      </div>
                    </div></CCol
                  >
                  <CCol>
                    <label>Mức tiêu thụ nhiên liệu ngoài đô thị</label>
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
                    <input
                      type="text"
                      class="form-control"
                      v-model.trim="passCar.Car_loadweight"
                  /></CCol>

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
        <CCardFooter class="text-center" v-if="this.Role == 0">
          <CButton
            color="info"
            v-if="passCar.Car_id == 0"
            @click="insertClick(passCar)"
          >
            Thêm
          </CButton>
          <CButton
            color="info"
            v-if="passCar.Car_id != 0"
            @click="updateClick(passCar)"
          >
            Cập nhật
          </CButton>
          <CButton type="reset" color="danger"> Reset </CButton>
        </CCardFooter>
        <CCardFooter class="text-center" v-if="this.Role == 1">
          <CButton
            color="info"
            to="/Post/CreateAndEditPost"
          >
            Tạo bài đăng
          </CButton>
        </CCardFooter>
      </CForm>
    </CCol>
  </div>
</template>
<style scoped>
.text-nowrap {
  white-space: nowrap !important;
}
</style>
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
    passCar: {
      type: Object,
      default: () => {},
    },
    passLength: {},
    passWidth: {},
    passHeight: {},
    accountname_valid: Boolean,
    accountpassword_valid: Boolean,
  },

  mounted() {
    this.getCarversions();
  },
  beforeUpdate() {
    $("#idlength").val(this.passLength);
    $("#idwidth").val(this.passWidth);
    $("#idheight").val(this.passHeight);
  },
  data() {
    return {
      Role: null,
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
      domain: Domain,
      horizontal: { label: "col-6", input: "col-6" },
    };
  },
  updated() {
    this.Role =
      this.$auth.$storage.getUniversal("userInfo") == null
        ? 2
        : this.$auth.$storage.getUniversal("userInfo").Account_role;
    if (this.Role == 1) {
      $("#TheCreateAndEditCarID input,select").attr("disabled", true);
    }
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
    insertClick(value) {
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      value.Car_totaldimens =
        $("#idlength").val() +
        " x " +
        $("#idwidth").val() +
        " x " +
        $("#idheight").val();
      value.Car_adder = "Người quản trị";
      axios.post(this.domain + "Car/post", value).then((res) => {
        swal.fire({
          position: "center",
          icon: res.data.split("-")[0] == "1" ? "success" : "error",
          title: res.data.split("-")[1],
          showConfirmButton: false,
          timer: 1500,
        });
        this.$router.push("/Car/Car");
      });
      // }
    },
    updateClick(value) {
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      value.Car_totaldimens =
        $("#idlength").val() +
        " x " +
        $("#idwidth").val() +
        " x " +
        $("#idheight").val();
      value.Car_adder = "Người quản trị";
      axios.put(this.domain + "Car/put", value).then((res) => {
        swal.fire({
          position: "center",
          icon: res.data.split("-")[0] == "1" ? "success" : "error",
          title: res.data.split("-")[1],
          showConfirmButton: false,
          timer: 1500,
        });
        this.$router.push("/Car/Car");
      });
      // }
    },
  },
};
</script>
