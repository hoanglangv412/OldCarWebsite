<template>
  <div class="TheCustomer">
    <CRow>
      <CCol col="12"
        ><CCard>
          <CCardBody>
            <CRow>
              <CCol
                col="12"
                xl="3"
                lg="3"
                md="12"
                sm="12"
                class="d-flex justify-content-center"
                ><div>
                  <CImg
                    class="c-avatar-img"
                    style="height: 250px; width: 250px"
                    :src="takePhoto(customerContact.Customer_avatar)"
                  /></div
              ></CCol>
              <CCol>
                <CListGroup flush>
                  <CCardTitle class="h1">{{
                    customerContact.Customer_name
                  }}</CCardTitle>
                  <CListGroupItem class="h5"
                    >Địa chỉ:&nbsp;&nbsp;&nbsp;{{
                      customerContact.Customer_address
                    }}</CListGroupItem
                  >
                  <CListGroupItem class="h5"
                    >Email:&nbsp;&nbsp;&nbsp;{{
                      customerContact.Customer_email
                    }}</CListGroupItem
                  >
                  <CListGroupItem class="h5"
                    >Số điện thoại:&nbsp;&nbsp;&nbsp;{{
                      customerContact.Customer_phone
                    }}</CListGroupItem
                  >
                </CListGroup>
              </CCol>
            </CRow>
          </CCardBody>

          <CCardBody>
            <CCardLink class="btn btn-outline-info float-right"
              >Gửi email</CCardLink
            >
          </CCardBody></CCard
        ></CCol
      >
    </CRow>
  </div>
</template>
<script>
import moment from "moment";
import { freeSet } from "@coreui/icons";

export default {
  name: "TheCustomer",
  freeSet,
  props: {
    customerContact: {},
  },
  components: {},
  data() {
    return {};
  },
  methods: {
    takePhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/Customer/" + value);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
    getDateFormat(date) {
      return date.length > 0 ? moment(date).format("YYYY/MM/DD") : "";
    },
  },
};
</script>