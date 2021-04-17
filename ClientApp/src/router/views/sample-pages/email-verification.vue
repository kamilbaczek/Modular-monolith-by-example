<script>
import appConfig from "@/app.config";

/**
 * Email verification component
 */
export default {
  page: {
    title: "Email verification",
    meta: [{ name: "description", content: appConfig.description }],
  },
  data() {
    return {};
  },
  components: {},
  methods: {},
};
</script>

<template>
  <div class="account-pages my-5 pt-sm-5">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <div class="text-center mb-5 text-muted">
            <router-link to="/" class="d-block auth-logo">
              <img
                src="@/assets/images/logo-dark.png"
                alt=""
                height="20"
                class="auth-logo-dark mx-auto"
              />
              <img
                src="@/assets/images/logo-light.png"
                alt=""
                height="20"
                class="auth-logo-light mx-auto"
              />
            </router-link>
            <p class="mt-3">Responsive Bootstrap 5 Admin Dashboard</p>
          </div>
        </div>
      </div>
      <!-- end row -->
      <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6 col-xl-5">
          <div class="card">
            <div class="card-body">
              <div class="p-2">
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
            </div>
          </div>
          <div class="mt-5 text-center">
            <p>
              Did't receive an email ?
              <a href="#" class="fw-medium text-primary"> Resend </a>
            </p>
            <p>
              ©
              {{ new Date().getFullYear() }} Estimation Tool Crafted with
              <i class="mdi mdi-heart text-danger"></i> by Themesbrand
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
