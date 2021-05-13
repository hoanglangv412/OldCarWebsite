<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <carousel
            :per-page="1"
            :paginationEnabled="false"
            :navigationEnabled="true"
            :navigationNextLabel="Next"
            :navigationPrevLabel="Prev"
            :mouseDrag="false"
          >
            <slide v-for="photoLink in passPhoto" :key="photoLink">
              <CImg :src="takePhoto(photoLink)" block  class="w-100 h-100"/>
            </slide>
          </carousel>
        </CCardBody>
      </CForm>
    </CCol>
  </div>
</template>
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
