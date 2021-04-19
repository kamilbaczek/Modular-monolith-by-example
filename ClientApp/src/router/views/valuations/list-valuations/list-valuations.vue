<script>
import axios from "axios";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import appConfig from "@/app.config";
import Grid from "@/components/et-grid";

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
          key: "lastName",
          sortable: true,
        },
        {
          key: "requestedDate",
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
      .get("https://localhost:5001/api/valuations-module/Valuations", {
        headers: {
          "Content-type": "application/json;charset=utf-8",
        },
      })
      .then((res) => {
        this.tableData = res.data.valuations;
      });
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
          variant="warning"
          class="mx-1"
          v-b-tooltip.hover
          title="Suggest valuation proposal"
        >
          <i class="bx bxs-comment-add font-size-16 align-middle me-2"></i>
          Suggest
        </b-button>
        <b-button variant="info" class="mx-1" title="Go to details">
          <i class="bx bx-detail font-size-16 align-middle me-2"></i>
          Details
        </b-button>
      </template>
    </Grid>
  </Layout>
</template>
