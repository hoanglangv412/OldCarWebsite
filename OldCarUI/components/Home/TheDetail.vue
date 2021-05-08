<template>
  <div>
    <CForm class="form-insert-update">
      <CCardHeader>
        <h1>{{ passPost.Post_title }}</h1>
      </CCardHeader>
      <CCardBody class="text-nowrap">
        <CCard style="border: 0px">
          <CCardBody class="p-0">
            <CRow>
              <CCol
                ><table class="table">
                  <tr>
                    <td class="h5">Tên xe</td>
                    <td>{{ carName }}</td>
                  </tr>
                  <tr>
                    <td class="h5">Giá</td>
                    <td>{{ formatPrice(passPost.Post_car_price) }}</td>
                  </tr>
                  <tr>
                    <td class="h5">Địa chỉ</td>
                    <td>{{ passPost.Post_car_province }}</td>
                  </tr>
                  <tr>
                    <td class="h5">Lượt yêu thích</td>
                    <td>
                      <CBadge color="danger">
                        {{
                          passPost.Post_car_like != null
                            ? passPost.Post_car_like
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
                    </td>
                  </tr>
                  <tr>
                    <td class="h5">Ngày đăng</td>
                    <td>{{ formatDate(passPost.Post_car_date) }}</td>
                  </tr>
                </table></CCol
              >
              <CCol>
                <CButton class="p-0" @click="previewPhoto(passPost)">
                  <CImg
                    :src="takePhoto(passPost.Post_car_frontpic)"
                    block
                    class="card-img-top"
                  />
                </CButton>
              </CCol>
            </CRow>
          </CCardBody>
        </CCard>

        <CCard>
          <CCardBody>
            <div class="row">
              <div class="col">
                <h4>Thông tin người bán cung cấp</h4>
              </div>
              <div class="col">
                <CButton
                  color="light"
                  class="float-right"
                  @click="collapse = !collapse"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-chevron-double-down"
                    viewBox="0 0 16 16"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M1.646 6.646a.5.5 0 0 1 .708 0L8 12.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                    <path
                      fill-rule="evenodd"
                      d="M1.646 2.646a.5.5 0 0 1 .708 0L8 8.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                  </svg>
                </CButton>
              </div>
            </div>

            <CCollapse :show="collapse" class="mt-2">
              <CRow>
                <CCol>
                  <table class="table">
                    <tr>
                      <td class="h5">Xuất xứ</td>
                      <td>{{ passPost.Post_car_origin }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Màu nội thất</td>
                      <td>
                        <input
                          type="color"
                          v-model="passPost.Post_car_incolor"
                          disabled
                        />
                      </td>
                    </tr>
                    <tr>
                      <td class="h5">Màu xe</td>
                      <td>
                        <input
                          type="color"
                          v-model="passPost.Post_car_outcolor"
                          disabled
                        />
                      </td>
                    </tr>
                    <tr>
                      <td class="h5">Số km đã đi</td>
                      <td>{{ passPost.Post_car_km }} km</td>
                    </tr>
                    <tr>
                      <td class="h5">Số km/lít</td>
                      <td>{{ passPost.Post_car_kpl }} km/lít</td>
                    </tr>
                    <tr>
                      <td class="h5">Độ mới xe</td>
                      <td>{{ passPost.Post_car_cond }}%</td>
                    </tr>
                  </table>
                </CCol>
                <CCol col="8">
                  <div
                    class="list-group"
                    v-if="passPost.Post_car_replaceditems != undefined"
                  >
                    <a
                      href="#"
                      class="list-group-item"
                      style="color:black"
                    >
                      <h5>Linh kiện đã thay thế</h5>
                    </a>
                    <a
                      href="#"
                      class="list-group-item list-group-item-action"
                      v-for="item in passPost.Post_car_replaceditems.split(',')"
                      :key="item"
                    >
                      {{ item }}
                    </a>
                  </div>
                </CCol>
              </CRow>
              <CRow>
                <h5>Mô tả chi tiết</h5>
                <CTextarea
                  class="w-100"
                  rows="8"
                  readonly
                  v-model="passPost.Post_car_detail"
                />
              </CRow>
            </CCollapse>
          </CCardBody>
        </CCard>
        <CCard>
          <CCardBody>
            <div class="row">
              <div class="col">
                <h4>Tổng quan</h4>
              </div>
              <div class="col">
                <CButton
                  color="light"
                  class="float-right"
                  @click="collapse3 = !collapse3"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-chevron-double-down"
                    viewBox="0 0 16 16"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M1.646 6.646a.5.5 0 0 1 .708 0L8 12.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                    <path
                      fill-rule="evenodd"
                      d="M1.646 2.646a.5.5 0 0 1 .708 0L8 8.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                  </svg>
                </CButton>
              </div>
            </div>

            <CCollapse :show="collapse3" class="mt-2">
              <CRow>
                <CCol col="6">
                  <CImg
                    :src="takeSecondPhoto(passPost.Post_car_frontpic)"
                    block
                    class="card-img-top"
                  />
                </CCol>
                <CCol col="6">
                  <fieldset class="border rounded">
                    <legend class="text-left ml-3" style="width: 0">
                      Kích thước xe
                    </legend>
                    <table class="table text-left">
                      <tr>
                        <td class="h5">Kích thước tổng thể</td>
                        <td>{{ passCar.Car_totaldimens }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Chiều dài cơ sở</td>
                        <td>{{ passCar.Car_baselength }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Bán kính quay vòng</td>
                        <td>{{ passCar.Car_turnradius }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Khoảng sáng gầm xe</td>
                        <td>{{ passCar.Car_height }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Số cửa</td>
                        <td>{{ passCar.Car_doors }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Số ghế</td>
                        <td>{{ passCar.Car_seats }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Thông số lốp xe</td>
                        <td>{{ passPost.Post_car_tire }}</td>
                      </tr>
                      <tr>
                        <td class="h5">Mâm xe</td>
                        <td>{{ passPost.Post_car_plate }}</td>
                      </tr>
                    </table>
                  </fieldset>
                </CCol>
              </CRow></CCollapse
            >
          </CCardBody>
        </CCard>
        <CCard>
          <CCardBody>
            <div class="row">
              <div class="col">
                <h4>Thông số kĩ thuật</h4>
              </div>
              <div class="col">
                <CButton
                  color="light"
                  class="float-right"
                  @click="collapse1 = !collapse1"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-chevron-double-down"
                    viewBox="0 0 16 16"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M1.646 6.646a.5.5 0 0 1 .708 0L8 12.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                    <path
                      fill-rule="evenodd"
                      d="M1.646 2.646a.5.5 0 0 1 .708 0L8 8.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                  </svg>
                </CButton>
              </div>
            </div>

            <CCollapse :show="collapse1" class="mt-2">
              <table class="table">
                <tr>
                  <td class="h5">Hệ truyền động</td>
                  <td>{{ passCar.Car_trans }}</td>
                </tr>
                <tr>
                  <td class="h5">Nhiên liệu</td>
                  <td>{{ passCar.Car_fuel }}</td>
                </tr>
                <tr>
                  <td class="h5">Động cơ</td>
                  <td>{{ passCar.Car_engine }}</td>
                </tr>
                <tr>
                  <td class="h5">Lực mô men xoắn cực đại</td>
                  <td>{{ passCar.Car_maxmomen }}</td>
                </tr>
                <tr>
                  <td class="h5">Vận tốc tối đa</td>
                  <td>{{ passCar.Car_maxspeed }}</td>
                </tr>
                <tr>
                  <td class="h5">Công suất tối đa</td>
                  <td>{{ passCar.Car_maxpower }}</td>
                </tr>
                <tr>
                  <td class="h5">Trọng tải</td>
                  <td>{{ passCar.Car_loadweight }}</td>
                </tr>
                <tr>
                  <td class="h5">Hệ truyền động</td>
                  <td>{{ passCar.Car_drivetype }}</td>
                </tr>
                <tr>
                  <td class="h5">Dung tích xi lanh</td>
                  <td>{{ passCar.Car_cylcapacity }}</td>
                </tr>
                <tr>
                  <td class="h5">Hệ thống phanh</td>
                  <td>{{ passCar.Car_brakesystem }}</td>
                </tr>
              </table>
            </CCollapse>
          </CCardBody>
        </CCard>
        <CCard>
          <CCardBody>
            <div class="row">
              <div class="col">
                <h4>Trang bị</h4>
              </div>
              <div class="col">
                <CButton
                  color="light"
                  class="float-right"
                  @click="collapse2 = !collapse2"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-chevron-double-down"
                    viewBox="0 0 16 16"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M1.646 6.646a.5.5 0 0 1 .708 0L8 12.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                    <path
                      fill-rule="evenodd"
                      d="M1.646 2.646a.5.5 0 0 1 .708 0L8 8.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                  </svg>
                </CButton>
              </div>
            </div>

            <CCollapse :show="collapse2" class="mt-2">
              <CRow>
                <CCol col="7"
                  ><table class="table">
                    <tr>
                      <td class="h5">Số túi khí</td>
                      <td>{{ passCar.Car_airnums }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Camera</td>
                      <td>{{ passPost.Car_camera }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Loại cửa</td>
                      <td>{{ passPost.Car_doortype }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Loại gương</td>
                      <td>{{ passPost.Car_mirror }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Loại ghế</td>
                      <td>{{ passPost.Car_seattype }}</td>
                    </tr>
                    <tr>
                      <td class="h5">Hệ thống âm thanh</td>
                      <td>{{ passPost.Car_sound }}</td>
                    </tr>
                  </table></CCol
                >
                <CCol col="5">
                  <table
                    v-if="passPost.Car_technology != undefined"
                    class="table"
                  >
                    <tr
                      v-for="item in passPost.Car_technology.split(',')"
                      :key="item"
                    >
                      <td class="h5">{{ item }}</td>
                      <td>
                        <CBadge color="success" v-if="item != ''">
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="16"
                            height="16"
                            fill="currentColor"
                            class="bi bi-check2-circle"
                            viewBox="0 0 16 16"
                          >
                            <path
                              d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                            />
                            <path
                              d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                            />
                          </svg>
                        </CBadge>
                      </td>
                    </tr>
                  </table>
                </CCol>
              </CRow>
            </CCollapse>
          </CCardBody>
        </CCard>
        <CCard>
          <CCardBody>
            <div class="row">
              <div class="col">
                <h4>Bảo hiểm</h4>
              </div>
              <div class="col">
                <CButton
                  color="light"
                  class="float-right"
                  @click="collapse4 = !collapse4"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-chevron-double-down"
                    viewBox="0 0 16 16"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M1.646 6.646a.5.5 0 0 1 .708 0L8 12.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                    <path
                      fill-rule="evenodd"
                      d="M1.646 2.646a.5.5 0 0 1 .708 0L8 8.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
                    />
                  </svg>
                </CButton>
              </div>
            </div>

            <CCollapse :show="collapse4" class="mt-2">
              <CRow>
                <CCol>
                  <table
                    v-if="passPost.Post_car_anothercare != undefined"
                    class="table"
                  >
                    <tr
                      v-for="item in passPost.Post_car_anothercare.split(',')"
                      :key="item"
                    >
                      <td class="h5">{{ item }}</td>
                      <td>
                        <CBadge color="success" v-if="item != ''">
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="16"
                            height="16"
                            fill="currentColor"
                            class="bi bi-check2-circle"
                            viewBox="0 0 16 16"
                          >
                            <path
                              d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                            />
                            <path
                              d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                            />
                          </svg>
                        </CBadge>
                      </td>
                    </tr>
                  </table>
                </CCol>
              </CRow>
            </CCollapse>
          </CCardBody>
        </CCard>
      </CCardBody>
    </CForm>
    <!-- Modal preview ảnh -->
    <CModal :title="title" color="dark" size="lg" :show.sync="darkModal">
      <div class="p-0 rounded">
        <ThePreviewPhoto :passPhoto="passPhoto" />
      </div>
    </CModal>
  </div>
</template>
<style>
table td,
th {
  font-size: 1rem;
  border-width: 0px !important;
}
.modal-footer {
  display: none !important;
  background-color: black;
}
.text-nowrap {
  white-space: nowrap !important;
}
</style>
<script>
import axios from "axios";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
import ThePreviewPhoto from "./ThePreviewPhoto";
import Table from "~/pages/base/Table.vue";

export default {
  name: "TheDetail",
  components: {
    ThePreviewPhoto,
  },

  props: { passPost: Object, carName: String, passCar: Object },
  data() {
    return {
      title: null,
      domain: Domain,
      ThePreviewPhoto,
      darkModal: false,
      passPhoto: {},
      collapse: false,
      collapse1: false,
      collapse2: false,
      collapse3: false,
      collapse4: false,
      technologyName: [],
    };
  },
  methods: {
    getTechnologyName(value) {
      return value.split(",");
    },
    formatDate(value) {
      if (value != undefined) {
        return value.substring(0, 10);
      }
    },
    formatPrice(value) {
      if (value != undefined) {
        var returnVal = value.toLocaleString("it-IT", {
          style: "currency",
          currency: "VND",
        });
        return returnVal;
      }
    },
    previewPhoto(value) {
      if (value != undefined) {
        (this.darkModal = true),
          (this.passPhoto = value.Post_car_frontpic.split(",").slice(0));
      }
    },
    getBadgeColor(value) {
      if (value != undefined) {
        return value.includes("GPS") ? "success" : "dark";
      }
    },
    takeSecondPhoto(value) {
      if (value != undefined) {
        var images;
        try {
          images = require("@/assets/OldCarPhoto/" + value.split(",")[1]);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
    takePhoto(value) {
      if (value != undefined) {
        var images;
        try {
          images = require("@/assets/OldCarPhoto/" + value.split(",")[0]);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
  },
};
</script>
