<script>
import axios from "@/helpers/http-comunicator";

export default {
  props: {
    servicesIds: {
      type: Array,
      default: () => [],
    },
    clientFullName: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      services: [],
    };
  },
  mounted() {
    axios
      .get("services-module/Services/batch", {
        params: {
          servicesIds: this.servicesIds,
        },
        paramsSerializer: (params) => {
          var queryStringBuilder = require("qs");
          return queryStringBuilder.stringify(params, {
            arrayFormat: "repeat",
          });
        },
      })
      .then((res) => {
        this.services = res.data;
      });
  },
  methods: {},
};
</script>

<template>
  <div v-if="services.length > 0" class="col-lg-6">
    <div class="card p-1">
      <div class="card-body">
        <h3 class="card-title">Inquiry</h3>
        <p class="card-title-desc">
          Services that {{ clientFullName }} requsted:
        </p>
        <div role="tablist">
          <b-card
            v-for="(service, index) in services"
            :key="`service-${index}`"
            no-body
            class="mb-1 shadow-none"
          >
            <b-card-header header-tag="header" role="tab">
              <h6 class="m-0">
                <span class="badge bg-danger mx-1">{{
                  service.category.name
                }}</span>
                <a
                  v-b-toggle.accordion-index
                  class="text-dark"
                  href="javascript: void(0);"
                  >{{ service.name }}</a
                >
              </h6>
            </b-card-header>
            <b-collapse
              :id="index"
              visible
              accordion="my-accordion"
              role="tabpanel"
            >
              <b-card-body>
                <b-card-text>{{ service.description }}</b-card-text>
              </b-card-body>
            </b-collapse>
          </b-card>
        </div>
      </div>
    </div>
  </div>
</template>
