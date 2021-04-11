<template>
  <div class="TheCustomer">
    <CCard>
      <CCardHeader>
        <h3>Quản lí người dùng</h3>
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
          <TheCreateEditCustomer
            :passCustomer="customerUpdate"
            @closeModal="closeModal"
            :accountname_valid="null"
            :accountpassword_valid="null"
          />
          <div slot="footer" class="w-100 d-none"></div>
        </CModal>
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
          <template #method="{ item }">
            <td class="py-2">
              <CButton
                color="warning"
                class="btn-update"
                @click="updateClick(item.Customer_id)"
              >
                <CIcon :content="$options.freeSet.cilPencil" />
              </CButton>
              <CButton
                color="danger"
                @click="deleteClick(item.Customer_id)"
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
  data() {
    return {
      customerItem: [
        { key: "Customer_id", label: "ID", _style: "min-width:100px;" },
        {
          key: "Customer_avatar",
          label: "Avatar",
          _style: "min-width:150px",
        },
        {
          key: "Customer_name",
          label: "Tên người dùng",
          _style: "min-width:100px;",
        },
        {
          key: "Customer_birth",
          label: "Ngày sinh",
          _style: "min-width:100px;",
        },
        {
          key: "Customer_email",
          label: "Email",
          _style: "min-width:150px",
        },
        {
          key: "Customer_address",
          label: "Địa chỉ",
          _style: "min-width:100px;",
        },
        {
          key: "Customer_phone",
          label: "Số điện thoại",
          _style: "min-width:100px;",
        },
        {
          key: "Customer_begindate",
          label: "Ngày lập",
          _style: "min-width:100px;",
        },
        { key: "method", label: "Phương thức", _style: "min-width:100px;" },
      ],
      customerUpdate: {},
      ModalTitle: null,
      infoModal: false,
    };
  },
  methods: {
    deleteClick(ID) {
      swal
        .fire({
          title: "Bạn chắc chắn xóa người dùng này?",
          text: "Người dùng này sẽ bị xóa vĩnh viễn.",
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
              .delete("https://localhost:44343/OldCar/Customer/" + ID)
              .then((res) => {
                this.$emit("getListCustomers");
                swal.fire(
                  res.data.split("-")[1],
                  "Người dùng đã bị xóa.",
                  res.data.split("-")[0] == "1" ? "success" : "error"
                );
              });
          }
        });
    },
    getDateFormat(date) {
      return date.length > 0 ? moment(date).format("YYYY/MM/DD") : "";
    },
    addClick() {
      (this.accountUpdate = {
        Customer_id: 0,
        Customer_account_id: null,
        Customer_avatar: "",
        Customer_name: "",
        Customer_birth: "",
        Customer_email: "",
        Customer_address: "",
        Customer_phone: "",
        Customer_begindate: "",
      }),
        (this.infoModal = true),
        (this.ModalTitle = "Thêm người dùng");
    },
    updateClick(ID) {
      axios
        .get("https://localhost:44343/OldCar/Customer/GetDataById/" + ID)
        .then((res) => {
          this.customerUpdate = {
            Customer_id: res.data[0].Customer_id,
            Customer_account_id: res.data[0].Customer_account_id,
            Customer_avatar: res.data[0].Customer_avatar,
            Customer_name: res.data[0].Customer_name,
            Customer_birth: res.data[0].Customer_birth,
            Customer_email: res.data[0].Customer_email,
            Customer_address: res.data[0].Customer_address,
            Customer_phone: res.data[0].Customer_phone,
            Customer_begindate: res.data[0].Customer_begindate,
          };
        });
      (this.infoModal = true), (this.ModalTitle = "Cập nhật người dùng");
    },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getListCustomers");
    },
  },
};
</script>