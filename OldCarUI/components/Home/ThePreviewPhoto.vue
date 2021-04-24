<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <carousel
            :per-page="1"
            :paginationEnabled="true"
            paginationPosition="bottom-overlay"
            :navigationEnabled="true"
            :navigationNextLabel="Next"
            :navigationPrevLabel="Prev"
            :mouseDrag="false"
          >
            <slide v-for="photoLink in passPhoto" :key="photoLink">
              <CImg :src="takePhoto(photoLink)" block />
            </slide>
          </carousel>
        </CCardBody>
      </CForm>
    </CCol>
  </div>
</template>
<style>
.VueCarousel-slide img {
  height: 500px !important;
  width: auto !important;
  margin: 0 auto;
}
</style>
<script>
import { Carousel, Slide } from "vue-carousel";

export default {
  name: "TheCreateEditAccount",
  components: {
    Carousel,
    Slide,
  },
  props: {
    passPhoto: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {};
  },
  methods: {
    takePhoto(value) {
      if (value) {
        var images;
        try {
          images = require("@/assets/OldCarPhoto/" + value);
        } catch (e) {
          images = require("@/assets/img/nophoto.png");
        }
        return images;
      }
    },
    deleteClass() {
      console.log(1);
      document.querySelectorAll(".carousel-item").classList.remove("active");
    },
  },
};
</script>
