<template>
  <div class="TheCustomer">
    <CRow>
      <CCol col="10"
        ><CCard>
          <CCardHeader>
            <h1>Tạo đơn mua bán</h1>
          </CCardHeader>
          <CCardBody>
            <CInput v-model="passPost.Post_id" hidden />
            <table class="table">
              <tr>
                <td>Bài đăng:</td>
                <td>{{ passPost.Post_title }}</td>
                <td>
                  <CButton
                    class="btn btn-outline-info float-right"
                    @click="viewDetail(passPost)"
                  >
                    Chi tiết
                  </CButton>
                </td>
              </tr>
              <tr>
                <td>Người mua:</td>
                <td>
                  <div class="row">
                    <div class="col-3">
                      <input
                        type="radio"
                        name="customer_selector"
                        id="email"
                        checked="true"
                      /><label for="email" class="pl-2">Email</label><br />
                      <input
                        type="radio"
                        name="customer_selector"
                        id="Phone"
                      /><label for="Phone" class="pl-2">Số điện thoại</label>
                    </div>

                    <div class="col">
                      <input
                        type="text"
                        class="form-control"
                        placeholder="Nhập số điện thoại hoặc email người mua"
                        id="id_customer_buy"
                        @change="onCustomerChange()"
                      />
                    </div>
                  </div>
                </td>
              </tr>
              <tr>
                <td>Ngày:</td>
                <td>
                  <input
                    :value="moment().format('MMMM Do YYYY, h:mm a')"
                    horizontal
                    disabled
                  />
                </td>
              </tr>
            </table>
          </CCardBody>
          <CCardFooter>
            <CButton
              class="float-right"
              color="info"
              @click="insertClick(passPost)"
            >
              Tạo
            </CButton>
          </CCardFooter></CCard
        ></CCol
      >
    </CRow>
    <CModal :title="detailTitle" color="info" size="xl" :show.sync="infoModal">
      <div class="p-0 rounded">
        <TheDetail
          :contactFlag="contactFlag"
          :passPost="passPost"
          :carName="title"
          :passCar="passCar"
          @takePhoto="takePhoto"
        />
      </div>
    </CModal>
  </div>
</template>
<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import { Domain } from "@/constant/constant";
import swal from "sweetalert2";
import TheDetail from "../../components/Home/TheDetail";
import ThePost from "~/components/Post/ThePost";
export default {
  name: "TheCustomer",
  freeSet,
  props: {
    passPost: {},
  },
  components: { TheDetail, ThePost },
  data() {
    return {
      customerInfo: {},
      contactFlag: false,
      buyFlag: false,
      domain: Domain,
      infoModal: false,
      title: null,
      passPost: {},
      detailTitle: null,
      passCar: {},
      postUpdate: {},
    };
  },
  methods: {
    onCustomerChange(e) {
      if ($("#email").prop("checked")) {
        try {
          axios
            .get(
              this.domain +
                "Customer/GetDataByEmail/" +
                $("#id_customer_buy").val().split(".")[0]
            )
            .then((res) => {
              this.customerInfo = {
                Customer_id: res.data[0].Customer_id,
                Customer_avatar: res.data[0].Customer_avatar,
                Customer_name: res.data[0].Customer_name,
                Customer_birth: res.data[0].Customer_birth,
                Customer_email: res.data[0].Customer_email,
                Customer_address: res.data[0].Customer_address,
                Customer_phone: res.data[0].Customer_phone,
                Customer_begindate: res.data[0].Customer_begindate,
                Account_name: res.data[0].Account_name,
                Account_password: res.data[0].Account_password,
                Account_role: res.data[0].Account_role,
                Account_lastLogin: res.data[0].Account_lastLogin,
              };
            });
        } catch (e) {
          alert(e);
        }
      } else {
        try {
          axios
            .get(
              this.domain +
                "Customer/GetDataByPhone/" +
                $("#id_customer_buy").val()
            )
            .then((res) => {
              this.customerInfo = {
                Customer_id: res.data[0].Customer_id,
                Customer_avatar: res.data[0].Customer_avatar,
                Customer_name: res.data[0].Customer_name,
                Customer_birth: res.data[0].Customer_birth,
                Customer_email: res.data[0].Customer_email,
                Customer_address: res.data[0].Customer_address,
                Customer_phone: res.data[0].Customer_phone,
                Customer_begindate: res.data[0].Customer_begindate,
                Account_name: res.data[0].Account_name,
                Account_password: res.data[0].Account_password,
                Account_role: res.data[0].Account_role,
                Account_lastLogin: res.data[0].Account_lastLogin,
              };
            });
        } catch (e) {
          alert(e);
        }
      }
    },
    insertClick(value) {
      if (value != undefined) {
        value.Contract_customerBuy_id = this.customerInfo.Customer_id;
        value.Contract_customerSell_id = this.$auth.user;
        swal
          .fire({
            title:
              "Xác nhận bán xe này cho khách hàng: " +
              this.customerInfo.Customer_name +
              "?",
            text: "Bài đăng sẽ được ẩn trên website.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Chắn chắn",
            cancelButtonText: "Không",
          })
          .then((result) => {
            if (result.isConfirmed) {
              axios
                .post("https://localhost:44343/Api/Contract/Post/", value)
                .then((res) => {
                  swal.fire(
                    res.data.split("-")[1],
                    "",
                    res.data.split("-")[0] == "1" ? "success" : "error"
                  );
                });
              this.postUpdate = {
                Post_id: value.Post_id,
                Post_customer_id: null,
                Post_car_id: null,
                Post_title: null,
                Post_car_price: null,
                Post_car_origin: null,
                Post_car_incolor: null,
                Post_car_outcolor: null,
                Post_car_tire: null,
                Post_car_plate: null,
                Post_car_province: null,
                Post_car_km: null,
                Post_car_detail: null,
                Post_car_kpl: null,
                Post_car_cond: null,
                Post_car_anothercare: null,
                Post_car_frontpic: null,
                Post_car_replaceditems: null,
                Post_car_date: null,
                Car_camera: null,
                Car_doortype: null,
                Car_mirror: null,
                Car_seattype: null,
                Car_sound: null,
                Car_technology: null,
                Post_car_like: null,
                Post_car_sold: 1,
              };
              console.log("hahaha", this.postUpdate);
              axios
                .put("https://localhost:44343/Api/Post/Put/", this.postUpdate)
                .then(
                  this.$router.push("/Post/Post"),
                  // this.$root.$emit("getPost")
                );
            }
          });
      }
    },
    viewDetail(value) {
      if (value != undefined) {
        axios
          .get(this.domain + "Car/GetNameById/" + value.Post_car_id)
          .then((res) => {
            var carName =
              res.data[0].Carversion_ManufacturerName.trim() +
              " " +
              res.data[0].Carversion_name.trim() +
              " " +
              res.data[0].Carversion_date.trim();
            this.title = carName;
          });
        axios
          .get(this.domain + "Car/GetDataById/" + value.Post_car_id)
          .then((res) => {
            this.passCar = res.data[0];
          });
        (this.infoModal = true),
          (this.detailTitle = "Chi tiết xe"),
          (this.passPost = value);
      }
    },
  },
};
</script>