<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <h3>Quản lí dòng xe</h3>
      </CCardHeader>
      <CCardBody class="text">
        <CButton
          color="info"
          class="m-2 btn-add float-right mr-5"
          @click="addClick()"
        >
          Thêm +
        </CButton>
        <CModal
          :title="ModalTitle"
          color="info"
          size="lg"
          :show.sync="infoModal"
        >
          <test />
          <div slot="footer" class="w-100 d-none"></div>
        </CModal>
        <CDataTable
          id="id_car"
          class="text-center text-nowrap"
          :items="dataCars"
          :fields="carItem"
          :items-per-page="8"
          table-filter
          clickable-rows
          hover
          pagination
        >
          <!-- <template #Carversion_ManufacturerLogo="{ item }">
            <td style="height: 10px; width: 10px">
              <CImg
                :src="takePhoto(item.Carversion_ManufacturerLogo)"
                block
                class="card-img-top"
              />
            </td>
          </template>
          <template #Carversion_option="{ item }">
            <td>
              <CBadge :color="getBadgeColor(item.Carversion_option)">
                {{ getRole(item.Carversion_option) }}
              </CBadge>
            </td>
          </template> -->
          <template #method="{ item }" style="overflow: auto">
            <td class="py-2 bg-white" style="position: sticky; right: 0; z-index: 1">
              <CButton
                color="warning"
                class="btn-update"
                @click="updateClick(item.Carversion_id)"
              >
                <CIcon :content="$options.freeSet.cilPencil" />
              </CButton>
              <CButton
                color="danger"
                @click="deleteClick(item.Carversion_id)"
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
                <CMedia :aside-image-props="{ height: 102 }">
                  <h4>
                    <!-- {{ item.username }} -->
                  </h4>
                  <!-- <p class="text-muted">User since: {{ item.registered }}</p> -->
                  <CButton size="sm" color="info" class="">
                    User Settings
                  </CButton>
                  <CButton size="sm" color="danger" class="ml-1">
                    Delete
                  </CButton>
                </CMedia>
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
import test from "./test";

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
    test,
  },
  data() {
    return {
      carItem: [
        { key: "Car_id", label: "ID", _style: "min-width:100px;" },
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
        {
          key: "Car_seats",
          label: "Số ghế",
          _style: "min-width:100px;",
        },
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
          key: "Car_maxpower",
          label: "Công suất cực đại",
          _style: "min-width:100px;",
        },
        {
          key: "Car_loadweight",
          label: "Trọng tải",
          _style: "min-width:100px;",
        },
        {
          key: "Car_doors",
          label: "Số cửa",
          _style: "min-width:100px;",
        },
        {
          key: "Car_drivetype",
          label: "Hệ truyền động",
          _style: "min-width:100px;",
        },
        {
          key: "Car_totaldimens",
          label: "Kích thước tổng thể",
          _style: "min-width:100px;",
        },
        {
          key: "Car_baselength",
          label: "Chiều dài cơ sở",
          _style: "min-width:100px;",
        },
        {
          key: "Car_turnradius",
          label: "Bán kính quay vòng",
          _style: "min-width:100px;",
        },
        {
          key: "Car_height",
          label: "Khoảng sáng gầm xe",
          _style: "min-width:100px;",
        },
        {
          key: "Car_cylcapacity",
          label: "Dung tích xi lanh",
          _style: "min-width:100px;",
        },
        {
          key: "Car_brakesystem",
          label: "Hệ thống phanh",
          _style: "min-width:100px;",
        },
        {
          key: "Car_fuelsystem",
          label: "Hệ thống nhiên liệu",
          _style: "min-width:100px;",
        },
        {
          key: "Car_airnums",
          label: "Số túi khí",
          _style: "min-width:100px;",
        },
        {
          key: "method",
          label: "Phương thức",
          _style:
            "position: sticky; right: 0; z-index: 1;background-color:white",
        },
      ],
      carversionUpdate: {},
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
    // //table sizing td,th
    // $("table ")
    //   .filter(function () {
    //     return $(this).attr("placeholder") == "type string...";
    //   })
    //   .attr("placeholder", "Nhập từ khóa tìm kiếm");
  },
  methods: {
    toggleDetails(item) {
      this.$set(item, "_toggled", !item._toggled);
      this.collapseDuration = 300;
      this.$nextTick(() => {
        this.collapseDuration = 0;
      });
    },
    // getBadgeColor(Carversion_option) {
    //   return Carversion_option == "0"
    //     ? "primary"
    //     : Carversion_option == "1"
    //     ? "warning"
    //     : "success";
    // },
    // getRole(Carversion_option) {
    //   return Carversion_option == "0"
    //     ? "Standard"
    //     : Carversion_option == "1"
    //     ? "Advance"
    //     : "Full option";
    // },
    // deleteClick(ID) {
    //   swal
    //     .fire({
    //       title: "Bạn chắc chắn xóa dòng xe này?",
    //       text: "Dòng xe này sẽ bị xóa vĩnh viễn.",
    //       icon: "warning",
    //       showCancelButton: true,
    //       confirmButtonColor: "#3085d6",
    //       cancelButtonColor: "#d33",
    //       confirmButtonText: "Chắn chắn",
    //       cancelButtonText: "Không",
    //     })
    //     .then((result) => {
    //       if (result.isConfirmed) {
    //         axios
    //           .delete("https://localhost:44343/Api/Carversion/Delete/" + ID)
    //           .then((res) => {
    //             this.$emit("getCarversion");
    //             swal.fire(
    //               res.data.split("-")[1],
    //               "Dòng xe này đã bị xóa.",
    //               res.data.split("-")[0] == "1" ? "success" : "error"
    //             );
    //           });
    //       }
    //     });
    // },
    addClick() {
      (this.carversionUpdate = {
        Carversion_id: 0,
        Carversion_name: "",
        Carversion_date: "",
        Carversion_style: "",
        Carversion_edition: "",
        Carversion_option: "",
        Carversion_ManufacturerName: "",
        Carversion_ManufacturerLogo: "",
      }),
        (this.infoModal = true),
        (this.ModalTitle = "Thêm dòng xe");
    },
    // updateClick(ID) {
    //   axios
    //     .get("https://localhost:44343/Api/Carversion/GetDataById/" + ID)
    //     .then((res) => {
    //       this.carversionUpdate = {
    //         Carversion_id: res.data[0].Carversion_id,
    //         Carversion_name: res.data[0].Carversion_name,
    //         Carversion_date: res.data[0].Carversion_date,
    //         Carversion_style: res.data[0].Carversion_style,
    //         Carversion_edition: res.data[0].Carversion_edition,
    //         Carversion_option: res.data[0].Carversion_option,
    //         Carversion_ManufacturerName:
    //           res.data[0].Carversion_ManufacturerName,
    //         Carversion_ManufacturerLogo:
    //           res.data[0].Carversion_ManufacturerLogo,
    //       };
    //     });
    //   (this.infoModal = true), (this.ModalTitle = "Cập nhật dòng xe");
    // },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getCar");
    },
    // takePhoto(value) {
    //   if (value) {
    //     var images;
    //     try {
    //       images = require("@/assets/logo/" + value.split("~")[0]);
    //     } catch (e) {
    //       images = require("@/assets/img/nophoto.png");
    //     }
    //     return images;
    //   }
    // },
  },
};
</script>