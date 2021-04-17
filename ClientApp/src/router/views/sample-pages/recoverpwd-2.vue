<script>
import axios from "axios";
import { required, email } from "vuelidate/lib/validators";

import appConfig from "@/app.config";
import { authMethods } from "@/state/helpers";

/**
 * Recoverpwd-2 component
 */
export default {
  page: {
    title: "Recoverpwd-2",
    meta: [{ name: "description", content: appConfig.description }],
  },
  data() {
    return {
      email: "",
      submitted: false,
      error: null,
      tryingToReset: false,
      isResetError: false,
    };
  },
  methods: {
    ...authMethods,
    // Try to register the user in with the email, fullname
    // and password they provided.
    tryToReset() {
      this.submitted = true;
      // stop here if form is invalid
      this.$v.$touch();

      if (this.$v.$invalid) {
        return;
      } else {
        if (process.env.VUE_APP_DEFAULT_AUTH === "firebase") {
          this.tryingToReset = true;
          // Reset the authError if it existed.
          this.error = null;
          return (
            this.resetPassword({
              email: this.email,
            })
              // eslint-disable-next-line no-unused-vars
              .then((token) => {
                this.tryingToReset = false;
                this.isResetError = false;
              })
              .catch((error) => {
                this.tryingToReset = false;
                this.error = error ? error : "";
                this.isResetError = true;
              })
          );
        } else if (process.env.VUE_APP_DEFAULT_AUTH === "authapi") {
          axios
            .post("http://127.0.0.1:8000/api/password/create", {
              email: this.email,
            })
            .then((res) => {
              this.isResetError = true;
              this.error = res.data;
              return res;
            });
        }
      }
    },
  },
  validations: {
    email: {
      required,
      email,
    },
  },
  mounted() {
    document.body.classList.add("auth-body-bg");
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
                    <h5 class="text-primary">Reset Password</h5>
                    <p class="text-muted">
                      Re-Password with Estimation Tool
                    </p>
                  </div>

                  <div class="mt-4">
                    <div
                      class="alert alert-success text-center mb-4"
                      role="alert"
                    >
                      Enter your Email and instructions will be sent to you!
                    </div>
                    <form @submit.prevent="tryToReset">
                      <b-alert
                        v-model="isResetError"
                        class="mb-4"
                        variant="danger"
                        dismissible
                        >{{ error }}</b-alert
                      >
                      <div class="mb-3">
                        <label for="useremail">Email</label>
                        <input
                          type="email"
                          v-model="email"
                          class="form-control"
                          id="useremail"
                          placeholder="Enter email"
                          :class="{
                            'is-invalid': submitted && $v.email.$error,
                          }"
                        />
                        <div
                          v-if="submitted && $v.email.$error"
                          class="invalid-feedback"
                        >
                          <span v-if="!$v.email.required"
                            >Email is required.</span
                          >
                          <span v-if="!$v.email.email"
                            >Please enter valid email.</span
                          >
                        </div>
                      </div>

                      <div class="row mb-0">
                        <div class="col-12 text-end">
                          <button
                            class="btn btn-primary w-md waves-effect waves-light"
                            type="submit"
                          >
                            Reset
                          </button>
                        </div>
                      </div>
                    </form>
                    <div class="mt-5 text-center">
                      <p>
                        Remember It ?
                        <router-link
                          to="/auth/login-2"
                          class="fw-medium text-primary"
                        >
                          Sign In here</router-link
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
