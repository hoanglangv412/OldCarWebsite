<template>
  <CHeader fixed with-subheader light class="bg-dark">
    <div class="row">
      <CToggler
        v-c-emit-root-event:toggle-sidebar-mobile
        in-header
        class="ml-3 d-lg-none col-1"
      />
      <CToggler
        v-c-emit-root-event:toggle-sidebar
        in-header
        class="ml-3 d-md-down-none col-1"
        style="color: white"
      />
      <div class="col">
        <CHeaderNav class="mr-auto w-100">
          <nav class="navbar navbar-expand-lg navbar-dark bg-dark w-100">
            <a
              class="navbar-brand mr-5"
              href="/Home/Home"
              style="font-size: 25px"
              >Trang chủ</a
            >
            <button
              class="navbar-toggler"
              type="button"
              data-toggle="collapse"
              data-target="#navbarSupportedContent"
              aria-controls="navbarSupportedContent"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
              <span class="navbar-toggler-icon"></span>
            </button>

            <div
              class="collapse navbar-collapse w-100"
              id="navbarSupportedContent"
            >
              <div class="row">
                <div class="col-12 col-xl-3 col-lg-4 col-md-12 col-xs-12">
                  <ul class="navbar-nav">
                    <li class="nav-item dropdown">
                      <a
                        class="nav-link dropdown-toggle"
                        style="font-size: 20px"
                        id="navbarDropdown"
                        role="button"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                      >
                        Hãng xe
                      </a>
                      <div
                        class="dropdown-menu"
                        style="width: 1100px"
                        aria-labelledby="navbarDropdown"
                      >
                        <div class="row">
                          <div
                            class="col-2"
                            v-for="item in Manufacturers"
                            :key="item"
                          >
                            <CButton
                              class="dropdown-item"
                              style="min-width: 0"
                              :to="`/SearchName/${item}`"
                            >
                              {{ item }}
                            </CButton>
                          </div>
                        </div>
                      </div>
                    </li>
                    <li class="nav-item dropdown">
                      <a
                        class="nav-link dropdown-toggle"
                        id="navbarDropdown"
                        role="button"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                        style="font-size: 20px"
                      >
                        Đời
                      </a>
                      <div
                        class="dropdown-menu"
                        style="width: 100px; height: 200px; overflow: scroll"
                        aria-labelledby="navbarDropdown"
                      >
                        <CButton
                          v-for="item in carDates"
                          :key="item"
                          class="dropdown-item"
                          style="min-width: 0"
                          :to="`/SearchName/${item}`"
                        >
                          {{ item }}
                        </CButton>
                      </div>
                    </li>
                    <li class="nav-item dropdown">
                      <a
                        class="nav-link dropdown-toggle"
                        id="navbarDropdown"
                        role="button"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                        style="font-size: 20px"
                      >
                        Địa chỉ
                      </a>
                      <div
                        class="dropdown-menu"
                        style="width: 800px"
                        aria-labelledby="navbarDropdown"
                      >
                        <div class="row">
                          <div
                            class="col-2"
                            v-for="item in cityNames"
                            :key="item"
                          >
                            <CButton
                              class="dropdown-item"
                              style="min-width: 0"
                              :to="`/SearchName/${item}`"
                            >
                              {{ item }}
                            </CButton>
                          </div>
                        </div>
                      </div>
                    </li>
                  </ul>
                </div>
                <div class="col d-flex align-items-center">
                  <div class="row">
                    <div class="col-8">
                      <div class="input-group">
                        <input
                          id="id_searchvalue"
                          class="form-control"
                          type="search"
                          placeholder="Nhập thông tin xe"
                          aria-label="Search"
                        />
                        <div class="input-group-append">
                          <CButton
                            class="btn btn-outline-info"
                            @click="searchClick()"
                          >
                            Tìm
                          </CButton>
                        </div>
                      </div>
                    </div>
                    <div class="col-2">
                      <CButton
                        class="btn btn-outline-success"
                        v-if="this.Role == 1"
                        to="/Home/HomeCarForPost"
                      >
                        Tạo bài đăng +
                      </CButton>
                    </div>
                    <div class="col-2 pl-1 pr-1">
                      <TheHeaderDropdownAccnt />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </nav>
        </CHeaderNav>
      </div>
    </div>
  </CHeader>
</template>
<script>
import TheHeaderDropdownAccnt from "./TheHeaderDropdownAccnt";

export default {
  name: "TheHeader",
  components: {
    TheHeaderDropdownAccnt,
  },
  mounted() {
    for (var i = 1970; i < 2100; i++) {
      this.carDates.push(i);
    }
  },
  updated() {
    this.Role =
      this.$auth.$storage.getUniversal("userInfo") == null
        ? 2
        : this.$auth.$storage.getUniversal("userInfo").Account_role;
  },
  data() {
    return {
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
      Manufacturers: [
        "Acura",
        "Alfa Romeo",
        "Audi",
        "BMW",
        "Bentley",
        "Buick",
        "Cadillac",
        "Chevrolet",
        "Chrysler",
        "Dodge",
        "Fiat",
        "Ford",
        "GMC",
        "Genesis",
        "Honda",
        "Hyundai",
        "Infiniti",
        "Jaguar",
        "Jeep",
        "Kia",
        "Land Rover",
        "Lexus",
        "Lincoln",
        "Lotus",
        "Maserati",
        "Mazda",
        "Mercedes-Benz",
        "Mercedes-Benz AMG",
        "Mercury",
        "Mini",
        "Mitsubishi",
        "Nikola",
        "Nissan",
        "Polestar",
        "Pontiac",
        "Porsche",
        "Ram",
        "Rivian",
        "Rolls-Royce",
        "Saab",
        "Saturn",
        "Scion",
        "Smart",
        "Subaru",
        "Suzuki",
        "Tesla",
        "Toyota",
        "Volkswagen",
        "Volvo",
        "Vinfast",
      ],
      carDates: [],
      Role: null,
    };
  },
  methods: {
    searchClick() {
      console.log("hahahahaha", "/SearchName/" + $("#id_searchvalue").val());
      this.$router.push("/SearchName/" + $("#id_searchvalue").val());
    },
  },
};
</script>
