<script>
import appConfig from "@/app.config";

/**
 * Lock screen page -component
 */
export default {
  page: {
    title: "Lockscreen",
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
  <div>
    <div class="home-btn d-none d-sm-block">
      <router-link tag="a" to="/" class="text-dark">
        <i class="mdi mdi-home-variant h2"></i>
      </router-link>
    </div>
    <div class="account-pages my-5 pt-5">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-md-8 col-lg-6 col-xl-5">
            <div class="card overflow-hidden">
              <div class="bg-soft bg-primary">
                <div class="row">
                  <div class="col-7">
                    <div class="text-primary p-4">
                      <h5 class="text-primary">Lock screen</h5>
                      <p>Enter your password to unlock the screen!</p>
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
                    <div class="user-thumb text-center mb-4">
                      <img
                        src="@/assets/images/users/avatar-1.jpg"
                        class="rounded-circle img-thumbnail avatar-md"
                        alt="thumbnail"
                      />
                      <h5 class="font-size-15 mt-3">Maria Laird</h5>
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

                    <div class="row mb-0">
                      <div class="col-12 text-end">
                        <button class="btn btn-primary w-md" type="submit">
                          Unlock
                        </button>
                      </div>
                    </div>
                  </form>
                </div>
              </div>
            </div>
            <div class="mt-5 text-center">
              <p>
                Not you ? return
                <router-link
                  tag="a"
                  to="/auth/login-1"
                  class="fw-medium text-primary"
                  >Sign In</router-link
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
  </div>
</template>
