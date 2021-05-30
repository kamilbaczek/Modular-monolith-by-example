<script>
import axios from "@/helpers/http-comunicator";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import appConfig from "@/app.config";
import Grid from "@/components/et-grid";
import Status from "../components/status.vue";

export default {
  page: {
    title: "Valuations List",
    meta: [
      {
        name: "valuations",
        content: appConfig.description,
      },
    ],
  },
  components: {
    Layout,
    PageHeader,
    Grid,
    Status,
  },
  data() {
    return {
      tableData: [],
      title: "Valuations",
      items: [
        {
          text: "Dashboard",
          href: "/",
        },
        {
          text: "Valuations",
          active: true,
        },
      ],
      fields: [
        {
          key: "fullName",
          sortable: true,
        },
        {
          key: "requestedDate",
          sortable: true,
        },
        {
          key: "status",
          sortable: true,
        },
        { key: "actions", label: "Actions" },
      ],
      totalRows: 1,
    };
  },
  mounted() {
    this.totalRows = this.items.length;
    axios
      .get("valuations-module/Valuations", {
        headers: {
          "Content-type": "application/json;charset=utf-8",
        },
      })
      .then((res) => {
        this.tableData = res.data.valuations;
      });
  },
  methods: {
    goToDetails(id) {
      this.$router.push({ name: "details-valuation", params: { id: id } });
    },
  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />
    <Grid
      :title="title"
      :fields="fields"
      :tableData="tableData"
      :totalRows="totalRows"
    >
      <template v-slot:actions="data">
        <b-button
          @click.prevent="goToDetails(data.item.id)"
          variant="info"
          class="mx-1"
          title="Go to details"
        >
          <i class="bx bx-detail font-size-16 align-middle me-2"></i>
          Details
        </b-button>
      </template>

      <template v-slot:status="data">
        <Status :status="data.item.status"></Status>
      </template>
    </Grid>
  </Layout>
</template>
