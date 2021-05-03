<template>
  <div>
    <CCol>
      <CForm class="form-insert-update">
        <CCardBody class="text-nowrap">
          <CRow>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border p-4">
                <legend style="width:0;float-left">Thông tin mô tả</legend>
                <CInput v-model="passPost.Post_id" hidden />
                <label>Tiêu đề</label>
                <input
                  class="form-control"
                  v-model="passPost.Post_title"
                  type="text"
                  horizontal
                />
                <div role="group" class="form-group form-row">
                  <CCol>
                    <label>Loại xe</label>
                    <select
                      class="custom-select form-control"
                      v-model="passPost.Post_car_id"
                      id="carSelector"
                    >
                      <option
                        v-for="item in Selectpostcars"
                        :key="item.Car_id"
                        :value="item.Car_id"
                      >
                        {{ item.Carversion_ManufacturerName }} _
                        {{ item.Carversion_name }} _
                        {{ item.Carversion_edition }} _
                        {{ item.Carversion_style }} _
                        {{ item.Carversion_date }}
                      </option>
                    </select></CCol
                  >
                </div>
                <CRow>
                  <CCol>
                    <label>Giá(VND)</label>
                    <input
                      class="form-control"
                      v-model="passPost.Car_price"
                      type="number"
                      step="100000000"
                      min="0"
                      max="1000000000000"
                  /></CCol>
                  <CCol>
                    <label>Nguồn gốc</label>
                    <input
                      class="form-control"
                      v-model.trim="passPost.Car_origin"
                  /></CCol>
                  <CCol>
                    <label>Nơi đăng kí biển</label>
                    <input
                      class="form-control"
                      v-model="passPost.Car_province"
                      list="cityNames"
                  /></CCol>
                  <datalist id="cityNames">
                    <option
                      v-for="item in cityNames"
                      :key="item"
                      :value="item"
                    ></option>
                  </datalist>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Số km đã đi</label>
                    <input
                      class="form-control"
                      v-model="passPost.Car_km"
                      type="number"
                      step="1000"
                      min="0"
                      max="1000000"
                  /></CCol>
                  <CCol>
                    <label>Số km đi được trên một lít xăng</label>
                    <input
                      class="form-control"
                      v-model="passPost.Car_kpl"
                      type="number"
                      step="10"
                      min="0"
                      max="500"
                    />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Mô tả chi tiết</label>
                    <CTextarea rows="4" v-model="passPost.Car_detail" />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Ảnh xe</label>
                    <input
                      id="idphotoselector"
                      type="file"
                      multiple
                      horizontal
                      @change="onFileChange"
                    />
                  </CCol>
                </CRow>
              </fieldset>

              <!-- <CInput
                label="Tiêu đề"
                horizontal
                v-model="passPost.Post_title"
              /> -->

              <!-- <CInput
                label="Bảo hiểm dân sự"
                horizontal
                v-model="passPost.Post_car_civilcare"
              /> -->
              <!-- <CInput
                label="Bảo hiểm thân vỏ"
                horizontal
                v-model="passPost.Post_car_bodycare"
              /> -->

              <!-- <CInput label="Camera" horizontal v-model="passPost.Car_camera" /> -->
              <!-- <CInput
                label="Các linh kiện đã thay thế"
                horizontal
                v-model="passPost.Car_replaceditems"
              /> -->
              <!-- <CInput label="ảnh" horizontal v-model="passPost.Car_frontpic" /> -->
            </CCol>
            <CCol col="12" md="12" lg="6" sm="12">
              <!-- <CInput
                label="Ngày đăng"
                horizontal
                v-model="passPost.Car_date"
              /> -->
              <fieldset class="border p-4">
                <legend style="width:0;float-left">Ngoại thất</legend>
                <CInput v-model="passPost.Post_customer_id" hidden />
                <CRow>
                  <CCol>
                    <label>Độ mới(%)</label>
                    <input
                      class="form-control"
                      v-model="passPost.Car_cond"
                      type="number"
                      step="10"
                      min="0"
                      max="100"
                    />
                  </CCol>
                  <CCol>
                    <label>Thông số mâm xe</label>
                    <input class="form-control" v-model="passPost.Car_plate"
                  /></CCol>
                  <CCol>
                    <label>Thông số lốp xe</label>
                    <input class="form-control" v-model="passPost.Car_tire" />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol col="2">
                    <fieldset>
                      <legend class="h6 pl-2">Màu xe</legend>
                      <CCol class="form-inline">
                        <v-input-colorpicker
                          id="id_outcolor"
                          class="form-control rounded"
                          background-color="light"
                          v-model.trim="passPost.Car_outcolor"
                        />
                      </CCol>
                    </fieldset>
                    <!-- <input class="form-control" v-model="passPost.Car_outcolor" /> -->
                  </CCol>
                  <CCol>
                    <fieldset>
                      <legend class="h6 pl-2">Camera</legend>
                      <CCol class="form-inline">
                        <CInputRadio
                          class="pr-5"
                          v-for="(option, optionIndex) in cameras"
                          :key="option"
                          :label="option"
                          type="radio"
                          :value="optionIndex"
                          :custom="true"
                          name="usertype"
                          @update:checked="passPost.Car_camera = option"
                        />
                      </CCol>
                    </fieldset>
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Loại cửa</label>
                    <select
                      class="custom-select form-control"
                      v-model="passPost.Car_doortype"
                    >
                      <option value="Cửa hit">Cửa hit</option>
                      <option value="Cửa thông thường">Cửa thông thường</option>
                      <option value="Khác">Khác...</option>
                    </select>
                  </CCol>
                  <CCol>
                    <label>Loại gương</label>
                    <select
                      class="custom-select form-control"
                      v-model="passPost.Car_mirror"
                    >
                      <option value="Gương chỉnh cơ">Gương chỉnh cơ</option>
                      <option value="Gương chỉnh điện">Gương chỉnh điện</option>
                      <option value="Khác">Khác...</option>
                    </select>
                  </CCol>
                </CRow>
              </fieldset>

              <CRow>
                <fieldset class="border p-4 w-100 mt-2">
                  <legend style="width:0;float-left">Nội thất</legend>
                  <CRow>
                    <CCol col="2">
                      <label>Màu nội thất</label>
                      <!-- <input
                    class="form-control"
                    v-model.trim="passPost.Car_incolor"
                /> -->
                      <v-input-colorpicker
                        class="form-control rounded"
                        id="id_incolor"
                        v-model.trim="passPost.Car_incolor"
                        background-color="light"
                      />
                    </CCol>
                    <CCol>
                      <label>Hệ thống âm thanh</label>
                      <input
                        class="form-control"
                        v-model="passPost.Car_sound"
                      />
                    </CCol>
                    <CCol>
                      <label>Loại ghế</label>
                      <select
                        class="custom-select form-control"
                        v-model="passPost.Car_seattype"
                      >
                        <option value="Ghế da">Ghế da</option>
                        <option value="Ghế nỉ">Ghế nỉ</option>
                        <option value="Khác">Khác...</option>
                      </select>
                    </CCol>
                  </CRow>
                </fieldset>
              </CRow>
              <CRow>
                <fieldset class="border p-4">
                  <legend style="width:0;float-left">
                    Bảo hiểm xe hiện tại
                  </legend>
                  <CInputCheckbox
                    column="3"
                    v-for="item in carCares"
                    :key="item"
                    :label="item"
                    :value="item"
                    inline="true"
                  />
                </fieldset>
              </CRow>
              <CRow>
                <CCol
                  ><fieldset class="border p-4">
                    <legend style="width:0;float-left">Trang bị đi kèm</legend>
                    <CInputCheckbox v-model="passPost.Car_gps" label="GPS" />
                    <CInputCheckbox
                      v-model="passPost.Car_touchscreen"
                      label="Màn hình cảm ứng"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_skyview"
                      label="Cửa sổ trời"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_electrunk"
                      label="Cốp điện"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_cruisecontrol"
                      label="Kiểm soát hành trình"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_tirepressurealert"
                      label="Cảnh báo áp suất lốp"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_electricbalance"
                      label="Cân bằng điện tử (ESP)"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_blindalert"
                      label="Cảnh báo điểm mù"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_distancesensor"
                      label="Cảm biến khoảng cách"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_acrosshillsupport"
                      label="Hỗ trợ khởi hành ngang dốc"
                    />
                    <CInputCheckbox
                      v-model="passPost.Car_autoairconditioner"
                      label="Điều hòa không khí tự động"
                    /></fieldset
                ></CCol>
                <CCol>
                  <fieldset class="border p-4">
                    <legend style="width:0;float-left">
                      Linh kiện thay thế
                    </legend>
                    <CInputCheckbox
                      v-for="item in replacedItems"
                      :key="item"
                      :label="item"
                      :value="item"
                    />
                  </fieldset>
                </CCol>
              </CRow>
            </CCol>
          </CRow>
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton
            color="info"
            v-if="passPost.Post_id == 0"
            @click="insertClick(passPost)"
          >
            Thêm
          </CButton>
          <CButton
            color="info"
            v-if="passPost.Post_id != 0"
            @click="updateClick(passPost)"
          >
            Cập nhật
          </CButton>
          <CButton type="reset" color="danger"> Reset </CButton>
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
import InputColorPicker from "vue-native-color-picker";
import axios from "axios";
import { freeSet } from "@coreui/icons";
import { Domain } from "@/constant/constant";
import swal from "sweetalert2";
export default {
  name: "TheCreateEditCarversion",
  components: {
    "v-input-colorpicker": InputColorPicker,
  },
  props: {
    passPost: {
      type: Object,
      default: () => {},
    },
  },
  mounted() {
    this.getPostcars();
  },
  data() {
    return {
      filesToSave: { name: null, file: null },
      Selectpostcars: [],
      carUpdate: {},
      postlist: [],
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
      replacedItems: [
        "Lốp xe",
        "Lazang",
        "Gương",
        "Sơn",
        "Đèn",
        "Phanh",
        "Loa",
        "Màn hình",
        "Khác",
      ],
      cameras: ["Camera lùi", "Camera 180°", "Camera 360°"],
      carCares: [
        "Bảo hiểm thân vỏ",
        "Bảo hiểm trách nhiệm dân sự",
        "Bảo hiểm vật chất",
        "Bảo hiểm người ngồi trên xe",
        "Khác",
      ],
      carMirrors: ["Gương điện", "Gương tay"],
      domain: Domain,
      horizontal: { label: "col-6", input: "col-6" },
    };
  },
  methods: {
    onFileChange(e) {
      let formData = new FormData();
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;

      for (var i = 0; i < files.length; i++) {
        this.passPost.Car_frontpic += files[i].name + ",";
        this.postlist.push(files[i]);
        // this.filesToSave.file = files[0];
        //   formData.append("files[" + i + "]", files[i]);
        // console.log("hehe", this.formData.get("files[" + i + "]"));
      }
      //   this.passCarverion.Carversion_ManufacturerLogo = files[0].name;
    },
    getPostcars() {
      axios.get(this.domain + "Car/Get").then((res) => {
        this.Selectpostcars = res.data;
      });
    },
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    insertClick(value) {
      //   console.log("hehe", this.postlist);
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      var carSelect = $("#carSelector").val();
      var folderName = $("#carSelector")
        .find("option[value=" + carSelect + "]")
        .text()
        .replaceAll(" ", "")
        .replaceAll("\n", "");
      axios.post(this.domain + "Post/post", value).then((res) => {
        swal
          .fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          })
          .then((res) => {
            for (var i = 0; i < this.postlist.length; i++) {
              let formData = new FormData();
              formData.append("FilePath", folderName);
              formData.append("filePhotos", this.postlist[i]);
              axios
                .post(this.domain + "Post/SaveMultipleFile", formData, {
                  headers: {
                    "Content-Type": this.filesToSave.type,
                  },
                })
                .then((response) => {
                  console.log(response);
                });
              this.$emit("closeModal", false);
            }
          });
      });
      // }
    },
    // updateClick(value) {
    //   // this.accountname_valid = this.validator(this.passAccount.Account_name);
    //   // this.accountpassword_valid = this.validator(
    //   //   this.passAccount.Account_password
    //   // );
    //   // if (this.accountname_valid && this.accountpassword_valid) {
    //   value.Car_totaldimens =
    //     $("#idlength").val() +
    //     " x " +
    //     $("#idwidth").val() +
    //     " x " +
    //     $("#idheight").val();
    //   axios.put(this.domain + "Car/put", value).then((res) => {
    //     swal.fire({
    //       position: "center",
    //       icon: res.data.split("-")[0] == "1" ? "success" : "error",
    //       title: res.data.split("-")[1],
    //       showConfirmButton: false,
    //       timer: 1500,
    //     });
    //     this.$router.push("/Car/Car");
    //   });
    //   // }
    // },
  },
};
</script>
