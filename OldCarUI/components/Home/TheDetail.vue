<template>
  <div>
    <CForm class="form-insert-update">
      <CCardHeader>
        <h1>{{ passPost.Post_title }}</h1>
      </CCardHeader>
      <CCardBody>
        <CRow>
          <CCol col="9">
            <CRow>
              <CCol col="6">
                <h5>Thông tin người dùng</h5>
                <table class="table">
                  <tr>
                    <td>Tên xe</td>
                    <td>{{ carName }}</td>
                  </tr>
                  <tr>
                    <td>Giá</td>
                    <td>{{ formatPrice(passPost.Post_car_price) }}</td>
                  </tr>
                  <tr>
                    <td>Xuất xứ</td>
                    <td>{{ passPost.Post_car_origin }}</td>
                  </tr>
                  <tr>
                    <td>Màu nội thất</td>
                    <td>{{ passPost.Post_car_incolor }}</td>
                  </tr>
                  <tr>
                    <td>Màu xe</td>
                    <td>{{ passPost.Post_car_outcolor }}</td>
                  </tr>
                  <tr>
                    <td>Thông số lốp xe</td>
                    <td>{{ passPost.Post_car_tire }}</td>
                  </tr>
                  <tr>
                    <td>Mâm xe</td>
                    <td>{{ passPost.Post_car_plate }}</td>
                  </tr>
                  <tr>
                    <td>Nơi đăng kí biển</td>
                    <td>{{ passPost.Post_car_province }}</td>
                  </tr>
                  <tr>
                    <td>Số km đã đi</td>
                    <td>{{ passPost.Post_car_km }} km</td>
                  </tr>
                  <tr>
                    <td>Số km/lít</td>
                    <td>{{ passPost.Post_car_detail }}</td>
                  </tr>
                  <tr>
                    <td>Mô tả chi tiết</td>
                    <td>{{ passPost.Post_car_kpl }} km/lít</td>
                  </tr>
                  <tr>
                    <td>Độ mới xe</td>
                    <td>{{ passPost.Post_car_cond }}%</td>
                  </tr>
                  <tr>
                    <td>Bảo hiểm dân sự</td>
                    <td>
                      <CBadge
                        :color="getBadgeColor(passPost.Post_car_civilcare)"
                      >
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="16"
                          height="16"
                          fill="currentColor"
                          class="bi bi-check2-circle"
                          viewBox="0 0 16 16"
                          v-if="passPost.Post_car_civilcare == true"
                        >
                          <path
                            d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                          />
                          <path
                            d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                          />
                        </svg>
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="16"
                          height="16"
                          fill="currentColor"
                          class="bi bi-file-excel"
                          viewBox="0 0 16 16"
                          v-else
                        >
                          <path
                            d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                          />
                          <path
                            d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                          />
                        </svg>
                      </CBadge>
                    </td>
                  </tr>
                  <tr>
                    <td>Bảo hiểm thân vỏ</td>
                    <td>
                      <CBadge
                        :color="getBadgeColor(passPost.Post_car_bodycare)"
                      >
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="16"
                          height="16"
                          fill="currentColor"
                          class="bi bi-check2-circle"
                          viewBox="0 0 16 16"
                          v-if="passPost.Post_car_bodycare == true"
                        >
                          <path
                            d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                          />
                          <path
                            d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                          />
                        </svg>
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="16"
                          height="16"
                          fill="currentColor"
                          class="bi bi-file-excel"
                          viewBox="0 0 16 16"
                          v-else
                        >
                          <path
                            d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                          />
                          <path
                            d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                          />
                        </svg>
                      </CBadge>
                    </td>
                  </tr>
                  <tr>
                    <td>Bảo hiểm khác</td>
                    <td>{{ passPost.Post_car_anothercare }}</td>
                  </tr>
                  <tr>
                    <td>Các linh kiện đã thay</td>
                    <td>{{ passPost.Post_car_replaceditems }}</td>
                  </tr>
                  <tr>
                    <td>Lượt yêu thích</td>
                    <td class="h5">
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
                </table>
              </CCol>
              <CCol col="6">
                <CButton class="p-0" @click="previewPhoto(passPost)">
                  <CImg
                    :src="takePhoto(passPost.Post_car_frontpic)"
                    block
                    class="card-img-top"
                  />
                </CButton>
                <h5>Thông số kĩ thuật</h5>
                <table class="table">
                  <tr>
                    <td>Hệ truyền động</td>
                    <td>{{ passCar.Car_trans }}</td>
                  </tr>
                  <tr>
                    <td>Nhiên liệu</td>
                    <td>{{ passCar.Car_fuel }}</td>
                  </tr>
                  <tr>
                    <td>Động cơ</td>
                    <td>{{ passCar.Car_engine }}</td>
                  </tr>
                  <tr>
                    <td>Lực mô men xoắn cực đại</td>
                    <td>{{ passCar.Car_maxmomen }}</td>
                  </tr>
                  <tr>
                    <td>Vận tốc tối đa</td>
                    <td>{{ passCar.Car_maxspeed }}</td>
                  </tr>
                  <tr>
                    <td>Công suất tối đa</td>
                    <td>{{ passCar.Car_maxpower }}</td>
                  </tr>
                  <tr>
                    <td>Trọng tải</td>
                    <td>{{ passCar.Car_loadweight }}</td>
                  </tr>
                  <tr>
                    <td>Hệ truyền động</td>
                    <td>{{ passCar.Car_drivetype }}</td>
                  </tr>
                  <tr>
                    <td>Dung tích xi lanh</td>
                    <td>{{ passCar.Car_cylcapacity }}</td>
                  </tr>
                  <tr>
                    <td>Hệ thống phanh</td>
                    <td>{{ passCar.Car_brakesystem }}</td>
                  </tr>
                  <tr>
                    <td>Hệ thống nhiên liệu</td>
                    <td>{{ passCar.Car_fuelsystem }}</td>
                  </tr>
                </table>
              </CCol>
            </CRow>
            <CImg
              :src="takeSecondPhoto(passPost.Post_car_frontpic)"
              block
              class="card-img-top"
            />
          </CCol>
          <CCol col="3">
            <h5 class="text-left">Kích thước xe</h5>
            <table class="table text-left">
              <tr>
                <td>Kích thước tổng thể</td>
                <td>{{ passCar.Car_totaldimens }}</td>
              </tr>
              <tr>
                <td>Chiều dài cơ sở</td>
                <td>{{ passCar.Car_baselength }}</td>
              </tr>
              <tr>
                <td>Bán kính quay vòng</td>
                <td>{{ passCar.Car_turnradius }}</td>
              </tr>
              <tr>
                <td>Chiều cao xe</td>
                <td>{{ passCar.Car_height }}</td>
              </tr>
            </table>
            <h5>Options</h5>
            <table class="table">
              <tr>
                <td>Số cửa</td>
                <td>{{ passCar.Car_doors }}</td>
              </tr>
              <tr>
                <td>Số ghế</td>
                <td>{{ passCar.Car_seats }}</td>
              </tr>
              <tr>
                <td>Số túi khí</td>
                <td>{{ passCar.Car_airnums }}</td>
              </tr>
              <tr>
                <td>Camera</td>
                <td>{{ passPost.Car_camera }}</td>
              </tr>
              <tr>
                <td>Loại cửa</td>
                <td>{{ passPost.Car_doortype }}</td>
              </tr>
              <tr>
                <td>Loại gương</td>
                <td>{{ passPost.Car_mirror }}</td>
              </tr>
              <tr>
                <td>Loại ghế</td>
                <td>{{ passPost.Car_seattype }}</td>
              </tr>
              <tr>
                <td>Hệ thống âm thanh</td>
                <td>{{ passPost.Car_sound }}</td>
              </tr>
              <tr>
                <td>GPS</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_gps)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_gps == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Màn hình cảm ứng</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_touchscreen)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_touchscreen == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Cửa sổ trời</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_skyview)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_skyview == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Cốp điện</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_electrunk)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_electrunk == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Kiểm soát hành trình</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_cruisecontrol)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_cruisecontrol == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Cảnh báo áp suất lốp</td>
                <td>
                  <CBadge
                    :color="getBadgeColor(passPost.Car_tirepressurealert)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_tirepressurealert == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Hệ thống cân bằng điện tử</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_electricbalance)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_electricbalance == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Cảnh báo điểm mù</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_blindalert)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_blindalert == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Cảm biến khoảng cách</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_distancesensor)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_distancesensor == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Camera 360</td>
                <td>
                  <CBadge :color="getBadgeColor(passPost.Car_camera360)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_camera360 == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Hỗ trợ khởi hành ngang dốc</td>
                <td>
                  <CBadge
                    :color="getBadgeColor(passPost.Car_acrosshillsupport)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_acrosshillsupport == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr>
              <tr>
                <td>Điều hòa tự động</td>
                <td>
                  <CBadge
                    :color="getBadgeColor(passPost.Car_autoairconditioner)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-check2-circle"
                      viewBox="0 0 16 16"
                      v-if="passPost.Car_autoairconditioner == true"
                    >
                      <path
                        d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z"
                      />
                      <path
                        d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z"
                      />
                    </svg>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="currentColor"
                      class="bi bi-file-excel"
                      viewBox="0 0 16 16"
                      v-else
                    >
                      <path
                        d="M5.18 4.616a.5.5 0 0 1 .704.064L8 7.219l2.116-2.54a.5.5 0 1 1 .768.641L8.651 8l2.233 2.68a.5.5 0 0 1-.768.64L8 8.781l-2.116 2.54a.5.5 0 0 1-.768-.641L7.349 8 5.116 5.32a.5.5 0 0 1 .064-.704z"
                      />
                      <path
                        d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"
                      />
                    </svg>
                  </CBadge>
                </td>
              </tr></table
          ></CCol>
        </CRow>
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
</style>
<script>
import axios from "axios";
import swal from "sweetalert2";
import { Domain } from "@/constant/constant";
import ThePreviewPhoto from "./ThePreviewPhoto";

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
    previewPhoto(value) {
      if (value) {
        (this.darkModal = true),
          (this.passPhoto = value.Post_car_frontpic.split("~").slice(0));
      }
    },
    getBadgeColor(value) {
      return value == true ? "success" : "dark";
    },
    takeSecondPhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/OldCarPhoto/" + value.split("~")[1]);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
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
  },
  mounted() {},
};
</script>
