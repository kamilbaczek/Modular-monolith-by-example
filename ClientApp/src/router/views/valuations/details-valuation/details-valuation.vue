<script>
import axios from "@/helpers/http-comunicator";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import SuggestProposalModal from "./suggest-proposal-modal/suggest-proposal-modal";
import ListServices from "./list-services/list-services";

import appConfig from "@/app.config";

export default {
  page: {
    title: "Valuations Details",
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
    ListServices,
    SuggestProposalModal,
  },
  data() {
    return {
      valuationId: "",
      details: {},
      servicesIds: [],
      title: "Valuations",
      items: [
        {
          text: "Valuations",
          href: "/valuations/",
        },
        {
          text: "Details",
          active: true,
        },
      ],
    };
  },
  mounted() {
    this.valuationId = this.$route.params.id;
    axios
      .get(`valuations-module/valuations/${this.valuationId}`)
      .then((res) => {
        this.details = res.data.valuationDetails;
        this.servicesIds = res.data.valuationDetails.services.map(
          (service) => service.serviceId
        );
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
    <div class="row" v-if="details.information">
      <div class="col-lg-12">
        <div class="card">
          <div class="card-body">
            <div class="invoice-title">
              <h4 class="float-end font-size-16">
                Identifier: <b>{{ details.information.id }}</b>
              </h4>
              <div class="mb-4">
                <img
                  src="@/assets/images/logo-small.png"
                  alt="logo"
                  height="30"
                />
              </div>
            </div>
            <hr />
            <div class="row">
              <div class="col-6">
                <strong>From:</strong>
                <br />
                {{ details.information.fullName }} <br />{{
                  details.information.email
                }}
              </div>
              <div class="col-6 text-sm-end">
                <address>
                  <strong>Requested Date:</strong>
                  <br />{{ details.information.requestedDate }}
                </address>
              </div>
            </div>
            <ListServices
              :servicesIds="servicesIds"
              :clientFullName="details.information.fullName"
            ></ListServices>
            <div class="d-print-none">
              <div class="float-end">
                <a
                  href="javascript:window.print()"
                  class="btn btn-success waves-effect waves-light me-1"
                  ><i class="fa fa-print"></i
                ></a>
                <button
                  @click.prevent="openSuggestModal()"
                  class="btn btn-danger w-lg waves-effect waves-light"
                >
                  <i class="fa fa-comments-dollar"></i> Suggest
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <SuggestProposalModal
      ref="suggest-proposal-modal"
      v-if="valuationId"
      :valuationId="valuationId"
    ></SuggestProposalModal>
  </Layout>
</template>
