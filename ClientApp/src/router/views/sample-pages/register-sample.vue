<script>
import appConfig from "@/app.config";

/**
 * Register sample page
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
                <a href="/">
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
                </a>
              </div>
              <div class="p-2">
                <form class="form-horizontal">
                  <div class="mb-3">
                    <label for="useremail">Email</label>
                    <input
                      type="email"
                      class="form-control"
                      id="useremail"
                      placeholder="Enter email"
                    />
                  </div>

                  <div class="mb-3">
                    <label for="username">Username</label>
                    <input
                      type="text"
                      class="form-control"
                      id="username"
                      placeholder="Enter username"
                    />
                  </div>

                  <div class="mb-3">
                    <label for="userpassword">Password</label>
                    <input
                      type="password"
                      class="form-control"
                      id="userpassword"
                      placeholder="Enter password"
                    />
                  </div>

                  <div class="mt-4 d-grid">
                    <button class="btn btn-primary" type="submit">
                      Register
                    </button>
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
                </form>
              </div>
            </div>
          </div>
          <div class="mt-5 text-center">
            <p>
              Already have an account ?
              <router-link
                tag="a"
                to="/auth/login-1"
                class="fw-medium text-primary"
                >Login</router-link
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
