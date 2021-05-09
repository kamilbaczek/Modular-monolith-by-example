import Vue from "vue";
import BootstrapVue from "bootstrap-vue";

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VueApexCharts from "vue-apexcharts";
import Vuelidate from "vuelidate";
import * as VueGoogleMaps from "vue2-google-maps";
import VueMask from "v-mask";
import VueRouter from "vue-router";
import vco from "v-click-outside";
import router from "./router/index";
import Scrollspy from "vue2-scrollspy";
import VueSweetalert2 from "vue-sweetalert2";
import 'sweetalert2/dist/sweetalert2.min.css';
import "../src/design/app.scss";

import store from "@/state/store";

import App from "./App.vue";

import i18n from "./i18n";

import tinymce from "vue-tinymce-editor";

//vee-validate
import { ValidationObserver, ValidationProvider, extend, localize} from "vee-validate";
import * as rules from "vee-validate/dist/rules";
import en from "vee-validate/dist/locale/en.json";

//custom plugins
import EtToast from '@/plugins/et-toast';
import EtConfirm from '@/plugins/et-confirm';

Vue.use(VueRouter);
Vue.use(vco);
Vue.use(Scrollspy);

const VueScrollTo = require("vue-scrollto");
Vue.use(VueScrollTo);

Vue.use(BootstrapVue);
Vue.use(Vuelidate);
Vue.use(VueMask);
Vue.use(require("vue-chartist"));
Vue.use(VueSweetalert2);
Vue.use(VueMask);
Vue.use(EtToast);
Vue.use(EtConfirm);
Vue.use(VueGoogleMaps, {
  load: {
    key: "AIzaSyAbvyBxmMbFhrzP9Z8moyYr6dCr-pzjhBE",
    libraries: "places",
  },
  installComponents: true,
});

Vue.component("apexchart", VueApexCharts);
Vue.component('ValidationProvider', ValidationProvider);
Vue.component("ValidationObserver", ValidationObserver);
Vue.component("tinymce", tinymce);

Object.keys(rules).forEach(rule => {
  extend(rule, rules[rule]);
});
localize("en", en);


Vue.config.productionTip = false;

new Vue({
  router,
  store,
  i18n,
  render: (h) => h(App),
}).$mount("#app");
