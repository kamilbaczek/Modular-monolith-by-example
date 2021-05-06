<template>
  <Layout>
    <PageHeader :title="title" :items="siteCrumbs" />
    <Grid :title="title" :fields="tableHeaders" :tableData="tableData">
      <template v-slot:actions="data">
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