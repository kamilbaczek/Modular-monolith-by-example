<template>
  <Layout>
    <PageHeader :title="title" :items="siteCrumbs" />

    <Grid :title="title" :fields="tableHeaders" :tableData="tableData">
      <template #headerButtons>
        <router-link tag="span" to="/add-new-service">
          <b-button
            variant="info"
            class="mx-1"
            v-b-tooltip.hover
          >
            <i class="bx bx-plus font-size-16 align-middle me-2"></i>
            Add new
          </b-button>
        </router-link>
      </template>
      <template v-slot:actions="data">
        <b-button
          variant="danger"
          class="mx-1"
          v-b-tooltip.hover
          title="Delete service"
          @click.prevent="deleteService(data.item.id)"
        >
          <i class="bx bxs-x-square font-size-16 align-middle me-2"></i>
          Delete
        </b-button>
      </template>
    </Grid>
  </Layout>
</template>

<script>
import axios from "@/helpers/http-comunicator";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import appConfig from "@/app.config";
import Grid from "@/components/et-grid";

export default {
  components: {
    Layout,
    PageHeader,
    Grid,
  },

  page: {
    title: "Services List",
    meta: [
      {
        name: "services",
        content: appConfig.description,
      },
    ],
  },

  data() {
    return {
      tableData: [],

      title: "Services",

      siteCrumbs: [
        {
          text: "Dashboard",
          href: "/",
        },
        {
          text: "Services",
          active: true,
        },
      ],

      tableHeaders: [
        {
          key: "name",
          sortable: true,
        },
        {
          key: "description",
          sortable: true,
        },
        {
          key: "category",
          sortable: true,
        },
        {
          key: "actions",
        },
      ],
    };
  },

  mounted() {
    this.getServices();
  },

  methods: {

    getServices() {
      axios.get("services-module/Services").then((res) => {
        this.tableData = res.data;
      });
    },
    deleteService(serviceId) {
      if (serviceId) {
        this.$etConfirm().then((actionResult) => {
          if (actionResult.isConfirmed) {
            axios.delete(`services-module/Services/${serviceId}`).then(() => {
              this.$etToast("Operation completed!");
            });
          }
        });
      }
    },
  },
};
</script>
