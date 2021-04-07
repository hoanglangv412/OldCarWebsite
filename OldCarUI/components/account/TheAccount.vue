<template>
  <div class="TheAccount">
    <CCard>
      <CCardHeader>
        <h3>Accounts management</h3>
      </CCardHeader>
      <CCardBody class="text">
        <CButton
          color="info"
          class="m-2 btn-add float-right mr-5"
          @click="addClick()"
        >
          <!-- <nuxt-link to="/account/add" class="text-white d-block">Add +</nuxt-link> -->Add
          +
        </CButton>
        <CModal
          :title="ModalTitle"
          color="info"
          size="lg"
          :show.sync="infoModal"
        >
          <TheCreateEditAccount v-bind:account='accountItem'/>
          <div slot="footer" class="w-100 d-none"></div>
        </CModal>
        <CDataTable
          :items="dataAccounts"
          :fields="account"
          :items-per-page="5"
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
                :accountId="1"
                color="warning"
                class="btn-update"
                @click="updateClick(item)"
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

const accountItem = [
  { key: "Account_id", label: "ID", _style: "min-width:100px" },
  { key: "Account_name", label: "Account name", _style: "min-width:150px" },
  {
    key: "Account_password",
    label: "Account password",
    _style: "min-width:100px;",
  },
  { key: "Account_role", label: "Role", _style: "min-width:100px;" },
  { key: "method", label: "Method", _style: "min-width:100px;" },
];
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
      account: accountItem,
      infoModal: false,
      ModalTitle: null,
    };
  },
  methods: {
    deleteAccount(ID) {
      swal
        .fire({
          title: "Are you sure?",
          text: "This account will be deleted instantly.",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!",
        })
        .then((result) => {
          if (result.isConfirmed) {
            axios
              .delete("https://localhost:44343/OldCar/Account/" + ID)
              .then((res) => {
                this.$emit("getListAccounts", this.dataAccounts);
              });
            swal.fire("Deleted!", "This account has been deleted.", "success");
          }
        });
    },
    getBadgeColor(Account_role) {
      return Account_role == "1" ? "info" : Account_role == "0" ? "danger" : "";
    },
    getRole(Account_role) {
      return Account_role == "1" ? "User" : Account_role == "0" ? "Admin" : "";
    },
    getPassword(Account_password) {
      return "******************";
    },
    addClick() {
      (this.accountItem = {
        Account_Id: 0,
        Account_Name: "",
        Account_password: "",
        Account_role: 0,
      }),
        (this.infoModal = true),
        (this.ModalTitle = "Modal Insert");
      // return infoModal = true;
    },
    updateClick(item) {
      (this.accountItem = {
        Account_Id: item.ID,
        Account_Name: item.Account_Name,
        Account_password: item.Account_password,
        Account_role: item.Account_role,
      }),
        (this.infoModal = true),
        (this.ModalTitle = "Modal Update");
      // return infoModal = true;
    },
  },
};
</script>