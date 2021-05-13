<template>
  <div class="TheCustomer">
    <CCard>
      <CCardHeader>
        <h3>Quản lí người dùng</h3>
      </CCardHeader>
      <CCardBody class="text">
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
              {{ getDateFormat(item.Customer_birth) }}
            </td>
          </template>
          <template #Customer_begindate="{ item }">
            <td>
              {{ getDateFormat(item.Customer_begindate) }}
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
import TheCreateEditCustomer from "./TheCreateEditCustomer";

export default {
  name: "TheCustomer",
  freeSet,
  props: {
    dataCustomers: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    TheCreateEditCustomer,
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
  data() {
    return {
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
      customerUpdate: {},
      ModalTitle: null,
      infoModal: false,
    };
  },
  methods: {
    getDateFormat(date) {
      return date.length > 0 ? moment(date).format("YYYY/MM/DD") : "";
    },
  },
};
</script>