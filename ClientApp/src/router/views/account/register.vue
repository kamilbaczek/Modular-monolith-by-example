<script>
import axios from "axios";

import {
  authMethods,
  authFackMethods,
  notificationMethods,
} from "@/state/helpers";
import Layout from "../../layouts/auth";
import appConfig from "@/app.config";
import { mapState } from "vuex";

import { required, email } from "vuelidate/lib/validators";

/**
 * Register component
 */
export default {
  page: {
    title: "Register",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  components: {
    Layout,
  },
  data() {
    return {
      user: {
        username: "",
        email: "",
        password: "",
      },
      submitted: false,
      regError: null,
      tryingToRegister: false,
      isRegisterError: false,
      registerSuccess: false,
    };
  },
  validations: {
    user: {
      username: {
        required,
      },
      email: {
        required,
        email,
      },
      password: {
        required,
      },
    },
  },
  computed: {
    ...mapState("authfack", ["status"]),
    notification() {
      return this.$store ? this.$store.state.notification : null;
    },
  },
  methods: {
    ...authMethods,
    ...authFackMethods,
    ...notificationMethods,
    // Try to register the user in with the email, username
    // and password they provided.
    tryToRegisterIn() {
      this.submitted = true;
      // stop here if form is invalid
      this.$v.$touch();

      if (this.$v.$invalid) {
        return;
      } else {
        if (process.env.VUE_APP_DEFAULT_AUTH === "firebase") {
          this.tryingToRegister = true;
          // Reset the regError if it existed.
          this.regError = null;
          return (
            this.register({
              email: this.user.email,
              password: this.user.password,
            })
              // eslint-disable-next-line no-unused-vars
              .then((token) => {
                this.tryingToRegister = false;
                this.isRegisterError = false;
                this.registerSuccess = true;
                if (this.registerSuccess) {
                  this.$router.push(
                    this.$route.query.redirectFrom || {
                      name: "default",
                    }
                  );
                }
              })
              .catch((error) => {
                this.tryingToRegister = false;
                this.regError = error ? error : "";
                this.isRegisterError = true;
              })
          );
        } else if (process.env.VUE_APP_DEFAULT_AUTH === "fakebackend") {
          const { email, username, password } = this.user;
          if (email && username && password) {
            this.registeruser(this.user);
          }
        } else if (process.env.VUE_APP_DEFAULT_AUTH === "authapi") {
          axios
            .post("http://127.0.0.1:8000/api/register", {
              username: this.user.username,
              email: this.user.email,
              password: this.user.password,
            })
            .then((res) => {
              return res;
            });
        }
      }
    },
  },
};
</script>

<template>
  <Layout>
    <div class="row justify-content-center">
      <div class="col-md-8 col-lg-6 col-xl-5">
        <div class="card overflow-hidden">
          <div class="bg-soft bg-primary">
            <div class="row">
              <div class="col-7">
                <div class="text-primary p-4">
                  <h5 class="text-primary">Free Register</h5>
                  <p>Get your free Skote account now.</p>
                </div>
              </div>
              <div class="col-5 align-self-end">
                <img
                  src="@/assets/images/profile-img.png"
                  alt
                  class="img-fluid"
                />
              </div>
            </div>
          </div>
          <div class="card-body pt-0">
            <div>
              <router-link tag="a" to="/">
                <div class="avatar-md profile-user-wid mb-4">
                  <span class="avatar-title rounded-circle bg-light">
                    <img
                      src="@/assets/images/logo.svg"
                      alt
                      class="rounded-circle"
                      height="34"
                    />
                  </span>
                </div>
              </router-link>
            </div>

            <b-alert
              v-model="registerSuccess"
              class="mt-3"
              variant="success"
              dismissible
              >Registration successfull.</b-alert
            >

            <b-alert
              v-model="isRegisterError"
              class="mt-3"
              variant="danger"
              dismissible
              >{{ regError }}</b-alert
            >

            <div
              v-if="notification.message"
              :class="'alert ' + notification.type"
            >
              {{ notification.message }}
            </div>

            <b-form class="p-2" @submit.prevent="tryToRegisterIn">
              <b-form-group
                class="mb-3"
                id="email-group"
                label="Username"
                label-for="username"
              >
                <b-form-input
                  id="username"
                  v-model="user.username"
                  type="text"
                  placeholder="Enter username"
                  :class="{
                    'is-invalid': submitted && $v.user.username.$error,
                  }"
                ></b-form-input>
                <div
                  v-if="submitted && !$v.user.username.required"
                  class="invalid-feedback"
                >
                  Username is required.
                </div>
              </b-form-group>

              <b-form-group
                class="mb-3"
                id="fullname-group"
                label="Email"
                label-for="email"
              >
                <b-form-input
                  id="email"
                  v-model="user.email"
                  type="email"
                  placeholder="Enter email"
                  :class="{ 'is-invalid': submitted && $v.user.email.$error }"
                ></b-form-input>
                <div
                  v-if="submitted && $v.user.email.$error"
                  class="invalid-feedback"
                >
                  <span v-if="!$v.user.email.required">Email is required.</span>
                  <span v-if="!$v.user.email.email"
                    >Please enter valid email.</span
                  >
                </div>
              </b-form-group>

              <b-form-group
                class="mb-3"
                id="password-group"
                label="Password"
                label-for="password"
              >
                <b-form-input
                  id="password"
                  v-model="user.password"
                  type="password"
                  placeholder="Enter password"
                  :class="{
                    'is-invalid': submitted && $v.user.password.$error,
                  }"
                ></b-form-input>
                <div
                  v-if="submitted && !$v.user.password.required"
                  class="invalid-feedback"
                >
                  Password is required.
                </div>
              </b-form-group>

              <div class="mt-4 d-grid">
                <b-button type="submit" variant="primary" class="btn-block"
                  >Register</b-button
                >
              </div>

              <div class="mt-4 text-center">
                <h5 class="font-size-14 mb-3">Sign up using</h5>

                <ul class="list-inline">
                  <li class="list-inline-item">
                    <a
                      href="javascript: void(0);"
                      class="social-list-item bg-primary text-white border-primary"
                    >
                      <i class="mdi mdi-facebook"></i>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a
                      href="javascript: void(0);"
                      class="social-list-item bg-info text-white border-info"
                    >
                      <i class="mdi mdi-twitter"></i>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a
                      href="javascript: void(0);"
                      class="social-list-item bg-danger text-white border-danger"
                    >
                      <i class="mdi mdi-google"></i>
                    </a>
                  </li>
                </ul>
              </div>

              <div class="mt-4 text-center">
                <p class="mb-0">
                  By registering you agree to the Skote
                  <a href="javascript: void(0);" class="text-primary"
                    >Terms of Use</a
                  >
                </p>
              </div>
            </b-form>
          </div>
          <!-- end card-body -->
        </div>
        <!-- end card -->

        <div class="mt-5 text-center">
          <p>
            Already have an account ?
            <router-link tag="a" to="/login" class="fw-medium text-primary"
              >Login</router-link
            >
          </p>
          <p>
            © {{ new Date().getFullYear() }} Estimation Tool Crafted with
            <i class="mdi mdi-heart text-danger"></i> by Themesbrand
          </p>
        </div>
      </div>
      <!-- end col -->
    </div>
    <!-- end row -->
  </Layout>
</template>

<style lang="scss" module></style>
