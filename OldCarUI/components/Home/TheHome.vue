<template>
  <div>
    <div class="TheHome" v-if="dataPosts && dataPosts.length > 0">
      <CRow>
        <CCol col="12" xl="9" lg="9" md="12" sm="12" xs="12">
          <CRow
            ><CCol v-if="searchFlag"
              ><div
                id="carouselExampleCaptions"
                class="carousel slide rounded"
                data-ride="carousel"
              >
                <ol class="carousel-indicators rounded">
                  <li
                    data-target="#carouselExampleCaptions"
                    data-slide-to="0"
                    class="active"
                  ></li>
                  <li
                    data-target="#carouselExampleCaptions"
                    data-slide-to="1"
                  ></li>
                  <li
                    data-target="#carouselExampleCaptions"
                    data-slide-to="2"
                  ></li>
                </ol>
                <div class="carousel-inner">
                  <div class="carousel-item active">
                    <CButton :to="`/SearchName/Vinfast`">
                      <img
                        src="@/assets/img/banner-x.jpg"
                        class="d-block w-100"
                        alt=""
                        style="height: 450px"
                    /></CButton>
                  </div>
                  <div class="carousel-item">
                    <CButton :to="`/SearchName/KIA`">
                      <img
                        src="@/assets/img/sorento.jpg"
                        class="d-block w-100"
                        alt=""
                        style="height: 450px"
                    /></CButton>
                  </div>
                  <div class="carousel-item">
                    <CButton :to="`/SearchName/mercedes`">
                      <img
                        src="@/assets/img/mercedes.jpg"
                        class="d-block w-100"
                        alt=""
                        style="height: 450px"
                    /></CButton>
                  </div>
                </div>
                <a
                  class="carousel-control-prev"
                  href="#carouselExampleCaptions"
                  role="button"
                  data-slide="prev"
                >
                  <span
                    class="carousel-control-prev-icon"
                    aria-hidden="true"
                  ></span>
                  <span class="sr-only">Previous</span>
                </a>
                <a
                  class="carousel-control-next"
                  href="#carouselExampleCaptions"
                  role="button"
                  data-slide="next"
                >
                  <span
                    class="carousel-control-next-icon"
                    aria-hidden="true"
                  ></span>
                  <span class="sr-only">Next</span>
                </a>
              </div></CCol
            ></CRow
          >
          <CRow>
            <CCol
              v-for="post in dataPosts"
              :key="post.Post_id"
              col="12"
              lg="4"
              xl="4"
              md="5"
              sm="6"
            >
              <div class="card w-100">
                <CButton
                  class="p-0"
                  @click="previewPhoto(post)"
                  style="display:block;width:100%;height:300px"
                >
                  <CImg
                    :src="takePhoto(post.Post_car_frontpic)"
                    block
                    class="card-img-top image"
                    style="width:100%;height:100%"
                  />
                </CButton>
                <div class="card-body">
                  <h3 class="card-title h-100" style="min-height: 80px">
                    {{ post.Post_title }}
                  </h3>
                  <div class="card-text border-top pt-2">
                    <table class="w-100">
                      <tr>
                        <td class="h5">Giá:</td>
                        <td class="pl-5 h5">
                          {{ formatPrice(post.Post_car_price) }}
                        </td>
                      </tr>
                      <tr>
                        <td class="h5">Tại:</td>
                        <td class="pl-5 h5">{{ post.Post_car_province }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Ngày đăng:</td>
                        <td class="pl-5 h5">
                          {{ moment(post.Post_car_date).format("DD/MM/YYYY") }}
                        </td>
                      </tr>
                      <tr>
                        <td class="h5">Lượt yêu thích:</td>
                        <td class="pl-5 h5">{{ post.Post_car_like }}</td>
                      </tr>
                      <tr>
                        <td colspan="2">
                          <CBadge
                            :color="getBadgeColor(post.Post_car_sold)"
                            class="float-right"
                          >
                            {{ getSold(post.Post_car_sold) }}
                          </CBadge>
                        </td>
                      </tr>
                    </table>
                  </div>
                  <CButton
                    class="btn-update float-right mt-5 btn btn-outline-warning"
                    :to="`/Home/${post.Post_id}`"
                  >
                    Chi tiết xe
                  </CButton>
                </div>
              </div>
            </CCol>
          </CRow>
        </CCol>
        <CCol v-if="searchFlag">
          <fieldset class="border p-2 mt-3">
            <legend class="ml-2 w-0">Bài đăng mới nhất</legend>
            <CRow>
              <CCol
                v-for="post in dataPostSorts"
                :key="post.Post_id"
                col="12"
                lg="12"
                xl="12"
                md="12"
                sm="12"
              >
                <div class="card container">
                  <CImg
                    :src="takePhoto(post.Post_car_frontpic)"
                    block
                    class="card-img-top image"
                  />
                  <div class="middle w-100 h-50 text-left">
                    <div class="text">
                      <div class="card-body">
                        <div class="card-text border-top pt-2">
                          <table class="w-100">
                            <tr>
                              <td class="h5">Giá:</td>
                              <td class="pl-5 h5">
                                {{ formatPrice(post.Post_car_price) }}
                              </td>
                            </tr>
                            <tr>
                              <td class="h5">Tại:</td>
                              <td class="pl-5 h5">
                                {{ post.Post_car_province }}
                              </td>
                            </tr>
                            <tr>
                              <td class="h5">Ngày đăng:</td>
                              <td class="pl-5 h5">
                                {{
                                  moment(post.Post_car_date).format(
                                    "DD/MM/YYYY"
                                  )
                                }}
                              </td>
                            </tr>
                            <tr>
                              <td class="h5">Lượt yêu thích:</td>
                              <td class="pl-5 h5">{{ post.Post_car_like }}</td>
                            </tr>
                          </table>
                        </div>
                        <div class="row mt-3">
                          <div class="col">
                            <CBadge
                              :color="getBadgeColor(post.Post_car_sold)"
                              class=""
                            >
                              {{ getSold(post.Post_car_sold) }}
                            </CBadge>
                          </div>
                          <div class="col">
                            <CButton
                              class="btn-update btn btn-warning float-right"
                              :to="`/Home/${post.Post_id}`"
                            >
                              Chi tiết xe
                            </CButton>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </CCol>
            </CRow>
          </fieldset>
        </CCol>
      </CRow>

      <!-- Modal preview ảnh -->
      <CModal :title="title" color="dark" size="lg" :show.sync="darkModal">
        <div class="p-0 rounded">
          <ThePreviewPhoto :passPhoto="passPhoto" />
        </div>
      </CModal>
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
    dataPosts: {
      type: Array,
      default: () => [],
    },
    dataPostSorts: {
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
          images = require("@/assets/OldCarPhoto/" + value.split(",")[0]);
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
