<template>
  <div id="id_send_email">
    <CRow>
      <CCol>
        <CForm>
          <CInput label="Tới" v-model="emailTo" id="id_emailTo"/>
          <CInput type="text" label="Tiêu đề" id="id_title" />
          <CTextarea type="text" label="Nội dung" id="id_content" rows="12" />
          <CButton class="btn btn-info float-right mt-2" @click="sendEmail()"
            >Gửi</CButton
          >
        </CForm>
      </CCol>
    </CRow>
  </div>
</template>
<script>
import { freeSet } from "@coreui/icons";
import axios from "axios";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
export default {
  name: "TheCustomer",
  freeSet,
  props: {
    emailTo: String,
  },
  components: {},
  data() {
    return {
      domain: Domain,
    };
  },
  mounted() {
    $("#id_send_email input").val("");
  },
  methods: {
    sendEmail() {
      let formData = new FormData();
      formData.append("FromUser", "kieungothekieu@gmail.com");
      formData.append("ToUser", $("#id_emailTo").val().trim());
      formData.append("EmailSubject", $("#id_title").val().trim());
      formData.append("EmailContent", $("#id_content").val().trim());
      if ($("#id_send_email input").val() != "") {
        axios
          .post(this.domain + "Customer/SendEmail", formData, {
            headers: {
              "Content-Type": Object,
            },
          })
          .then((res) => {
            swal.fire({
              position: "center",
              icon: res.data.split("-")[0] == "1" ? "success" : "error",
              title: res.data.split("-")[1],
              showConfirmButton: false,
              timer: 1500,
            });
          });
      } else {
        swal.fire({
          position: "center",
          icon: "error",
          title: "Điền trường còn thiếu",
          showConfirmButton: false,
          timer: 1500,
        });
      }
    },
  },
};
</script>