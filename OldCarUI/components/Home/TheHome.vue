<template>
  <div>
    <div class="TheHome" v-if="dataPosts && dataPosts.length > 0">
      <CRow>
        <CCol v-for="post in dataPosts" :key="post.Post_id" col="3">
          <div class="card w-100">
            <CButton class="p-0" @click="previewPhoto(post)">
              <CImg
                :src="takePhoto(post.Post_car_frontpic)"
                block
                class="card-img-top"
              />
            </CButton>
            <div class="card-body">
              <h4 class="card-title" style="height: 80px">
                {{ post.Post_title }}
              </h4>
              <div class="card-text border-top pt-2">
                <table class="h5">
                  <tr>
                    <td>Giá:</td>
                    <td class="pl-5">{{ formatPrice(post.Post_car_price) }}</td>
                  </tr>
                  <tr>
                    <td>Tại:</td>
                    <td class="pl-5">{{ post.Post_car_province }}</td>
                  </tr>
                  <tr>
                    <td>Ngày đăng:</td>
                    <td class="pl-5">
                      {{ moment(post.Post_car_date).format("DD/MM/YYYY") }}
                    </td>
                  </tr>
                  <tr>
                    <td>Lượt yêu thích:</td>
                    <td class="pl-5">{{ post.Post_car_like }}</td>
                  </tr>
                </table>
              </div>
              <CButton
                class="btn btn-info float-right"
                @click="viewDetail(post)"
              >
                Chi tiết
              </CButton>
            </div>
          </div>
        </CCol>
      </CRow>

      <!-- Modal preview ảnh -->
      <CModal :title="title" color="dark" size="lg" :show.sync="darkModal">
        <div class="p-0 rounded">
          <ThePreviewPhoto :passPhoto="passPhoto" />
        </div>
      </CModal>

      <CModal
        :title="detailTitle"
        color="info"
        size="xl"
        :show.sync="infoModal"
      >
        <div class="p-0 rounded">
          <TheDetail
            :passPost="passPost"
            :carName="title"
            :passCar="passCar"
            @takePhoto="takePhoto"
          />
        </div>
      </CModal>
    </div>
  </div>
</template>
<style scoped>
.modal-footer {
  display: none !important;
}

.card:hover {
  box-shadow: 2px 2px 15px;
  transition-duration: 0.5s;
}
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
    dataPosts: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {
      darkModal: false,
      infoModal: false,
      passPhoto: {},
      passCar:{},
      title: null,
      domain: Domain,
      detailTitle: null,
      passPost: {},
    };
  },
  methods: {
    formatPrice(value) {
      if (value) {
        var returnVal = value.toLocaleString("it-IT", {
          style: "currency",
          currency: "VND",
        });
        return returnVal;
      }
    },
    takePhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/OldCarPhoto/" + value.split("~")[0]);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
    previewPhoto(value) {
      if (value) {
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
          (this.passPhoto = value.Post_car_frontpic.split("~").slice(0));
      }
    },
    viewDetail(value) {
      if (value) {
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
  },
};
</script>
