<template>
  <Layout>
    <PageHeader :title="title" :items="siteCrumbs" />
    <Grid :title="title" :fields="tableHeaders" :tableData="tableData">
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
        <b-button
          variant="danger"
          class="mx-1"
          title="Delete user"
          @click.prevent="deleteUser(data.item.publicId)"
        >
          <i class="bx bxs-x-square font-size-16 align-middle me-2"></i>
          Delete
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

<script>
import axios from "@/helpers/http-comunicator";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import appConfig from "@/app.config";
import Grid from "@/components/et-grid";

export default {
  page: {
    title: "Users List",
    meta: [
      {
        name: "users",
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
      title: "Users",
      siteCrumbs: [
        {
          text: "Dashboard",
          href: "/",
        },
        {
          text: "Users",
          active: true,
        },
      ],
      tableHeaders: [
        {
          key: "firstName",
          sortable: true,
        },
        {
          key: "lastName",
          sortable: true,
        },
        {
          key: "userName",
          sortable: true,
        },
        {
          key: "email",
          sortable: true,
        },
        { key: "actions", label: "Actions" },
      ],
    };
  },

  mounted() {
    this.getUsers();
  },

  methods: {
    getUsers() {
      axios.get("users-module/Users").then((res) => {
        this.tableData = res.data.userListVm.users;
      });
    },
    deleteUser(userPublicId) {
      if (userPublicId) {
        this.$etConfirm().then((actionResult) => {
          if (actionResult.isConfirmed) {
            axios.delete(`users-module/Users/${userPublicId}`).then(() => {
              this.$etToast("Operation completed!");
            });
          }
        });
      }
    },
  },
};
</script>