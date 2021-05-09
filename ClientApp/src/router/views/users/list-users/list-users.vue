<template>
  <Layout>
    <PageHeader :title="title" :items="siteCrumbs" />

    <Grid :title="title" :fields="tableHeaders" :tableData="tableData">
      <template #headerButtons>
        <b-button variant="info" class="mx-1" v-b-tooltip.hover title="Suggest proposal" @click="openModalForm()">
          <i class="bx bx-plus font-size-16 align-middle me-2"></i>
          Add new
        </b-button>
      </template>
      <template v-slot:actions="data">
        <b-button variant="info" class="mx-1" v-b-tooltip.hover title="Edit" @click="openModalForm()">
          <i class="bx bx-detail font-size-16 align-middle me-2"></i>
          Edit
        </b-button>
        <b-button variant="danger" class="mx-1" v-b-tooltip.hover title="Delete user" @click.prevent="deleteUser(data.item.publicId)">
          <i class="bx bxs-x-square font-size-16 align-middle me-2"></i>
          Delete
        </b-button>

      </template>
    </Grid>

    <!-- MODAL -->
    <b-modal ref="user-form-modal" title="Add user" hide-footer size="md" centered>
      <UserForm />
    </b-modal>

  </Layout>
</template>

<script>
import axios from "@/helpers/http-comunicator";
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import UserForm from "@/components/users/user-form.vue";
import appConfig from "@/app.config";
import Grid from "@/components/et-grid";

export default {
  components: {
    Layout,
    PageHeader,
    Grid,
    UserForm,
  },

  page: {
    title: "Users List",
    meta: [
      {
        name: "users",
        content: appConfig.description,
      },
    ],
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
        {
          key: "actions",
        },
      ],
    };
  },

  mounted() {
    this.getUsers();
  },

  methods: {
    openModalForm() {
      this.$refs["user-form-modal"].show();
    },

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