<template>
  <div>
    <CCol>
      <CForm class="form-insert-update">
        <CCardBody class="text-nowrap pt-0">
          <CRow>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border pl-4 pr-4">
                <legend style="width:0;float-left">Thông tin mô tả</legend>
                <CInput v-model="passPost.Post_id" hidden />
                <label>Tiêu đề</label>
                <input
                  class="form-control"
                  v-model="passPost.Post_title"
                  type="text"
                  horizontal
                  autocomplete="true"
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
                      v-model="passPost.Post_car_price"
                      type="number"
                      step="100000000"
                      min="0"
                      max="1000000000000"
                  /></CCol>
                  <CCol>
                    <label>Nguồn gốc</label>
                    <input
                      class="form-control"
                      v-model.trim="passPost.Post_car_origin"
                      autocomplete="true"
                  /></CCol>
                  <CCol>
                    <label>Nơi đăng kí biển</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_province"
                      list="cityNames"
                      autocomplete="true"
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
                    <div class="row">
                      <div class="col-2 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-10 pr-0 pl-0">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_km"
                          type="number"
                          step="1000"
                          min="0"
                          max="1000000"
                        />
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Số km đi được trên một lít xăng</label>
                    <div class="row">
                      <div class="col-2 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-10 pr-0 pl-0">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_kpl"
                          type="number"
                          step="10"
                          min="0"
                          max="500"
                        />
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Mô tả chi tiết</label>
                    <CTextarea rows="4" v-model="passPost.Post_car_detail" />
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
            </CCol>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border pl-4 pr-4 pb-4">
                <legend style="width:0;float-left">Ngoại thất</legend>
                <CInput v-model="passPost.Post_customer_id" hidden />
                <CRow>
                  <CCol>
                    <label>Độ mới(%)</label>
                    <div class="row">
                      <div class="col-3 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-9 pr-0 pl-0">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_cond"
                          type="number"
                          step="10"
                          min="0"
                          max="100"
                        />
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Thông số mâm xe</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_plate"
                      autocomplete="true"
                  /></CCol>
                  <CCol>
                    <label>Thông số lốp xe</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_tire"
                      autocomplete="true"
                    />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol col="3">
                    <fieldset>
                      <legend class="h6 pl-2">Màu xe</legend>
                      <CCol class="form-inline">
                        <input
                          type="color"
                          id="id_outcolor"
                          class="form-control w-75"
                          background-color="light"
                          v-model="passPost.Post_car_outcolor"
                        />
                        <!-- <v-input-colorpicker
                          id="id_outcolor"
                          class="form-control rounded"
                          background-color="light"
                          v-model.trim="passPost.Post_car_outcolor"
                        /> -->
                      </CCol>
                    </fieldset>
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
                <fieldset class="border pl-4 pr-4 pb-4 w-100 mt-2">
                  <legend style="width:0;float-left">Nội thất</legend>
                  <CRow>
                    <CCol col="2">
                      <label>Màu nội thất</label>
                      <input
                        type="color"
                        id="id_outcolor"
                        class="form-control"
                        background-color="light"
                        v-model="passPost.Post_car_incolor"
                      />
                      <!-- <v-input-colorpicker
                        class="form-control rounded"
                        id="id_incolor"
                        v-model.trim="passPost.Post_car_incolor"
                        background-color="light"
                      /> -->
                    </CCol>
                    <CCol>
                      <label>Hệ thống âm thanh</label>
                      <input
                        class="form-control"
                        v-model="passPost.Car_sound"
                        autocomplete="true"
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
                <fieldset class="border pl-4 pr-4 pb-4">
                  <legend style="width:0;float-left">Bảo hiểm xe</legend>
                  <input
                    type="checkbox"
                    id="cares_0"
                    value="Bảo hiểm thân vỏ"
                  />
                  <label for="cares_0" class="pr-4">Bảo hiểm thân vỏ</label>

                  <input
                    type="checkbox"
                    id="cares_1"
                    value="Bảo hiểm trách nhiệm dân sự"
                  />
                  <label for="cares_1" class="pr-4"
                    >Bảo hiểm trách nhiệm dân sự</label
                  >

                  <input
                    type="checkbox"
                    id="cares_2"
                    value="Bảo hiểm vật chất"
                  />
                  <label for="cares_2" class="pr-4">Bảo hiểm vật chất</label>
                  <input
                    type="checkbox"
                    id="cares_3"
                    value="Bảo hiểm người ngồi trên xe"
                  />
                  <label for="cares_3" class="pr-4"
                    >Bảo hiểm người ngồi trên xe</label
                  >
                </fieldset>
              </CRow>
              <CRow>
                <CCol col="7"
                  ><fieldset class="border pl-4 pr-4 pb-4">
                    <legend style="width:0;float-left">Trang bị đi kèm</legend>
                    <div class="row">
                      <div class="col-7">
                        <input type="checkbox" id="technology_0" value="GPS" />
                        <label for="technology_0">GPS</label><br />
                        <input
                          type="checkbox"
                          id="technology_1"
                          value="Màn hình cảm ứng"
                        />
                        <label for="technology_1">Màn hình cảm ứng</label><br />
                        <input
                          type="checkbox"
                          id="technology_2"
                          value="Cửa sổ trời"
                        />
                        <label for="technology_2">Cửa sổ trời</label><br />
                        <input
                          type="checkbox"
                          id="technology_3"
                          value="Kiểm soát hành trình"
                        />
                        <label for="technology_3">Kiểm soát hành trình</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_4"
                          value="Hỗ trợ khởi hành ngang dốc"
                        />
                        <label for="technology_4"
                          >Hỗ trợ khởi hành ngang dốc</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_5"
                          value="Điều hòa không khí tự động"
                        />
                        <label for="technology_5"
                          >Điều hòa không khí tự động</label
                        ><br />
                      </div>
                      <div class="col-5">
                        <input
                          type="checkbox"
                          id="technology_6"
                          value="Cốp điện"
                        />
                        <label for="technology_6">Cốp điện</label><br />
                        <input
                          type="checkbox"
                          id="technology_7"
                          value="Cảnh báo áp suất lốp"
                        />
                        <label for="technology_7">Cảnh báo áp suất lốp</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_8"
                          value="Cân bằng điện tử (ESP)"
                        />
                        <label for="technology_8">Cân bằng điện tử (ESP)</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_9"
                          value="Cảnh báo điểm mù"
                        />
                        <label for="technology_9">Cảnh báo điểm mù</label><br />
                        <input
                          type="checkbox"
                          id="technology_10"
                          value="Cảm biến khoảng cách"
                        />
                        <label for="technology_10">Cảm biến khoảng cách</label
                        ><br />
                      </div>
                    </div></fieldset
                ></CCol>
                <CCol col="5">
                  <fieldset class="border pl-4 pr-4 pb-4">
                    <legend style="width:0;float-left">
                      Linh kiện thay thế
                    </legend>
                    <input
                      type="checkbox"
                      id="replacedItem_0"
                      value="Lốp xe"
                    /><label for="replacedItem_0" class="pl-2"> Lốp xe </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_1"
                      value="Lazang"
                    /><label for="replacedItem_1" class="pl-2"> Lazang </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_2"
                      value="Gương"
                    /><label for="replacedItem_2" class="pl-2"> Gương </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_3"
                      value="Sơn"
                    /><label for="replacedItem_3" class="pl-2"> Sơn </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_4"
                      value="Đèn"
                    /><label for="replacedItem_4" class="pl-2"> Đèn </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_5"
                      value="Phanh"
                    /><label for="replacedItem_5" class="pl-2"> Phanh </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_6"
                      value="Loa"
                    /><label for="replacedItem_6" class="pl-2"> Loa </label
                    ><br />

                    <input
                      type="checkbox"
                      id="replacedItem_7"
                      value="Màn hình"
                    /><label for="replacedItem_7" class="pl-2"> Màn hình </label
                    ><br />
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
      photoNames: {},
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
      cameras: ["Camera lùi", "Camera 180°", "Camera 360°"],
      carMirrors: ["Gương điện", "Gương tay"],
      domain: Domain,
      horizontal: { label: "col-6", input: "col-6" },
    };
  },
  methods: {
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.photoNames = "";
      for (var i = 0; i < files.length; i++) {
        this.postlist.push(files[i]);
        var carSelect = $("#carSelector").val();
        var folderName = $("#carSelector")
          .find("option[value=" + carSelect + "]")
          .text()
          .replaceAll(" ", "")
          .replaceAll("\n", "");
        this.photoNames += folderName + "/" + files[i].name + ",";
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
      value.Post_car_replaceditems = "";
      value.Car_technology = "";
      value.Post_car_anothercare = "";
      for (var i = 0; i < 8; i++) {
        $("#replacedItem_" + i + "").prop("checked") == true
          ? (value.Post_car_replaceditems +=
              $("#replacedItem_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 10; i++) {
        $("#technology_" + i + "").prop("checked") == true
          ? (value.Car_technology += $("#technology_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 4; i++) {
        $("#cares_" + i + "").prop("checked") == true
          ? (value.Post_car_anothercare += $("#cares_" + i + "").val() + ", ")
          : "";
      }
      value.Post_car_like = 0;
      value.Post_car_date = 0;
      value.Post_car_frontpic = this.photoNames;
      value.Post_customer_id = this.$auth.user;
      value.Post_id = null;
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
      console.log("hehehehe", value);
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
