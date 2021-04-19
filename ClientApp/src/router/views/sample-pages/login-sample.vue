<script>
import axios from "axios";

import {
  authMethods,
  authFackMethods,
  notificationMethods,
} from "@/state/helpers";
import { mapState } from "vuex";
import appConfig from "@/app.config";
import { required, email } from "vuelidate/lib/validators";

/**
 * Login sample page
 */
export default {
  page: {
    title: "Login",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  data() {
    return {
      email: "admin@themesbrand.com",
      password: "123456",
      submitted: false,
      authError: null,
      tryingToLogIn: false,
      isAuthError: false,
    };
  },
  validations: {
    email: {
      required,
      email,
    },
    password: {
      required,
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
    // Try to log the user in with the username
    // and password they provided.
    tryToLogIn() {
      this.submitted = true;
      // stop here if form is invalid
      this.$v.$touch();

      if (this.$v.$invalid) {
        return;
      } else {
        if (process.env.VUE_APP_DEFAULT_AUTH === "firebase") {
          this.tryingToLogIn = true;
          // Reset the authError if it existed.
          this.authError = null;
          return (
            this.logIn({
              email: this.email,
              password: this.password,
            })
              // eslint-disable-next-line no-unused-vars
              .then((token) => {
                this.tryingToLogIn = false;
                this.isAuthError = false;
                // Redirect to the originally requested page, or to the home page
                this.$router.push(
                  this.$route.query.redirectFrom || {
                    name: "default",
                  }
                );
              })
              .catch((error) => {
                this.tryingToLogIn = false;
                this.authError = error ? error : "";
                this.isAuthError = true;
              })
          );
        } else if (process.env.VUE_APP_DEFAULT_AUTH === "fakebackend") {
          const { email, password } = this;
          if (email && password) {
            this.login({
              email,
              password,
            });
          }
        } else if (process.env.VUE_APP_DEFAULT_AUTH === "authapi") {
          axios
            .post("http://127.0.0.1:8000/api/login", {
              email: this.email,
              password: this.password,
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
  <div class="account-pages my-5 pt-5">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6 col-xl-5">
          <div class="card overflow-hidden">
            <div class="bg-soft bg-primary">
              <div class="row">
                <div class="col-7">
                  <div class="text-primary p-4">
                    <h5 class="text-primary">Welcome Back !</h5>
                    <p>Sign in to continue to Estimation Tool</p>
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
                      <img src="@/assets/images/logo.svg" alt height="34" />
                    </span>
                  </div>
                </router-link>
              </div>
              <b-alert
                v-model="isAuthError"
                variant="danger"
                class="mt-3"
                dismissible
                >{{ authError }}</b-alert
              >

              <div
                v-if="notification.message"
                :class="'alert ' + notification.type"
              >
                {{ notification.message }}
              </div>

              <b-form class="p-2" @submit.prevent="tryToLogIn">
                <b-form-group
                  class="mb-3"
                  id="input-group-1"
                  label="Email"
                  label-for="input-1"
                >
                  <b-form-input
                    id="input-1"
                    v-model="email"
                    type="text"
                    placeholder="Enter email"
                    :class="{ 'is-invalid': submitted && $v.email.$error }"
                  ></b-form-input>
                  <div
                    v-if="submitted && $v.email.$error"
                    class="invalid-feedback"
                  >
                    <span v-if="!$v.email.required">Email is required.</span>
                    <span v-if="!$v.email.email"
                      >Please enter valid email.</span
                    >
                  </div>
                </b-form-group>

                <b-form-group
                  class="mb-3"
                  id="input-group-2"
                  label="Password"
                  label-for="input-2"
                >
                  <b-form-input
                    id="input-2"
                    v-model="password"
                    type="password"
                    placeholder="Enter password"
                    :class="{ 'is-invalid': submitted && $v.password.$error }"
                  ></b-form-input>
                  <div
                    v-if="submitted && !$v.password.required"
                    class="invalid-feedback"
                  >
                    Password is required.
                  </div>
                </b-form-group>
                <b-form-checkbox
                  class="form-check"
                  id="customControlInline"
                  name="checkbox-1"
                  value="accepted"
                  unchecked-value="not_accepted"
                >
                  Remember me
                </b-form-checkbox>
                <div class="mt-3 d-grid">
                  <b-button type="submit" variant="primary" class="btn-block"
                    >Log In</b-button
                  >
                </div>
                <div class="mt-4 text-center">
                  <h5 class="font-size-14 mb-3">Sign in with</h5>

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
                  <router-link tag="a" to="/forgot-password" class="text-muted">
                    <i class="mdi mdi-lock me-1"></i> Forgot your password?
                  </router-link>
                </div>
              </b-form>
            </div>
            <!-- end card-body -->
          </div>
          <div class="mt-5 text-center">
            <p>
              Don't have an account ?
              <router-link
                tag="a"
                to="/auth/register-1"
                class="fw-medium text-primary"
                >Signup now</router-link
              >
            </p>
            <p>
              © {{ new Date().getFullYear() }} Estimation Tool Crafted with
              <i class="mdi mdi-heart text-danger"></i>
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
