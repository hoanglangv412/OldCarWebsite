<template>
  <div>
    <CCol>
      <CForm class="form-insert-update">
        <CCardBody class="text-nowrap pt-0">
          <CRow>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border pl-4 pr-4">
                <legend style="width:0;float-left">Thông tin mô tả</legend>
                <CInput type="text" v-model.trim="passPost.Post_id" hidden />
                <CInput
                  type="text"
                  id="idsold"
                  v-model.trim="passPost.Post_car_sold"
                  hidden
                />
                <div role="group" class="form-group form-row">
                  <CCol>
                    <label>Dòng xe</label>
                    <div class="row">
                      <div class="col-10 pr-0">
                        <input
                          id="carSelector"
                          type="text"
                          class="form-control"
                          list="carversionNames"
                          v-model="passPost.Post_car_id"
                        />
                        <datalist id="carversionNames">
                          <option
                            v-for="item in Selectpostcars"
                            :key="item.Car_id"
                            :value="item.Car_id"
                          >
                            {{ item.Carversion_ManufacturerName }} _
                            {{ item.Carversion_name }} _
                            {{ item.Carversion_edition }} _
                            {{ item.Carversion_style }} _
                            {{ item.Carversion_date }}
                          </option>
                        </datalist>
                      </div>
                      <div class="col-2 pl-0">
                        <CButton
                          class="form-control text-center pr-0 pl-0 btn btn-info"
                          to="/Post/CreateAndEditCarForPost"
                        >
                          Tạo mới xe
                        </CButton>
                      </div>
                    </div>
                  </CCol>
                </div>
                <label>Tiêu đề</label>
                <input
                  class="form-control"
                  v-model="passPost.Post_title"
                  type="text"
                  horizontal
                  autocomplete="true"
                />

                <CRow>
                  <CCol>
                    <label>Giá</label>
                    <div class="input-group">
                      <input
                        id="idcurrency"
                        class="form-control"
                        v-model="passPost.Post_car_price"
                        @blur="formatPrice()"
                        type="text"
                      />
                      <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2"
                          >VND</span
                        >
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Nguồn gốc</label>
                    <input
                      class="form-control"
                      v-model.trim="passPost.Post_car_origin"
                      autocomplete="true"
                  /></CCol>
                  <CCol>
                    <label>Địa chỉ</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_province"
                      list="cityNames"
                      autocomplete="true"
                  /></CCol>
                  <datalist id="cityNames">
                    <option
                      v-for="item in cityNames"
                      :key="item"
                      :value="item"
                    ></option>
                  </datalist>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Số km đã đi</label>
                    <div class="row">
                      <div class="col-2 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-10 pr-0 pl-0 input-group">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_km"
                          type="number"
                          step="1000"
                          min="0"
                          max="1000000"
                        />
                        <div class="input-group-append">
                          <span class="input-group-text" id="basic-addon2"
                            >km</span
                          >
                        </div>
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Số km đi được trên một lít xăng</label>
                    <div class="row">
                      <div class="col-2 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-10 pr-0 pl-0 input-group">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_kpl"
                          type="number"
                          step="10"
                          min="0"
                          max="500"
                        />
                        <div class="input-group-append">
                          <span class="input-group-text" id="basic-addon2"
                            >km</span
                          >
                        </div>
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Mô tả chi tiết</label>
                    <CTextarea rows="4" v-model="passPost.Post_car_detail" />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Ảnh xe</label>
                    <input
                      id="idphotoselector"
                      type="file"
                      multiple
                      horizontal
                      @change="onFileChange"
                    />
                  </CCol>
                </CRow>
                <CRow
                  v-if="
                    passPost.Post_car_frontpic != undefined &&
                    passPost.Post_car_frontpic != '' &&
                    imageFlag
                  "
                >
                  <CCol>
                    <div class="row">
                      <div
                        class="col-12 col-md-6 col-lg-6 col-xl-4"
                        v-for="item in passPost.Post_car_frontpic.substring(
                          0,
                          passPost.Post_car_frontpic.length - 1
                        ).split(',')"
                        :key="item"
                      >
                        <CCardImg
                          style="width: 250px; height: 180px"
                          class="rounded"
                          :src="takePhoto(item)"
                        />
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow v-else>
                  <CCol>
                    <div>
                      <div class="row">
                        <div
                          class="col-12 col-md-6 col-lg-6 col-xl-4"
                          v-for="item in imageSource
                            .substring(0, imageSource.length - 1)
                            .split(',')"
                          :key="item"
                        >
                          <CCardImg
                            style="width: 250px; height: 180px"
                            class="rounded"
                            :src="item"
                          />
                        </div>
                      </div>
                    </div>
                  </CCol>
                </CRow>
              </fieldset>
            </CCol>
            <CCol col="12" md="12" lg="6" sm="12">
              <fieldset class="border pl-4 pr-4 pb-4">
                <legend style="width:0;float-left">Ngoại thất</legend>
                <CInput v-model="passPost.Post_customer_id" hidden />
                <CRow>
                  <CCol>
                    <label>Độ mới(%)</label>
                    <div class="row">
                      <div class="col-3 pr-0">
                        <input
                          class="form-control text-center pr-0 pl-0"
                          value="Trên"
                          readonly
                        />
                      </div>
                      <div class="col-9 pr-0 pl-0">
                        <input
                          class="form-control"
                          v-model="passPost.Post_car_cond"
                          type="number"
                          step="10"
                          min="0"
                          max="100"
                        />
                      </div>
                    </div>
                  </CCol>
                  <CCol>
                    <label>Thông số mâm xe</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_plate"
                      autocomplete="true"
                  /></CCol>
                  <CCol>
                    <label>Thông số lốp xe</label>
                    <input
                      class="form-control"
                      v-model="passPost.Post_car_tire"
                      autocomplete="true"
                    />
                  </CCol>
                </CRow>
                <CRow>
                  <CCol col="3">
                    <fieldset>
                      <legend class="h6 pl-2">Màu xe</legend>
                      <CCol class="form-inline">
                        <input
                          type="color"
                          id="id_outcolor"
                          class="form-control w-75"
                          background-color="light"
                          v-model="passPost.Post_car_outcolor"
                        />
                        <!-- <v-input-colorpicker
                          id="id_outcolor"
                          class="form-control rounded"
                          background-color="light"
                          v-model.trim="passPost.Post_car_outcolor"
                        /> -->
                      </CCol>
                    </fieldset>
                  </CCol>
                  <CCol>
                    <fieldset v-if="passPost.Car_camera != undefined">
                      <legend class="h6 pl-2">Camera</legend>
                      <CCol class="form-inline">
                        <CInputRadio
                          class="pr-5"
                          v-for="(option, optionIndex) in cameras"
                          :key="option"
                          :label="option"
                          type="radio"
                          :value="optionIndex"
                          :custom="true"
                          name="usertype"
                          :checked="passPost.Car_camera.includes(option)"
                          @update:checked="passPost.Car_camera = option"
                        />
                      </CCol>
                    </fieldset>
                  </CCol>
                </CRow>
                <CRow>
                  <CCol>
                    <label>Loại cửa</label>
                    <select
                      class="custom-select form-control"
                      v-model="passPost.Car_doortype"
                    >
                      <option value="Cửa hit">Cửa hit</option>
                      <option value="Cửa thông thường">Cửa thông thường</option>
                      <option value="Khác">Khác...</option>
                    </select>
                  </CCol>
                  <CCol>
                    <label>Loại gương</label>
                    <select
                      class="custom-select form-control"
                      v-model="passPost.Car_mirror"
                    >
                      <option value="Gương chỉnh cơ">Gương chỉnh cơ</option>
                      <option value="Gương chỉnh điện">Gương chỉnh điện</option>
                      <option value="Khác">Khác...</option>
                    </select>
                  </CCol>
                </CRow>
              </fieldset>

              <CRow>
                <fieldset class="border pl-4 pr-4 pb-4 w-100 mt-2">
                  <legend style="width:0;float-left">Nội thất</legend>
                  <CRow>
                    <CCol col="2">
                      <label>Màu nội thất</label>
                      <input
                        type="color"
                        id="id_outcolor"
                        class="form-control"
                        background-color="light"
                        v-model="passPost.Post_car_incolor"
                      />
                      <!-- <v-input-colorpicker
                        class="form-control rounded"
                        id="id_incolor"
                        v-model.trim="passPost.Post_car_incolor"
                        background-color="light"
                      /> -->
                    </CCol>
                    <CCol>
                      <label>Hệ thống âm thanh</label>
                      <input
                        class="form-control"
                        v-model="passPost.Car_sound"
                        autocomplete="true"
                      />
                    </CCol>
                    <CCol>
                      <label>Loại ghế</label>
                      <select
                        class="custom-select form-control"
                        v-model="passPost.Car_seattype"
                      >
                        <option value="Ghế da">Ghế da</option>
                        <option value="Ghế nỉ">Ghế nỉ</option>
                        <option value="Khác">Khác...</option>
                      </select>
                    </CCol>
                  </CRow>
                </fieldset>
              </CRow>
              <CRow>
                <fieldset
                  class="border pl-4 pr-4 pb-4"
                  v-if="passPost.Post_car_anothercare != undefined"
                >
                  <legend style="width:0;float-left">Bảo hiểm xe</legend>
                  <div class="row">
                    <div
                      class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-xs-12 col-12"
                    >
                      <input
                        type="checkbox"
                        id="cares_0"
                        value="Bảo hiểm thân vỏ"
                        :checked="
                          passPost.Post_car_anothercare.includes(
                            'Bảo hiểm thân vỏ'
                          )
                        "
                      />
                      <label for="cares_0" class="pr-4">Bảo hiểm thân vỏ</label>

                      <input
                        type="checkbox"
                        id="cares_1"
                        value="Bảo hiểm trách nhiệm dân sự"
                        :checked="
                          passPost.Post_car_anothercare.includes(
                            'Bảo hiểm trách nhiệm dân sự'
                          )
                        "
                      />
                      <label for="cares_1" class="pr-4"
                        >Bảo hiểm trách nhiệm dân sự</label
                      >
                    </div>
                    <div class="col">
                      <input
                        type="checkbox"
                        id="cares_2"
                        value="Bảo hiểm vật chất"
                        :checked="
                          passPost.Post_car_anothercare.includes(
                            'Bảo hiểm vật chất'
                          )
                        "
                      />
                      <label for="cares_2" class="pr-4"
                        >Bảo hiểm vật chất</label
                      >
                      <input
                        type="checkbox"
                        id="cares_3"
                        value="Bảo hiểm người ngồi trên xe"
                        :checked="
                          passPost.Post_car_anothercare.includes(
                            'Bảo hiểm người ngồi trên xe'
                          )
                        "
                      />
                      <label for="cares_3" class="pr-4"
                        >Bảo hiểm người ngồi trên xe</label
                      >
                    </div>
                  </div>
                </fieldset>
              </CRow>
              <CRow>
                <CCol col="12"
                  ><fieldset
                    class="border pl-4 pr-5 pb-4"
                    v-if="passPost.Car_technology != undefined"
                  >
                    <legend style="width:0;float-left">Trang bị đi kèm</legend>
                    <div class="row">
                      <div
                        class="col-xl-7 col-lg-7 col-md-7 col-sm-12 col-xs-12 col-12 pb-0"
                      >
                        <input type="checkbox" id="technology_0" value="GPS" />
                        <label for="technology_0">GPS</label><br />
                        <input
                          type="checkbox"
                          id="technology_1"
                          value="Màn hình cảm ứng"
                          :checked="
                            passPost.Car_technology.includes('Màn hình cảm ứng')
                          "
                        />
                        <label for="technology_1">Màn hình cảm ứng</label><br />
                        <input
                          type="checkbox"
                          id="technology_2"
                          value="Cửa sổ trời"
                          :checked="
                            passPost.Car_technology.includes('Cửa sổ trời')
                          "
                        />
                        <label for="technology_2">Cửa sổ trời</label><br />
                        <input
                          type="checkbox"
                          id="technology_3"
                          value="Kiểm soát hành trình"
                          :checked="
                            passPost.Car_technology.includes(
                              'Kiểm soát hành trình'
                            )
                          "
                        />
                        <label for="technology_3">Kiểm soát hành trình</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_4"
                          value="Hỗ trợ khởi hành ngang dốc"
                          :checked="
                            passPost.Car_technology.includes(
                              'Hỗ trợ khởi hành ngang dốc'
                            )
                          "
                        />
                        <label for="technology_4"
                          >Hỗ trợ khởi hành ngang dốc</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_5"
                          value="Điều hòa không khí tự động"
                          :checked="
                            passPost.Car_technology.includes(
                              'Điều hòa không khí tự động'
                            )
                          "
                        />
                        <label for="technology_5"
                          >Điều hòa không khí tự động</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_13"
                          value="Kính mầu"
                          :checked="
                            passPost.Car_technology.includes('Kính mầu')
                          "
                        />
                        <label for="technology_13">Kính mầu</label><br />

                        <input
                          type="checkbox"
                          id="technology_14"
                          value="Chống bó cứng phanh (ABS)"
                          :checked="
                            passPost.Car_technology.includes(
                              'Chống bó cứng phanh (ABS)'
                            )
                          "
                        />
                        <label for="technology_14"
                          >Chống bó cứng phanh (ABS)</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_15"
                          value=" Phân bố lực phanh điện tử (EBD)"
                          :checked="
                            passPost.Car_technology.includes(
                              'Phân bố lực phanh điện tử (EBD)'
                            )
                          "
                        />
                        <label for="technology_15"
                          >Phân bố lực phanh điện tử (EBD)</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_16"
                          value="Trợ lực phanh khẩn cấp (EBA)"
                          :checked="
                            passPost.Car_technology.includes(
                              'Trợ lực phanh khẩn cấp (EBA)'
                            )
                          "
                        />
                        <label for="technology_16"
                          >Trợ lực phanh khẩn cấp (EBA)</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_20"
                          value="Đèn sương mù"
                          :checked="
                            passPost.Car_technology.includes('Đèn sương mù')
                          "
                        />
                        <label for="technology_20">Đèn sương mù</label><br />
                      </div>
                      <div class="col">
                        <input
                          type="checkbox"
                          id="technology_6"
                          value="Cốp điện"
                          :checked="
                            passPost.Car_technology.includes('Cốp điện')
                          "
                        />
                        <label for="technology_6">Cốp điện</label><br />
                        <input
                          type="checkbox"
                          id="technology_7"
                          value="Cảnh báo áp suất lốp"
                          :checked="
                            passPost.Car_technology.includes(
                              'Cảnh báo áp suất lốp'
                            )
                          "
                        />
                        <label for="technology_7">Cảnh báo áp suất lốp</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_8"
                          value="Cân bằng điện tử (ESP)"
                          :checked="
                            passPost.Car_technology.includes(
                              'Cân bằng điện tử (ESP)'
                            )
                          "
                        />
                        <label for="technology_8">Cân bằng điện tử (ESP)</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_9"
                          value="Cảnh báo điểm mù"
                          :checked="
                            passPost.Car_technology.includes('Cảnh báo điểm mù')
                          "
                        />
                        <label for="technology_9">Cảnh báo điểm mù</label><br />
                        <input
                          type="checkbox"
                          id="technology_10"
                          value="Cảm biến khoảng cách"
                          :checked="
                            passPost.Car_technology.includes(
                              'Cảm biến khoảng cách'
                            )
                          "
                        />
                        <label for="technology_10">Cảm biến khoảng cách</label
                        ><br />
                        <input
                          type="checkbox"
                          id="technology_11"
                          value="Tay lái trợ lực"
                          :checked="
                            passPost.Car_technology.includes('Tay lái trợ lực')
                          "
                        />
                        <label for="technology_11">Tay lái trợ lực</label><br />
                        <input
                          type="checkbox"
                          id="technology_12"
                          value="Sấy kính sau"
                          :checked="
                            passPost.Car_technology.includes('Sấy kính sau')
                          "
                        />
                        <label for="technology_12">Sấy kính sau</label><br />
                        <input
                          type="checkbox"
                          id="technology_17"
                          value="Chốt cửa an toàn"
                          :checked="
                            passPost.Car_technology.includes('Chốt cửa an toàn')
                          "
                        />
                        <label for="technology_17">Chốt cửa an toàn</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_18"
                          value="Khóa cửa tự động"
                          :checked="
                            passPost.Car_technology.includes('Khóa cửa tự động')
                          "
                        />
                        <label for="technology_18">Khóa cửa tự động</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_19"
                          value="Khóa cửa điện điều khiển từ xa"
                          :checked="
                            passPost.Car_technology.includes(
                              'Khóa cửa điện điều khiển từ xa'
                            )
                          "
                        />
                        <label for="technology_19"
                          >Khóa cửa điện điều khiển từ xa</label
                        ><br />

                        <input
                          type="checkbox"
                          id="technology_21"
                          value="Đèn cảnh báo thắt dây an toàn"
                          :checked="
                            passPost.Car_technology.includes(
                              'Đèn cảnh báo thắt dây an toàn'
                            )
                          "
                        />
                        <label for="technology_22"
                          >Đèn cảnh báo thắt dây an toàn</label
                        ><br />
                      </div>
                    </div></fieldset
                ></CCol>
                <CCol col="12">
                  <fieldset
                    class="border pl-4 pr-4 pb-4"
                    v-if="passPost.Post_car_replaceditems != undefined"
                  >
                    <legend style="width:0;float-left">
                      Linh kiện thay thế
                    </legend>
                    <div class="row">
                      <div class="col">
                        <input
                          type="checkbox"
                          id="replacedItem_0"
                          value="Lốp xe"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Lốp xe')
                          "
                        /><label for="replacedItem_0" class="pl-2">
                          Lốp xe </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_1"
                          value="Lazang"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Lazang')
                          "
                        /><label for="replacedItem_1" class="pl-2">
                          Lazang </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_2"
                          value="Gương"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Gương')
                          "
                        /><label for="replacedItem_2" class="pl-2">
                          Gương </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_3"
                          value="Sơn"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Sơn')
                          "
                        /><label for="replacedItem_3" class="pl-2"> Sơn </label
                        ><br />
                      </div>
                      <div class="col">
                        <input
                          type="checkbox"
                          id="replacedItem_4"
                          value="Đèn"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Đèn')
                          "
                        /><label for="replacedItem_4" class="pl-2"> Đèn </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_5"
                          value="Phanh"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Phanh')
                          "
                        /><label for="replacedItem_5" class="pl-2">
                          Phanh </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_6"
                          value="Loa"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Loa')
                          "
                        /><label for="replacedItem_6" class="pl-2"> Loa </label
                        ><br />

                        <input
                          type="checkbox"
                          id="replacedItem_7"
                          value="Màn hình"
                          :checked="
                            passPost.Post_car_replaceditems.includes('Màn hình')
                          "
                        /><label for="replacedItem_7" class="pl-2">
                          Màn hình </label
                        ><br />
                      </div>
                    </div>
                  </fieldset>
                </CCol>
              </CRow>
            </CCol>
          </CRow>
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton
            color="info"
            v-if="passPost.Post_id == 0"
            @click="insertClick(passPost)"
          >
            Thêm
          </CButton>
          <CButton
            color="info"
            v-if="passPost.Post_id != 0"
            @click="updateClick(passPost)"
          >
            Cập nhật
          </CButton>
          <CButton type="reset" color="danger"> Reset </CButton>
        </CCardFooter>
      </CForm>
    </CCol>
  </div>
