import Vue from "vue";
import BootstrapVue from "bootstrap-vue";
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

Vue.component("tinymce", tinymce);
Vue.use(VueRouter);
Vue.use(vco);
Vue.use(Scrollspy);
const VueScrollTo = require("vue-scrollto");
Vue.use(VueScrollTo);
Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(Vuelidate);
Vue.use(VueMask);
Vue.use(require("vue-chartist"));
Vue.use(VueSweetalert2);
Vue.use(VueGoogleMaps, {
  load: {
    key: "AIzaSyAbvyBxmMbFhrzP9Z8moyYr6dCr-pzjhBE",
    libraries: "places",
  },
  installComponents: true,
});
Vue.component("apexchart", VueApexCharts);

new Vue({
  router,
  store,
  i18n,
  render: (h) => h(App),
}).$mount("#app");
