<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <h3>Quản lí bài đăng</h3>
      </CCardHeader>
      <CCardBody class="text">
        <CButton
          color="info"
          to="/Post/CreateAndEditPost"
          class="m-2 btn-add float-right mr-5"
        >
          + Thêm
        </CButton>
        <!-- <CModal
          :title="ModalTitle"
          color="info"
          size="xl"
          :show.sync="infoModal"
        >
          <TheCreateAndEditCar
            :passCar="carUpdate"
            @closeModal="closeModal"
            :accountname_valid="null"
            :accountpassword_valid="null"
          />
          <div slot="footer" class="w-100 d-none"></div>
        </CModal> -->
        <CDataTable
          id="id_car"
          class="text-center text-nowrap"
          :items="dataPosts"
          :fields="postItem"
          :items-per-page="8"
          table-filter
          clickable-rows
          hover
          pagination
        >
          <template #Post_car_incolor="{ item }">
            <td>
              <input type="color" v-model="item.Post_incolor" disabled />
            </td>
          </template>
          <template #Post_car_outcolor="{ item }">
            <td>
              <input type="color" v-model="item.Post_outcolor" disabled />
            </td>
          </template>
          <template #Post_car_date="{ item }">
            <td>
              {{ formatDate(item.Post_car_date) }}
            </td>
          </template>
          <template #Post_car_km="{ item }">
            <td>{{ item.Post_car_km }} km</td>
          </template>
          <template #Post_car_like="{ item }">
            <td>
              <CBadge color="danger">
                {{ item.Post_car_like != null ? item.Post_car_like : "0" }}
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="currentColor"
                  class="bi bi-heart"
                  viewBox="0 0 16 16"
                >
                  <path
                    d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"
                  />
                </svg>
              </CBadge>
            </td>
          </template>
          <template #Post_car_price="{ item }">
            <td>
              {{ formatPrice(item.Post_car_price) }}
            </td>
          </template>
          <template #Post_car_sold="{ item }">
            <td>
              <CBadge :color="getBadgeColor(item.Post_car_sold)">
                {{ getSold(item.Post_car_sold) }}
              </CBadge>
            </td>
          </template>
          <template #method="{ item }">
            <td
              class="py-2 bg-white"
              style="position: sticky; right: 0; z-index: 1"
            >
              <CButton
                color="warning"
                class="btn-update"
                :to="`/Post/${item.Post_id}`"
              >
                <CIcon :content="$options.freeSet.cilPencil" />
              </CButton>
              <CButton
                color="danger"
                @click="deleteClick(item.Post_id)"
                class="btn-delete"
              >
                <CIcon :content="$options.freeSet.cilTrash" />
              </CButton>
              <CButton
                class="btn btn-outline-info"
                @click="viewDetail(item)"
              >
                Chi tiết
              </CButton>
            </td>
          </template>
        </CDataTable>
        <CModal
          :title="detailTitle"
          color="info"
          size="xl"
          :show.sync="infoModal"
        >
          <div class="p-0 rounded">
            <TheDetail
              :contactFlag="contactFlag"
              :buyFlag="buyFlag"
              :passPost="passPost"
              :carName="title"
              :passCar="passCar"
              @takePhoto="takePhoto"
            />
          </div>
        </CModal>
      </CCardBody>
    </CCard>
  </div>
