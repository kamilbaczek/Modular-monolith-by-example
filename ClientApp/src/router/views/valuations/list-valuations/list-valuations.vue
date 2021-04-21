<script>
import axios from "@/helpers/http-comunicator";
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
    openSuggestModal() {
      this.$refs["suggest-proposal-modal"].show();
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
          variant="warning"
          class="mx-1"
          v-b-tooltip.hover
          title="Suggest proposal"
          @click="openSuggestModal()"
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
    <b-modal
      ref="suggest-proposal-modal"
      title="Suggest proposal"
      hide-footer
      size="lg"
      centered
    >
      <div class="card-body">
        <form>
          <div class="row">
            <div class="col-lg-4">
              <div class="mb-3">
                <label for="price">Price</label>
                <input
                  type="text"
                  class="form-control"
                  id="price"
                  placeholder="Enter Price"
                  v-mask="'###.###.###.###.###,##'"
                />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-lg-12">
              <div class="mb-3">
                <label for="message">Message</label>
                <textarea class="form-control" id="message" rows="3"></textarea>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-lg-12">
              <div class="text-end">
                <b-button variant="success" class="mx-1" title="Go to details">
                  <i
                    class="bx bx bx-mail-send font-size-16 align-middle me-2"
                  ></i>
                  Send
                </b-button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </b-modal>
  </Layout>
</template>
