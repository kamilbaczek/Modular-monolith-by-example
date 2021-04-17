<script>
import axios from "axios";
import { required, email } from "vuelidate/lib/validators";

import {
  authMethods,
  authFackMethods,
  notificationMethods,
} from "@/state/helpers";
import { mapState } from "vuex";

import appConfig from "@/app.config";

/**
 * Register-2 component
 */
export default {
  page: {
    title: "Register 2",
    meta: [{ name: "description", content: appConfig.description }],
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
  mounted() {
    document.body.classList.add("auth-body-bg");
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
  <div>
    <div class="container-fluid p-0">
      <div class="row g-0">
        <div class="col-xl-9">
          <div class="auth-full-bg pt-lg-5 p-4">
            <div class="w-100">
              <div class="bg-overlay"></div>
              <div class="d-flex h-100 flex-column">
                <div class="p-4 mt-auto">
                  <div class="row justify-content-center">
                    <div class="col-lg-7">
                      <div class="text-center">
                        <h4 class="mb-3">
                          <i
                            class="bx bxs-quote-alt-left text-primary h1 align-middle me-3"
                          ></i
                          ><span class="text-primary">5k</span>+ Satisfied
                          clients
                        </h4>

                        <div dir="ltr" class="owl-theme">
                          <b-carousel
                            id="carousel-1"
                            :interval="4000"
                            indicators
                          >
                            <!-- Text slides with image -->
                            <b-carousel-slide>
                              <p class="font-size-16 mb-4">
                                " Fantastic theme with a ton of options. If you
                                just want the HTML to integrate with your
                                project, then this is the package. You can find
                                the files in the 'dist' folder...no need to
                                install git and all the other stuff the
                                documentation talks about. "
                              </p>
                              <div>
                                <h4 class="font-size-16 text-primary">
                                  Abs1981
                                </h4>
                                <p class="font-size-14 mb-0">- Skote User</p>
                              </div>
                            </b-carousel-slide>

                            <!-- Slides with custom text -->
                            <b-carousel-slide>
                              <p class="font-size-16 mb-4">
                                " If Every Vendor on Envato are as supportive as
                                Themesbrand, Development with be a nice
                                experience. You guys are Wonderful. Keep us the
                                good work. "
                              </p>
                              <div>
                                <h4 class="font-size-16 text-primary">
                                  nezerious
                                </h4>
                                <p class="font-size-14 mb-0">- Skote User</p>
                              </div>
                            </b-carousel-slide>
                          </b-carousel>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- end col -->

        <div class="col-xl-3">
          <div class="auth-full-page-content p-md-5 p-4">
            <div class="w-100">
              <div class="d-flex flex-column h-100">
                <div class="mb-4 mb-md-5">
                  <router-link to="/" class="d-block auth-logo">
                    <img
                      src="@/assets/images/logo-dark.png"
                      alt=""
                      height="18"
                      class="auth-logo-dark"
                    />
                    <img
                      src="@/assets/images/logo-light.png"
                      alt=""
                      height="18"
                      class="auth-logo-light"
                    />
                  </router-link>
                </div>
                <div class="my-auto">
                  <div>
                    <h5 class="text-primary">Register account</h5>
                    <p class="text-muted">Get your free Skote account now.</p>
                  </div>

                  <div class="mt-4">
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

                    <b-form @submit.prevent="tryToRegisterIn">
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
                          :class="{
                            'is-invalid': submitted && $v.user.email.$error,
                          }"
                        ></b-form-input>
                        <div
                          v-if="submitted && $v.user.email.$error"
                          class="invalid-feedback"
                        >
                          <span v-if="!$v.user.email.required"
                            >Email is required.</span
                          >
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
                        <b-button
                          type="submit"
                          variant="primary"
                          class="btn-block"
                          >Register</b-button
                        >
                      </div>

                      <div class="mt-4 text-center">
                        <h5 class="font-size-14 mb-3">Sign up using</h5>

                        <ul class="list-inline">
                          <li class="list-inline-item">
                            <a
                              href="javascript::void()"
                              class="social-list-item bg-primary text-white border-primary"
                            >
                              <i class="mdi mdi-facebook"></i>
                            </a>
                          </li>
                          <li class="list-inline-item">
                            <a
                              href="javascript::void()"
                              class="social-list-item bg-info text-white border-info"
                            >
                              <i class="mdi mdi-twitter"></i>
                            </a>
                          </li>
                          <li class="list-inline-item">
                            <a
                              href="javascript::void()"
                              class="social-list-item bg-danger text-white border-danger"
                            >
                              <i class="mdi mdi-google"></i>
                            </a>
                          </li>
                        </ul>
                      </div>
                    </b-form>

                    <div class="mt-5 text-center">
                      <p>
                        Already have an account ?
                        <router-link
                          to="/auth/login-2"
                          class="fw-medium text-primary"
                        >
                          Login</router-link
                        >
                      </p>
                    </div>
                  </div>
                </div>

                <div class="mt-4 mt-md-5 text-center">
                  <p class="mb-0">
                    © {{ new Date().getFullYear() }} Estimation Tool Crafted
                    with <i class="mdi mdi-heart text-danger"></i> by
                    Themesbrand
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- end col -->
      </div>
      <!-- end row -->
    </div>
    <!-- end container-fluid -->
  </div>
</template>

<style lang="scss" scoped>
::v-deep .carousel-caption {
  position: relative !important;
  right: 0;
  left: 0;
  padding-top: 1.25rem;
  padding-bottom: 1.25rem;
  color: #495057;
}

::v-deep .carousel-indicators li {
  background-color: rgba(85, 110, 230, 0.25);
}
</style>
