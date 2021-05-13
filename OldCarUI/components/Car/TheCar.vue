<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <h3>Quản lí xe</h3>
      </CCardHeader>
      <CCardBody class="text">
        <CButton
          color="info"
          to="/Car/CreateAndEditCar"
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
          class="text-nowrap"
          :items="dataCars"
          :fields="carItem"
          :items-per-page="8"
          table-filter
          clickable-rows
          hover
          pagination
        >
          <template #Car_name="{ item }">
            <td>
              <h6>
                {{ item.Carversion_ManufacturerName }}
                {{ item.Carversion_name }}
                {{ item.Carversion_edition }}
                {{ item.Carversion_style }}
                {{ item.Carversion_date }}
              </h6>
            </td>
          </template>
          <template #Car_maxspeed="{ item }">
            <td>{{ item.Car_maxspeed }} km/h</td>
          </template>
          <template #Car_acceleration="{ item }">
            <td>{{ item.Car_acceleration }}</td>
          </template>
          <template #Car_maxpower="{ item }">
            <td style="height: 10px; width: 10px">
              {{ item.Car_maxpower }}
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
                :to="`/Car/${item.Car_id}`"
                @click="updateClick(item.Car_id)"
              >
                <CIcon :content="$options.freeSet.cilPencil" />
              </CButton>
              <CButton
                color="danger"
                @click="deleteClick(item.Car_id)"
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
                              :src="takePhoto(item.Carversion_photo)"
                            />
                          </CCardHeader>
                          <CCardBody>
                            <h6>
                              {{ item.Carversion_ManufacturerName }}
                              {{ item.Carversion_name }}
                              {{ item.Carversion_edition }}
                              {{ item.Carversion_style }}
                              {{ item.Carversion_date }}
                            </h6>
                            <p class="text-monospace">
                              Option:
                              {{ getRole(item.Carversion_option) }}
                            </p>
                          </CCardBody>
                        </CCard>
                      </td>
                      <td>Dài x Rộng x Cao(mm)</td>
                      <td>{{ item.Car_totaldimens }}</td>
                      <td class="border-left">Trọng tải</td>
                      <td>{{ item.Car_loadweight }}</td>
                    </tr>
                    <tr>
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
                    </tr>
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
import Table from "~/pages/base/Table.vue";
import TheCreateAndEditCar from "./TheCreateAndEditCar";

export default {
  name: "TheCarversion",
  freeSet,
  props: {
    dataCars: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    TheCreateAndEditCar,
  },
  data() {
    return {
      carItem: [
        { key: "Car_id", label: "ID", _style: "min-width:100px;" },
        { key: "Car_name", label: "Tên xe", _style: "min-width:100px;" },
        // {
        //   key: "Car_carversion_id",
        //   label: "Logo",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Car_trans",
          label: "Hộp số",
          _style: "min-width:100px;",
        },
        {
          key: "Car_fuel",
          label: "Nhiên liệu",
          _style: "min-width:150px",
        },
        {
          key: "Car_engine",
          label: "Động cơ",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Car_seats",
        //   label: "Số ghế",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Car_maxmomen",
          label: "Momen xoắn cực đại",
          _style: "min-width:150px",
        },
        {
          key: "Car_maxspeed",
          label: "Vận tốc tối đa",
          _style: "min-width:100px;",
        },
        {
          key: "Car_acceleration",
          label: "Tăng tốc",
          _style: "min-width:100px;",
        },
        {
          key: "Car_maxpower",
          label: "Công suất cực đại",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Car_loadweight",
        //   label: "Trọng tải",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_doors",
        //   label: "Số cửa",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Car_drivetype",
          label: "Hệ truyền động",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Car_totaldimens",
        //   label: "Kích thước tổng thể",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_baselength",
        //   label: "Chiều dài cơ sở",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_turnradius",
        //   label: "Bán kính quay vòng",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Car_height",
        //   label: "Khoảng sáng gầm xe",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Car_cylcapacity",
          label: "Dung tích xi lanh",
          _style: "min-width:100px;",
        },
        {
          key: "Car_brakesystem",
          label: "Hệ thống phanh chân",
          _style: "min-width:100px;",
        },
        {
          key: "Car_handbrake",
          label: "Hệ thống phanh tay",
          _style: "min-width:100px;",
        },
        {
          key: "Car_cityfuelconsump",
          label: "Mức tiêu thụ nhiên liệu trong đô thị",
          _style: "min-width:100px;",
        },
        {
          key: "Car_highwayfuelconsump",
          label: "Mức tiêu thụ nhiên loại ngoài đô thị",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Car_airnums",
        //   label: "Số túi khí",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_name",
        //   label: "Tên dòng xe",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_date",
        //   label: "Đời",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_style",
        //   label: "Kiểu dáng",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_edition",
        //   label: "Phiên bản",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_option",
        //   label: "Option",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_ManufacturerName",
        //   label: "Tên hãng sản xuất",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_ManufacturerLogo",
        //   label: "Logo",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Carversion_photo",
        //   label: "Photo",
        //   _style: "min-width:100px;",
        // },
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
              .delete("https://localhost:44343/Api/Car/Delete/" + ID)
              .then((res) => {
                this.$emit("getCar");
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
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getCar");
    },
  },
};
</script>