<template>
  <div>
    <CCol md="12">
      <CForm class="form-insert-update">
        <CCardBody>
          <CInput
            placeholder="Account name"
            label="Account name"
            horizontal
            autocomplete="name"
            valid-feedback=""
            invalid-feedback="Please provide at least 10 characters."
            :is-valid="validator"
          />
          <CInput
            type="password"
            label="Password"
            placeholder="Password"
            horizontal
            autocomplete="address"
            valid-feedback=""
            invalid-feedback="Please provide at least 10 characters."
            :is-valid="validator"
          />
          <div :key="name" class="form-row form-group">
            <CCol sm="3">Role</CCol>
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
        </CCardBody>
        <CCardFooter class="text-center">
          <CButton type="submit" size="md" color="info" v-if="account.accountId==0"> Insert </CButton>
          <CButton type="submit" size="md" color="info" v-if="account.accountId!=0"> Update </CButton>
          <CButton type="reset" size="md" color="danger"> Reset </CButton>
        </CCardFooter>
      </CForm>
    </CCol>
  </div>
</template>

<script>
import axios from "axios";
import { freeSet } from "@coreui/icons";
import swal from "sweetalert2";

export default {
  name: "TheCreateEditAccount",
  props:{
    account:{
      type: Array,
      default:()=>[],
    }
  },
  data() {
    return {
      selected: [], // Must be an array reference!
      show: true,
      horizontal: { label: "col-3", input: "col-9" },
      options: ["News", "Entertainment", "Technology", "Work", "Fashion"],
      radioOptions: ["Admin", "User"],
    };
  },
  methods: {
    validator(val) {
      return val ? val.length >= 10 : false;
    },
  },
};
</script>
