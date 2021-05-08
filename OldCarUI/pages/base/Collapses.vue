<template>
  <CRow>
    <CCol col="12">
      <CCard>
        <CCardBody>
          <div class="row">
            <div class="col">
              <h6>Thông tin người bán cung cấp</h6>
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
            <CCard body-wrapper>
              <CCardText>Collapse contents Here</CCardText>
              <CButton
                size="sm"
                color="secondary"
                @click="innerCollapse = !innerCollapse"
              >
                Toggle Inner Collapse
              </CButton>
              <CCollapse :show="innerCollapse" class="mt-2">
                <CCard body-wrapper> Hello! </CCard>
              </CCollapse>
            </CCard>
          </CCollapse>
        </CCardBody>
      </CCard>
      <CCard>
        <CCardBody>
          <div class="row">
            <div class="col">
              <h6>Thông số kĩ thuật</h6>
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
            <CCard body-wrapper>
              <CCardText>Collapse contents Here</CCardText>
              <CButton
                size="sm"
                color="secondary"
                @click="innerCollapse1 = !innerCollapse1"
              >
                Toggle Inner Collapse
              </CButton>
              <CCollapse :show="innerCollapse1" class="mt-2">
                <CCard body-wrapper> Hello! </CCard>
              </CCollapse>
            </CCard>
          </CCollapse>
        </CCardBody>
      </CCard>
      <CCard>
        <CCardBody>
          <div class="row">
            <div class="col">
              <h6>Bảo hiểm xe</h6>
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
            <CCard body-wrapper>
              <CCardText>Collapse contents Here</CCardText>
              <CButton
                size="sm"
                color="secondary"
                @click="innerCollapse2 = !innerCollapse2"
              >
                Toggle Inner Collapse
              </CButton>
              <CCollapse :show="innerCollapse2" class="mt-2">
                <CCard body-wrapper> Hello! </CCard>
              </CCollapse>
            </CCard>
          </CCollapse>
        </CCardBody>
      </CCard>
    </CCol>
  </CRow>
</template>

<script>
export default {
  name: "Collapses",
  data() {
    return {
      collapse: false,
      innerCollapse: false,
      collapse1: false,
      innerCollapse1: false,
      collapse2: false,
      innerCollapse2: false,
      text: `
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry
        richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor
        brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon
        tempor, sunt aliqua put a bird on it squid single-origin coffee nulla
        assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore
        wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher
        vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic
        synth nesciunt you probably haven't heard of them accusamus labore VHS.
      `,
    };
  },
};
</script>
