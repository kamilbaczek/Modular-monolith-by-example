<template>
  <div class="card-body">
    <validation-observer ref="observer" v-slot="{ invalid, handleSubmit }">
      <b-form @submit.stop.prevent="handleSubmit(onSubmit)">
        <!-- Username -->
        <div class="col-lg-7">
          <validation-provider
            name="User name"
            rules="required|min:3"
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
        <!-- FirstName -->
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
        <!-- LastName -->
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
        <!-- Email -->
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
        <!-- Button -->
        <div class="col-lg-12">
          <div class="text-end">
            <b-button
              :disabled="invalid"
              variant="success"
              class="mx-1"
              title="Send form"
              @click="onSubmit"
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
        username: "",
        firstName: "",
        lastName: "",
        email: "",
      },
    };
  },

  mounted() {
    this.getUser(this.userPublicId);
  },

  methods: {
    getUser(userPublicId) {
      if (userPublicId === "") return;

      axios.get(`users-module/Users/${userPublicId}`).then((res) => {
        this.form = res.data;
      });
    },

    onSubmit(userPublicId) {
      if (!userPublicId) {
        //create user
        axios.get("users-module/Users", this.form).then((res) => {
          this.form = res.data;
        });
      } else {
        //update user
        alert("Form submitted!");
      }
    },

    getValidationState({ dirty, valid = null }) {
      return dirty || valid ? valid : null;
    },

    resetForm() {
      this.form = {
        username: "",
        firstName: "",
        lastName: "",
        email: "",
      };

      this.$nextTick(() => {
        this.$refs.observer.reset();
      });
    },
  },
  props: {
    userPublicId: {
      type: String,
      required: false,
    },
  },
};
</script>