</template>
<style scoped>
.text-nowrap {
  white-space: nowrap !important;
}
</style>
<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import { Domain } from "@/constant/constant";
import swal from "sweetalert2";
export default {
  name: "TheCreateEditCarversion",
  components: {},
  props: {
    passPost: {
      type: Object,
      default: () => {},
    },
    imageFlag: {
      type: Boolean,
      default: true,
    },
  },
  mounted() {
    this.getPostcars();
    // if (passPost.Post_car_replaceditems != undefined) {
    //   console.log("hehehehehehe", passPost.Post_car_replaceditems);
    //   this.passPost.Post_car_replaceditems.split(",").forEach((element) => {
    //     $("input[value=" + element + "]").attr("checked", true);
    //   });
    // }
  },
  data() {
    return {
      updatePost: this.passPost,
      imageSource: "",
      filesToSave: { name: null, file: null },
      Selectpostcars: [],
      carUpdate: {},
      postlist: [],
      photoNames: "",
      cityNames: [
        "An Giang",
        "Bà Rịa - Vũng Tàu",
        "Bắc Giang",
        "Bắc Kạn",
        "Bạc Liêu",
        "Bắc Ninh",
        "Bến Tre",
        "Bình Định",
        "Bình Dương",
        "Bình Phước",
        "Bình Thuận",
        "Cà Mau",
        "Cao Bằng",
        "Đắk Lắk",
        "Đắk Nông",
        "Điện Biên",
        "Đồng Nai",
        "Đồng Tháp",
        "Gia Lai",
        "Hà Giang",
        "Hà Nam",
        "Hà Tĩnh",
        "Hải Dương",
        "Hậu Giang",
        "Hòa Bình",
        "Hưng Yên",
        "Khánh Hòa",
        "Kiên Giang",
        "Kon Tum",
        "Lai Châu",
        "Lâm Đồng",
        "Lạng Sơn",
        "Lào Cai",
        "Long An",
        "Nam Định",
        "Nghệ An",
        "Ninh Bình",
        "Ninh Thuận",
        "Phú Thọ",
        "Quảng Bình",
        "Quảng Nam",
        "Quảng Ngãi",
        "Quảng Ninh",
        "Quảng Trị",
        "Sóc Trăng",
        "Sơn La",
        "Tây Ninh",
        "Thái Bình",
        "Thái Nguyên",
        "Thanh Hóa",
        "Thừa Thiên Huế",
        "Tiền Giang",
        "Trà Vinh",
        "Tuyên Quang",
        "Vĩnh Long",
        "Vĩnh Phúc",
        "Yên Bái",
        "Phú Yên",
        "Cần Thơ",
        "Đà Nẵng",
        "Hải Phòng",
        "Hà Nội",
        "TP Hồ Chí Minh",
      ],
      cameras: ["Camera lùi", "Camera 180°", "Camera 360°"],
      carMirrors: ["Gương điện", "Gương tay"],
      domain: Domain,
      horizontal: { label: "col-6", input: "col-6" },
    };
  },
  methods: {
    formatPrice() {
      if (!$("#idcurrency").val().includes(",")) {
        let dollarUSLocale = Intl.NumberFormat("en-US");
        var returnVal = dollarUSLocale.format($("#idcurrency").val());
        $("#idcurrency").val(returnVal);
      }
    },
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.photoNames = "";
      this.imageSource = "";
      for (var i = 0; i < files.length; i++) {
        this.postlist.push(files[i]);
        var folderName = $("#carSelector").val();
        this.photoNames += folderName + "/" + files[i].name + ",";
        this.imageSource += URL.createObjectURL(e.target.files[i]) + ",";
        this.imageFlag = false;
        // this.filesToSave.file = files[0];
        //   formData.append("files[" + i + "]", files[i]);
        // console.log("hehe", this.formData.get("files[" + i + "]"));
      }
      // this.passPost.Post_car_frontpic = this.photoNames;
      //   this.passCarverion.Carversion_ManufacturerLogo = files[0].name;
    },
    getPostcars() {
      axios.get(this.domain + "Car/Get").then((res) => {
        this.Selectpostcars = res.data;
      });
    },
    validator(val) {
      return val ? val.length >= 5 : false;
    },
    takePhoto(value) {
      var images;
      try {
        images = require("@/assets/OldCarPhoto/" + value);
      } catch (e) {
        images = require("@/assets/img/nophoto.png");
      }
      return images;
    },
    insertClick(value) {
      value.Post_car_replaceditems = "";
      value.Car_technology = "";
      value.Post_car_anothercare = "";
      for (var i = 0; i < 8; i++) {
        $("#replacedItem_" + i + "").prop("checked") == true
          ? (value.Post_car_replaceditems +=
              $("#replacedItem_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 22; i++) {
        $("#technology_" + i + "").prop("checked") == true
          ? (value.Car_technology += $("#technology_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 4; i++) {
        $("#cares_" + i + "").prop("checked") == true
          ? (value.Post_car_anothercare += $("#cares_" + i + "").val() + ", ")
          : "";
      }
      value.Post_car_like = 0;
      value.Post_car_date = 0;
      value.Post_car_sold = 0;
      value.Post_car_frontpic = this.photoNames != "" ? this.photoNames : "";
      value.Post_customer_id = this.$auth.user;
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      var folderName = $("#carSelector").val();
      value.Post_car_price = $("#idcurrency").val();
      console.log("hahahahaha123", value);
      axios.post(this.domain + "Post/post", value).then((res) => {
        swal
          .fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          })
          .then((res) => {
            for (var i = 0; i < this.postlist.length; i++) {
              let formData = new FormData();
              formData.append("FilePath", folderName);
              formData.append("filePhotos", this.postlist[i]);
              axios
                .post(this.domain + "Post/SaveMultipleFile", formData, {
                  headers: {
                    "Content-Type": this.filesToSave.type,
                  },
                })
                .then((response) => {
                  console.log(response);
                });
            }
            this.$router.push("/Post/Post");
          });
      });
      // }
    },
    updateClick(value) {
      value.Post_car_replaceditems = "";
      value.Car_technology = "";
      value.Post_car_anothercare = "";
      for (var i = 0; i < 8; i++) {
        $("#replacedItem_" + i + "").prop("checked") == true
          ? (value.Post_car_replaceditems +=
              $("#replacedItem_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 22; i++) {
        $("#technology_" + i + "").prop("checked") == true
          ? (value.Car_technology += $("#technology_" + i + "").val() + ", ")
          : "";
      }
      for (var i = 0; i < 4; i++) {
        $("#cares_" + i + "").prop("checked") == true
          ? (value.Post_car_anothercare += $("#cares_" + i + "").val() + ", ")
          : "";
      }
      value.Post_car_like = 0;
      value.Post_car_date = 0;
      value.Post_car_frontpic = this.photoNames != "" ? this.photoNames : "";
      value.Post_customer_id = this.$auth.user;
      // this.accountname_valid = this.validator(this.passAccount.Account_name);
      // this.accountpassword_valid = this.validator(
      //   this.passAccount.Account_password
      // );
      // if (this.accountname_valid && this.accountpassword_valid) {
      var carSelect = $("#carSelector").val();
      var folderName = $("#carSelector")
        .find("option[value=" + carSelect + "]")
        .text()
        .replaceAll(" ", "")
        .replaceAll("\n", "");
      value.Post_car_sold = $('#idsold').val() == "true" ? 1 : 0;
      value.Post_car_price = $("#idcurrency").val();
      axios.put(this.domain + "Post/put", value).then((res) => {
        swal
          .fire({
            position: "center",
            icon: res.data.split("-")[0] == "1" ? "success" : "error",
            title: res.data.split("-")[1],
            showConfirmButton: false,
            timer: 1500,
          })
          .then((res) => {
            for (var i = 0; i < this.postlist.length; i++) {
              let formData = new FormData();
              formData.append("FilePath", folderName);
              formData.append("filePhotos", this.postlist[i]);
              axios
                .post(this.domain + "Post/SaveMultipleFile", formData, {
                  headers: {
                    "Content-Type": this.filesToSave.type,
                  },
                })
                .then((response) => {
                  console.log(response);
                });
            }
            this.$router.push("/Post/Post");
          });
      });
      // }
    },
  },
};
</script>
