<template>
  <div class="card-body">
    <validation-observer ref="observer" v-slot="{ invalid, handleSubmit }">
      <b-form @submit.stop.prevent="handleSubmit(onSubmit)">
        <div class="col-lg-7">
          <validation-provider
            name="User name"
            rules="required|min:3|alpha_num"
            v-slot="validationContext"
          >
            <b-form-group label="User name">
              <b-form-input
                id="userName"
                name="userName"
                v-model="form.userName"
                :state="getValidationState(validationContext)"
              />
              <b-form-invalid-feedback>
                {{ validationContext.errors[0] }}
              </b-form-invalid-feedback>
            </b-form-group>
          </validation-provider>
        </div>

        <div class="col-lg-7">
          <validation-provider
            name="First name"
            rules="required|min:3|alpha"
            v-slot="validationContext"
          >
            <b-form-group label="First name">
              <b-form-input
                id="firstName"
                name="firstName"
                v-model="form.firstName"
                :state="getValidationState(validationContext)"
              />
              <b-form-invalid-feedback>
                {{ validationContext.errors[0] }}
              </b-form-invalid-feedback>
            </b-form-group>
          </validation-provider>
        </div>

        <div class="col-lg-7">
          <validation-provider
            name="Last name"
            rules="required|min:3|alpha"
            v-slot="validationContext"
          >
            <b-form-group label="Last name">
              <b-form-input
                id="lastName"
                name="lastName"
                v-model="form.lastName"
                :state="getValidationState(validationContext)"
              />
              <b-form-invalid-feedback>
                {{ validationContext.errors[0] }}
              </b-form-invalid-feedback>
            </b-form-group>
          </validation-provider>
        </div>

        <div class="col-lg-7">
          <validation-provider
            name="Email"
            rules="required|email"
            v-slot="validationContext"
          >
            <b-form-group label="Email">
              <b-form-input
                id="email"
                name="email"
                v-model="form.email"
                :state="getValidationState(validationContext)"
              />
              <b-form-invalid-feedback>
                {{ validationContext.errors[0] }}
              </b-form-invalid-feedback>
            </b-form-group>
          </validation-provider>
        </div>

        <div class="col-lg-12">
          <div class="text-end">
            <b-button
              :disabled="invalid"
              variant="success"
              class="mx-1"
              title="Go to details"
            >
              <i class="bx bx bx-mail-send font-size-16 align-middle me-2"></i>
              Send
            </b-button>
          </div>
        </div>
      </b-form>
    </validation-observer>
  </div>
</template>

<script>
import axios from "@/helpers/http-comunicator";

export default {
  components: {},

  data() {
    return {
      form: {
        firstName: null,
      },
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

    getValidationState({ dirty, validated, valid = null }) {
      return dirty || validated ? valid : null;
    },

    resetForm() {
      this.form = {
        firstName: null,
        userName: null,
      };

      this.$nextTick(() => {
        this.$refs.observer.reset();
      });
    },

    onSubmit() {
      alert("Form submitted!");
    },
  },
};
</script>