</template>
<style scoped>
.text-nowrap {
  white-space: nowrap !important;
}
</style>
<script>
import moment from "moment";
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
import TheDetail from "../../components/Home/TheDetail";
export default {
  name: "ThePost",
  freeSet,
  props: {
    dataPosts: {
      type: Array,
      default: () => [],
    },
  },
  components: { TheDetail },
  data() {
    return {
      contactFlag: false,
      buyFlag: true,
      postItem: [
        { key: "Post_id", label: "ID", _style: "min-width:100px;" },
        // {
        //   key: "Post_customer_id",
        //   label: "Logo",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_id",
        //   label: "Hộp số",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Post_title",
          label: "Tiêu đề",
          _style: "min-width:150px",
        },
        {
          key: "Post_car_price",
          label: "Giá",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_origin",
          label: "Nguồn gốc",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_incolor",
          label: "Màu nội thất",
          _style: "min-width:150px",
        },
        {
          key: "Post_car_outcolor",
          label: "Màu xe",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Post_car_tire",
        //   label: "Thông số lốp xe",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_plate",
        //   label: "Thông số mâm xe",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Post_car_province",
          label: "Địa chỉ",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_km",
          label: "Số km đã đi",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Post_car_detail",
        //   label: "Mô tả chi tiết",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_kpl",
        //   label: "km/lít",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_cond",
        //   label: "Độ mới(%)",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_civilcare",
        //   label: "Bảo hiểm dân sự",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_bodycare",
        //   label: "Bảo hiểm thân vỏ",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_anothercare",
        //   label: "Bảo hiểm khác",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_frontpic",
        //   label: "Hệ thống phanh chân",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_leftpic",
        //   label: "Hệ thống phanh tay",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_rightpic",
        //   label: "Mức tiêu thụ nhiên liệu trong đô thị",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_behindpic",
        //   label: "Mức tiêu thụ nhiên loại ngoài đô thị",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_inpic",
        //   label: "Số túi khí",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_outpic",
        //   label: "Tên dòng xe",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_tirepic",
        //   label: "Đời",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_enginepic",
        //   label: "Kiểu dáng",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_trunkpic",
        //   label: "Phiên bản",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Post_car_replaceditems",
        //   label: "Các linh kiện đã thay thế",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Post_car_like",
          label: "Lượt yêu thích",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_date",
          label: "Ngày đăng",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Car_camera",
        //   label: "Camera",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_doortype",
        //   label: "Loại cửa",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_mirror",
        //   label: "Loại gương",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_seattype",
        //   label: "Loại ghế",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_sound",
        //   label: "Hệ thống âm thanh",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_gps",
        //   label: "GPS",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_touchscreen",
        //   label: "Màn cảm ứng",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_skyview",
        //   label: "Cửa sổ trời",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_electrunk",
        //   label: "Cốp điện",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_cruisecontrol",
        //   label: "Kiểm soát hành trình",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_tirepressurealert",
        //   label: "Cảnh báo áp suất lốp",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_electricbalance",
        //   label: "Cân bằng điện tử(ESP)",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_blindalert",
        //   label: "Cảnh báo điểm mù",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_distancesensor",
        //   label: "Cảm biển khoảng cách",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_camera360",
        //   label: "Camera 360",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_acrosshillsupport",
        //   label: "Hỗ trợ khởi hành ngang dốc",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_autoairconditioner",
        //   label: "Hệ thống điều hòa tự động",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Post_car_sold",
          label: "Đã bán",
          _style: "min-width:100px;",
        },
        {
          key: "method",
          label: "Phương thức",
          _style:
            "position: sticky; right: 0; z-index: 1;background-color:white",
        },
      ],
      domain: Domain,
      detailTitle: null,
      carUpdate: {},
      ModalTitle: null,
      infoModal: false,
      passPost: {},
      passCar: {},
      title: null,
    };
  },
  mounted() {
    //change search name
    $("label:contains('Filter:')").text("Tìm kiếm");
    //change search placeholder
    $("input")
      .filter(function () {
        return $(this).attr("placeholder") == "type string...";
      })
      .attr("placeholder", "Nhập từ khóa tìm kiếm");
  },
  methods: {
    getBadgeColor(value) {
      return value ? "danger" : "success";
    },
    getSold(value) {
      return value ? "Đã bán" : "Chưa bán";
    },
    formatDate(value) {
      if (value != undefined) {
        return value.substring(0, 10);
      }
    },
    formatPrice(value) {
      if (value != undefined) {
        var returnVal = value.toLocaleString("it-IT", {
          style: "currency",
          currency: "VND",
        });
        return returnVal;
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
    deleteClick(ID) {
      swal
        .fire({
          title: "Bạn chắc chắn xóa loại xe này?",
          text: "Loại xe này sẽ bị xóa vĩnh viễn.",
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
              .delete("https://localhost:44343/Api/Post/Delete/" + ID)
              .then((res) => {
                this.$emit("getPost");
                swal.fire(
                  res.data.split("-")[1],
                  res.data.split("-")[0] == "1" ? "Bài đăng đã bị xóa." : "",
                  res.data.split("-")[0] == "1" ? "success" : "error"
                );
              });
          }
        });
    },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getCar");
    },
  },
};
</script>