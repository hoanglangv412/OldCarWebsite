<template>
  <div class="TheCarversion">
    <CCard>
      <CCardHeader>
        <CRow>
          <CCol col="10"> <h3>Danh sách bài đăng hiện tại</h3></CCol>
        </CRow>
      </CCardHeader>
      <CCardBody class="text">
        <div class="row">
          <div class="col">
            <CCallout color="danger">
              <small class="text-muted">Lượng bài đăng bán được</small><br />
              <strong class="h4">{{ soldCount }}</strong>
            </CCallout>
          </div>
          <div class="col">
            <CCallout color="warning">
              <small class="text-muted">Lượng bài đăng chưa bán</small><br />
              <strong class="h4">{{ unsoldCount }}</strong>
            </CCallout>
          </div>
          <div class="col">
            <CCallout color="info">
              <small class="text-muted">Số lượng bài đăng</small><br />
              <strong class="h4">{{ dataPosts.length }}</strong>
            </CCallout>
          </div>
          <div class="col">
            <CCallout color="info">
              <small class="text-muted">Bài đăng được quan tâm nhiều nhất</small
              ><br />
              <strong class="h4">
                <CBadge color="danger">
                  {{
                    mostLikeItem.Post_car_like != null
                      ? mostLikeItem.Post_car_like
                      : "0"
                  }}
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
                <CButton
                  class="btn btn-outline-info"
                  @click="viewDetail(mostLikeItem)"
                >
                  Chi tiết
                </CButton></strong
              >
            </CCallout>
          </div>
        </div>
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
        <CDataTable
          id="tablecute"
          class=""
          :items="dataPosts"
          :fields="carversionItem"
          :items-per-page="6"
          table-filter
          clickable-rows
          hover
          pagination
          @row-clicked="handleFunction"
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
          <template #Post_car_date="{ item }">
            <td>
              {{ formatDate(item.Post_car_date) }}
            </td>
          </template>
          <template #Post_car_sold="{ item }">
            <td>
              <CBadge :color="getBadgeColor(item.Post_car_sold)">
                {{ getSold(item.Post_car_sold) }}
              </CBadge>
            </td>
          </template>
        </CDataTable>
      </CCardBody>
    </CCard>
    <CCard>
      <CCardHeader>
        <CRow>
          <CCol col="10"> <h3>Danh sách người dùng hiện tại</h3></CCol>
        </CRow>
      </CCardHeader>
      <CCardBody class="text">
        <CCallout color="info">
          <small class="text-muted">Lượng người dùng hiện tại</small><br />
          <strong class="h4">{{ dataCustomers.length }}</strong>
        </CCallout>

        <CDataTable
          :items="dataCustomers"
          :fields="customerItem"
          :items-per-page="8"
          table-filter
          clickable-rows
          hover
          pagination
        >
          <template #Customer_birth="{ item }">
            <td>
              {{ formatDate(item.Customer_birth) }}
            </td>
          </template>
          <template #Customer_begindate="{ item }">
            <td>
              {{ formatDate(item.Customer_begindate) }}
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
import TheDetail from "../../components/Home/TheDetail";

export default {
  name: "TheCarversion",
  freeSet,
  props: {
    soldCount: String,
    unsoldCount: String,
    dataPosts: {
      type: Array,
      default: () => [],
    },
    mostLikeItem: {
      type: Object,
      default: () => {},
    },
    dataCustomers: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    TheDetail,
  },
  data() {
    return {
      contactFlag: false,
      buyFlag: false,

      passPost: {},
      title: null,
      carversionItem: [
        {
          key: "Car_name",
          label: "Tên xe ",
          _style: "min-width:100px;",
        },
        {
          key: "Customer_name",
          label: "Người bán",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_like",
          label: "Lượt thích",
          _style: "min-width:150px",
        },
        {
          key: "Post_car_sold",
          label: "Đã bán",
          _style: "min-width:100px;",
        },
        {
          key: "Post_car_date",
          label: "Ngày đăng",
          _style: "min-width:100px;",
        },
      ],

      customerItem: [
        { key: "Customer_id", label: "ID", _style: "min-width:100px;" },
        {
          key: "Customer_name",
          label: "Tên người dùng",
          _style: "min-width:100px;",
        },
        // {
        //   key: "Customer_birth",
        //   label: "Ngày sinh",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Customer_email",
          label: "Email",
          _style: "min-width:150px",
        },
        // {
        //   key: "Customer_address",
        //   label: "Địa chỉ",
        //   _style: "min-width:100px;",
        // },
        // {
        //   key: "Customer_phone",
        //   label: "Số điện thoại",
        //   _style: "min-width:100px;",
        // },
        {
          key: "Customer_begindate",
          label: "Ngày lập",
          _style: "min-width:100px;",
        },
      ],
      title: null,
      passCar: {},
      detailTitle: {},
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
    formatDate(value) {
      if (value != undefined) {
        return value.substring(0, 10);
      }
    },
    getBadgeColor(value) {
      return value ? "danger" : "success";
    },
    getSold(value) {
      return value ? "Đã bán" : "Chưa bán";
    },
  },
};
</script>