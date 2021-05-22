<template>
  <div>
    <div class="TheHome" v-if="dataCars && dataCars.length > 0">
      <CRow>
        <CCol col="12" xl="12" lg="12" md="12" sm="12" xs="12">
          <CRow>
            <CCol
              v-for="post in dataCars"
              :key="post.Car_id"
              col="12"
              lg="4"
              xl="4"
              md="5"
              sm="6"
            >
              <div class="card w-100">
                <div
                  class="p-0"
                  style="display: block; width: 100%; height: 350px"
                >
                  <CImg
                    :src="takePhoto(post.Carversion_photo)"
                    block
                    class="card-img-top image"
                    style="width: 100%; height: 100%"
                  />
                </div>
                <div class="card-body">
                  <h3 class="card-title h-100" style="min-height: 80px">
                    {{ post.Carversion_ManufacturerName }}_{{
                      post.Carversion_name
                    }}_{{ post.Carversion_edition }}_{{
                      post.Carversion_style
                    }}_{{ post.Carversion_date }}
                  </h3>
                  <CButton
                    class="btn-update float-right mt-5 btn btn-outline-info"
                    :to="`/Car/${post.Car_id}`"
                  >
                    Tạo bài đăng với xe này
                  </CButton>
                </div>
              </div>
            </CCol>
          </CRow>
        </CCol>
      </CRow>
    </div>
  </div>
</template>
<style scoped>
.modal-footer {
  display: none !important;
}
.middle {
  transition: 0.5s ease;
  opacity: 0;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
}
.container:hover .image {
  opacity: 0.2;
}

.container:hover .middle {
  opacity: 1;
}

.image {
  opacity: 1;
  display: block;
  width: 100%;
  height: auto;
  transition: 0.5s ease;
  backface-visibility: hidden;
}
/* .card:hover {
  box-shadow: 2px 2px 15px;
  transition-duration: 0.5s;
} */
</style>
<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import ThePreviewPhoto from "./ThePreviewPhoto";
import { Domain } from "@/constant/constant";
import TheDetail from "./TheDetail";
export default {
  freeSet,
  name: "TheHome",
  components: {
    ThePreviewPhoto,
    TheDetail,
  },
  props: {
    searchFlag: Boolean,
    dataCars: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {
      buyFlag: false,
      contactFlag: true,
      darkModal: false,
      infoModal: false,
      passPhoto: {},
      passCar: {},
      title: null,
      domain: Domain,
      detailTitle: null,
      passPost: {},
    };
  },
  methods: {
    getBadgeColor(value) {
      return value ? "danger" : "success";
    },
    getSold(value) {
      return value ? "Đã bán" : "Chưa bán";
    },
    formatPrice(value) {
      if (value != undefined) {
        return value + " VND";
      }
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
    previewPhoto(value) {
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
        (this.darkModal = true),
          (this.passPhoto = value.Post_car_frontpic.substring(
            0,
            value.Post_car_frontpic.length - 1
          )
            .split(",")
            .slice(0));
      }
    },
  },
};
</script>
