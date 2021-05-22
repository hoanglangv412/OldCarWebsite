<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <CRow style="height: 150px">
          <CCol col="10"> <h3>Quản lí dòng xe</h3></CCol>
          <CCol col="2">
            <CImg
              style="width: 200px; height: 130px"
              class="rounded"
              :src="this.carversion_photo"
            />
          </CCol>
        </CRow>
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
          <TheCreateEditCarversion
            :passCarverion="carversionUpdate"
            @closeModal="closeModal"
            :accountname_valid="null"
            :accountpassword_valid="null"
          />
          <div slot="footer" class="w-100 d-none"></div>
        </CModal>
        <CDataTable
          class="text-center"
          :items="dataCarversions"
          :fields="carversionItem"
          :items-per-page="6"
          table-filter
          clickable-rows
          hover
          pagination
          @row-clicked="handleFunction"
        >
          <template #Carversion_ManufacturerLogo="{ item }">
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
          </template>
          <template #method="{ item }">
            <td class="py-2">
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
            </td>
          </template>
        </CDataTable>
      </CCardBody>
    </CCard>
  </div>
</template>
<script>
import moment from "moment";
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";
import TheCreateEditCarversion from "./TheCreateEditCarversion";

export default {
  name: "TheCarversion",
  freeSet,
  props: {
    dataCarversions: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    TheCreateEditCarversion,
  },
  data() {
    return {
      carversionItem: [
        { key: "Carversion_id", label: "ID", _style: "min-width:100px;" },
        {
          key: "Carversion_ManufacturerLogo",
          label: "Logo",
          _style: "min-width:100px;",
        },
        {
          key: "Carversion_ManufacturerName",
          label: "Hãng xe",
          _style: "min-width:100px;",
        },
        {
          key: "Carversion_name",
          label: "Tên dòng xe",
          _style: "min-width:150px",
        },
        {
          key: "Carversion_date",
          label: "Đời",
          _style: "min-width:100px;",
        },
        {
          key: "Carversion_style",
          label: "Kiểu dáng",
          _style: "min-width:100px;",
        },
        {
          key: "Carversion_edition",
          label: "Phiên bản",
          _style: "min-width:150px",
        },
        {
          key: "Carversion_option",
          label: "Option",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Carversion_photo",
        //   label: "ảnh",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Carversion_adder",
          label: "Người tạo",
          _style: "min-width:100px;",
        },
        { key: "method", label: "Phương thức", _style: "min-width:100px;" },
      ],
      carversionUpdate: {},
      ModalTitle: null,
      infoModal: false,
      carversion_photo: null,
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
    getBadgeColor(Carversion_option) {
      return Carversion_option == "0"
        ? "primary"
        : Carversion_option == "1"
        ? "warning"
        : "success";
    },
    getRole(Carversion_option) {
      return Carversion_option == "0"
        ? "Standard"
        : Carversion_option == "1"
        ? "Advance"
        : "Full option";
    },
    deleteClick(ID) {
      swal
        .fire({
          title: "Bạn chắc chắn xóa dòng xe này?",
          text: "Dòng xe này sẽ bị xóa vĩnh viễn.",
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
              .delete("https://localhost:44343/Api/Carversion/Delete/" + ID)
              .then((res) => {
                this.$emit("getCarversion");
                swal.fire(
                  res.data.split("-")[1],
                  "Dòng xe này đã bị xóa.",
                  res.data.split("-")[0] == "1" ? "success" : "error"
                );
              });
          }
        });
    },
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
    updateClick(ID) {
      axios
        .get("https://localhost:44343/Api/Carversion/GetDataById/" + ID)
        .then((res) => {
          this.carversionUpdate = {
            Carversion_id: res.data[0].Carversion_id,
            Carversion_name: res.data[0].Carversion_name,
            Carversion_date: res.data[0].Carversion_date,
            Carversion_style: res.data[0].Carversion_style,
            Carversion_edition: res.data[0].Carversion_edition,
            Carversion_option: res.data[0].Carversion_option,
            Carversion_ManufacturerName:
              res.data[0].Carversion_ManufacturerName,
            Carversion_ManufacturerLogo:
              res.data[0].Carversion_ManufacturerLogo,
          };
        });
      (this.infoModal = true), (this.ModalTitle = "Cập nhật dòng xe");
    },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getCarversion");
    },
    takePhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/logo/" + value.split("~")[0]);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
    handleFunction: function (item) {
      console.log("hehehe", item.Carversion_photo);
      try {
        if (item != null) {
          this.carversion_photo = require("@/assets/Carversion/" +
            item.Carversion_photo);
        } else {
          this.carversion_photo = require("@/assets/img/nophoto.png");
        }
      } catch (e) {
        this.carversion_photo = require("@/assets/img/nophoto.png");
      }
    },
  },
};
</script>