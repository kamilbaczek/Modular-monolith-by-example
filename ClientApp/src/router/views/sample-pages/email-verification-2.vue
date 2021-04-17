<script>
import appConfig from "@/app.config";

/**
 * Email-verification-2 component
 */
export default {
  page: {
    title: "Email verification 2",
    meta: [{ name: "description", content: appConfig.description }],
  },
  data() {
    return {};
  },
  methods: {},
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
                  <div class="text-center">
                    <div class="avatar-md mx-auto">
                      <div class="avatar-title rounded-circle bg-light">
                        <i class="bx bxs-envelope h1 mb-0 text-primary"></i>
                      </div>
                    </div>
                    <div class="p-2 mt-4">
                      <h4>Verify your email</h4>
                      <p>
                        We have sent you verification email
                        <span class="fw-semibold">example@abc.com</span>, Please
                        check it
                      </p>
                      <div class="mt-4">
                        <router-link to="/" class="btn btn-success w-md"
                          >Verify email</router-link
                        >
                      </div>
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
