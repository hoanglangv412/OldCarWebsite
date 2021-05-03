<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <h3>Quản lí dòng xe</h3>
      </CCardHeader>
      <CCardBody class="text">
        <CButton
          color="info"
          to="/Post/CreateAndEditPost"
          class="m-2 btn-add float-right mr-5"
          @click="addClick()"
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
          <template #method="{ item }">
            <td
              class="py-2 bg-white"
              style="position: sticky; right: 0; z-index: 1"
            >
              <CButton
                color="warning"
                class="btn-update"
                :to="`/Post/${item.Post_id}`"
                @click="updateClick(item.Post_id)"
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
                color="info"
                variant="outline"
                square
                @click="toggleDetails(item, index)"
              >
                {{ Boolean(item._toggled) ? "Hide" : "Show" }}
              </CButton>
            </td>
          </template>
          <template #details="{ item }">
            <CCollapse
              :show="Boolean(item._toggled)"
              :duration="collapseDuration"
            >
              <CCardBody>
                <CRow>
                  <table
                    class="table border w-25"
                    style="
                      position: -webkit-sticky;
                      position: sticky;
                      left: 0;
                      z-index: 1;
                    "
                  >
                    <tr>
                      <td rowspan="4">
                        <CCard>
                          <CCardHeader>
                            <CCardImg
                              style="width: 250px; height: 180px"
                              class="rounded border-info"
                              :src="takePhoto(item.Post_car_frontpic)"
                            />
                          </CCardHeader>
                          <CCardBody>
                            <h6>
                              <!-- {{ item.Carversion_ManufacturerName }}
                              {{ item.Carversion_name }}
                              {{ item.Carversion_edition }}
                              {{ item.Carversion_style }}
                              {{ item.Carversion_date }} -->
                            </h6>
                            <p class="text-monospace">
                              Option:
                              <!-- {{ getRole(item.Carversion_option) }} -->
                            </p>
                          </CCardBody>
                        </CCard>
                      </td>
                      <!-- <td>Dài x Rộng x Cao(mm)</td>
                      <td>{{ item.Car_totaldimens }}</td>
                      <td class="border-left">Trọng tải</td>
                      <td>{{ item.Car_loadweight }}</td> -->
                    </tr>
                    <!-- <tr>
                      <td>Chiều dài cơ sở</td>
                      <td>{{ item.Car_baselength }}mm</td>
                      <td class="border-left">Số cửa</td>
                      <td>{{ item.Car_doors }}</td>
                    </tr>
                    <tr>
                      <td>Bán kính quay vòng</td>
                      <td>{{ item.Car_turnradius }}mm</td>
                      <td class="border-left">Số ghế</td>
                      <td>{{ item.Car_seats }}</td>
                    </tr>
                    <tr>
                      <td>Khoảng sáng gầm xe</td>
                      <td>{{ item.Car_height }}mm</td>
                      <td class="border-left">Số túi khí</td>
                      <td>{{ item.Car_airnums }}</td>
                    </tr> -->
                  </table>
                </CRow>
              </CCardBody>
            </CCollapse>
          </template>
        </CDataTable>
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

export default {
  name: "ThePost",
  freeSet,
  props: {
    dataPosts: {
      type: Array,
      default: () => [],
    },
  },
  components: {},
  data() {
    return {
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
        {
          key: "Post_car_tire",
          label: "Thông số lốp xe",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_plate",
          label: "Thông số mâm xe",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_province",
          label: "Nơi đăng kí biển",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_km",
          label: "Số km đã đi",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_detail",
          label: "Mô tả chi tiết",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_kpl",
          label: "km/lít",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_cond",
          label: "Độ mới(%)",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_civilcare",
          label: "Bảo hiểm dân sự",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_bodycare",
          label: "Bảo hiểm thân vỏ",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_anothercare",
          label: "Bảo hiểm khác",
          _style: "min-width:100px;",
        },
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
        {
          key: "Post_car_replaceditems",
          label: "Các linh kiện đã thay thế",
          _style: "min-width:100px;",
        },
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
        {
          key: "Car_camera",
          label: "Camera",
          _style: "min-width:100px;",
        },
        {
          key: "Car_doortype",
          label: "Loại cửa",
          _style: "min-width:100px;",
        },
        {
          key: "Car_mirror",
          label: "Loại gương",
          _style: "min-width:100px;",
        },
        {
          key: "Car_seattype",
          label: "Loại ghế",
          _style: "min-width:100px;",
        },
        {
          key: "Car_sound",
          label: "Hệ thống âm thanh",
          _style: "min-width:100px;",
        },
        {
          key: "Car_gps",
          label: "GPS",
          _style: "min-width:100px;",
        },
        {
          key: "Car_touchscreen",
          label: "Màn cảm ứng",
          _style: "min-width:100px;",
        },
        {
          key: "Car_skyview",
          label: "Cửa sổ trời",
          _style: "min-width:100px;",
        },
        {
          key: "Car_electrunk",
          label: "Cốp điện",
          _style: "min-width:100px;",
        },
        {
          key: "Car_cruisecontrol",
          label: "Kiểm soát hành trình",
          _style: "min-width:100px;",
        },
        {
          key: "Car_tirepressurealert",
          label: "Cảnh báo áp suất lốp",
          _style: "min-width:100px;",
        },
        {
          key: "Car_electricbalance",
          label: "Cân bằng điện tử(ESP)",
          _style: "min-width:100px;",
        },
        {
          key: "Car_blindalert",
          label: "Cảnh báo điểm mù",
          _style: "min-width:100px;",
        },
        {
          key: "Car_distancesensor",
          label: "Cảm biển khoảng cách",
          _style: "min-width:100px;",
        },
        {
          key: "Car_camera360",
          label: "Camera 360",
          _style: "min-width:100px;",
        },
        {
          key: "Car_acrosshillsupport",
          label: "Hỗ trợ khởi hành ngang dốc",
          _style: "min-width:100px;",
        },
        {
          key: "Car_autoairconditioner",
          label: "Hệ thống điều hòa tự động",
          _style: "min-width:100px;",
        },
        {
          key: "method",
          label: "Phương thức",
          _style:
            "position: sticky; right: 0; z-index: 1;background-color:white",
        },
      ],
      carUpdate: {},
      ModalTitle: null,
      infoModal: false,
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
    getRole(Carversion_option) {
      return Carversion_option == "0"
        ? "Standard"
        : Carversion_option == "1"
        ? "Advance"
        : "Full option";
    },
    toggleDetails(item) {
      this.$set(item, "_toggled", !item._toggled);
      this.collapseDuration = 300;
      this.$nextTick(() => {
        this.collapseDuration = 0;
      });
    },
    takePhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/Carversion/" + value);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
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
                  res.data.split("-")[0] == "1"
                    ? "Loại xe này đã bị xóa khỏi danh sách."
                    : "Tồn tại bài đăng đang sử dụng loại xe này",
                  res.data.split("-")[0] == "1" ? "success" : "error"
                );
              });
          }
        });
    },
    addClick() {},
    updateClick(ID) {},
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getCar");
    },
  },
};
</script>