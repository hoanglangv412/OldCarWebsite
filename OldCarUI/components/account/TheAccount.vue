<template>
  <div class="TheAccount">
    <CCard>
      <CCardHeader>
        <h3>Quản lí tài khoản</h3>
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
          <TheCreateEditAccount
            :passAccount="accountUpdate"
            @closeModal="closeModal"
            :accountname_valid="null"
            :accountpassword_valid="null"
          />
          <div slot="footer" class="w-100 d-none"></div>
        </CModal>
        <CDataTable
          :items="dataAccounts"
          :fields="accountItem"
          :items-per-page="8"
          table-filter
          clickable-rows
          hover
          pagination
        >
          <template #Account_role="{ item }">
            <td>
              <CBadge :color="getBadgeColor(item.Account_role)">
                {{ getRole(item.Account_role) }}
              </CBadge>
            </td>
          </template>
          <template #Account_password="{ item }">
            <td>
              {{ getPassword(item.Account_password) }}
            </td>
          </template>
          <template #method="{ item }">
            <td class="py-2">
              <CButton
                color="warning"
                class="btn-update"
                @click="updateClick(item.Account_id)"
              >
                <CIcon :content="$options.freeSet.cilPencil" />
              </CButton>
              <CButton
                color="danger"
                @click="deleteAccount(item.Account_id)"
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
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";
import TheCreateEditAccount from "./TheCreateEditAccount";

export default {
  name: "TheAccount",
  freeSet,
  props: {
    dataAccounts: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    TheCreateEditAccount,
  },
  data() {
    return {
      accountItem: [
        { key: "Account_id", label: "ID", _style: "min-width:100px;" },
        {
          key: "Account_name",
          label: "Tên tài khoản",
          _style: "min-width:150px",
        },
        {
          key: "Account_password",
          label: "Mật khẩu",
          _style: "min-width:100px;",
        },
        { key: "Account_role", label: "Quyền", _style: "min-width:100px;" },
        { key: "method", label: "Phương thức", _style: "min-width:100px;" },
      ],
      accountUpdate: {},
      ModalTitle: null,
      infoModal: false,
    };
  },
  methods: {
    deleteAccount(ID) {
      swal
        .fire({
          title: "Bạn chắc chắn xóa tài khoản này?",
          text: "Tài khoản này sẽ bị xóa vĩnh viễn.",
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
              .delete("https://localhost:44343/OldCar/Account/" + ID)
              .then((res) => {
                this.$emit("getListAccounts");
                swal.fire(
                  res.data.split("-")[1],
                  "Tài khoản đã bị xóa.",
                  res.data.split("-")[0] == "1" ? "success" : "error"
                );
              });
          }
        });
    },
    getBadgeColor(Account_role) {
      return Account_role == "1" ? "info" : "danger";
    },
    getRole(Account_role) {
      return Account_role == "1" ? "Người dùng" : "Admin";
    },
    getPassword(Account_password) {
      return "******************";
    },
    addClick() {
      (this.accountUpdate = {
        Account_id: 0,
        Account_name: "",
        Account_password: "",
        Account_role: 0,
      }),
        (this.infoModal = true),
        (this.ModalTitle = "Thêm tài khoản");
    },
    updateClick(ID) {
      axios
        .get("https://localhost:44343/OldCar/Account/GetDataById/" + ID)
        .then((res) => {
          this.accountUpdate = {
            Account_id: res.data[0].Account_id,
            Account_name: res.data[0].Account_name.trim(),
            Account_password: res.data[0].Account_password.trim(),
            Account_role: res.data[0].Account_role,
          };
        });
      (this.infoModal = true), (this.ModalTitle = "Cập nhật tài khoản");
    },
    closeModal(val) {
      this.infoModal = val;
      this.$emit("getListAccounts");
    },
  },
};
</script>