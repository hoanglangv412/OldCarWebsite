<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <CInput
            placeholder="Enter the account name"
            label="Blog name"
            horizontal
            autocomplete="name"
            valid-feedback=""
            invalid-feedback="Please provide at least 4 characters."
            :is-valid="validator"
          />
          <CInput
            label="Address"
            placeholder="Enter the address"
            horizontal
            autocomplete="address"
            valid-feedback=""
            invalid-feedback="Please provide at least 4 characters."
            :is-valid="validator"
          />
          <CInput
            label="Posting date"
            :value="moment(date).format('YYYY/MM/DD')"
            horizontal
            disabled
          />
          <CSelect
            label="Select"
            horizontal
            :options="options"
            placeholder="Please select"
          />
          <CInput
            label="Short detail"
            placeholder="Enter short information about this blog"
            horizontal
            autocomplete="ShortDetail"
            valid-feedback=""
            invalid-feedback="Please provide at least 4 characters."
            :is-valid="validator"
          />
          <CTextarea
            label="Detail"
            placeholder="Type something about this blog"
            horizontal
            rows="9"
          />
          <div :key="name" class="form-row form-group">
            <CCol sm="3"> Status </CCol>
            <CCol sm="9" :class="form - inline">
              <CInputRadio
                v-for="(option, optionIndex) in radioOptions"
                :key="key + option"
                :label="option"
                :type="radio"
                :value="option"
                :custom="true"
                :name="`Option 1${key}`"
                :checked="optionIndex === key"
              />
            </CCol>
          </div>
          <CInputFile label="File input" horizontal />
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton type="submit" size="md" color="info"> Submit </CButton>
          <CButton type="reset" size="md" color="danger"> Reset </CButton>
        </CCardFooter>
      </CForm>
    </CCol>
  </div>
</template>

<script>
export default {
  name: "TheCreateAndEditAccount",
  data() {
    return {
      selected: [], // Must be an array reference!
      show: true,
      horizontal: { label: "col-3", input: "col-9" },
      options: ["News", "Entertainment", "Technology", "Work", "Fashion"],
      radioOptions: ["Inactive", "Active"],
    };
  },
  methods: {
    validator(val) {
      return val ? val.length >= 0 : false;
    },
    getDatetimenow() {
      const today = new Date();
      const date =
        today.getFullYear() +
        "/" +
        (today.getMonth() + 1) +
        "/" +
        today.getDate();
      const time = today.getHours() + ":" + today.getMinutes();
      const dateTime = date + " " + time;
      return dateTime;
    },
  },
};
</script>
