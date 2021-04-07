import Vue from 'vue'
import CoreuiVue from '@coreui/vue'
import moment from 'moment'
export default () => {
  Vue.use(CoreuiVue)
  Vue.prototype.moment = moment
}
