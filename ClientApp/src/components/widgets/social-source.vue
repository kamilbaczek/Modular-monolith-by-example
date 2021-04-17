<script>
import Loader from "./loader";

export default {
  components: {
    Loader,
  },
  props: {
    updating: {
      type: Boolean,
    },
  },
};
</script>

<template>
  <Loader :loading="updating">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title mb-4">Social Source</h4>
        <div class="text-center">
          <div class="avatar-sm mx-auto mb-4">
            <span class="avatar-title rounded-circle bg-primary bg-soft font-size-24">
              <i class="mdi mdi-facebook text-primary"></i>
            </span>
          </div>
          <p class="font-16 text-muted mb-2"></p>
          <h5>
            <a href="javascript: void(0);" class="text-dark">
              Facebook -
              <span class="text-muted font-16">125 sales</span>
            </a>
          </h5>
          <p class="text-muted">
            Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut
            libero venenatis faucibus tincidunt.
          </p>
          <a href="javascript: void(0);" class="text-primary font-16">
            Learn more
            <i class="mdi mdi-chevron-right"></i>
          </a>
        </div>
        <div class="row mt-4">
          <div class="col-sm-4">
            <div class="social-source text-center mt-3">
              <div class="avatar-xs mx-auto mb-3">
                <span
                  class="avatar-title rounded-circle bg-primary font-size-16"
                >
                  <i class="mdi mdi-facebook text-white"></i>
                </span>
              </div>
              <h5 class="font-size-15">Facebook</h5>
              <p class="text-muted mb-0">125 sales</p>
            </div>
          </div>
          <div class="col-sm-4">
            <div class="social-source text-center mt-3">
              <div class="avatar-xs mx-auto mb-3">
                <span class="avatar-title rounded-circle bg-info font-size-16">
                  <i class="mdi mdi-twitter text-white"></i>
                </span>
              </div>
              <h5 class="font-size-15">Twitter</h5>
              <p class="text-muted mb-0">112 sales</p>
            </div>
          </div>
          <div class="col-sm-4">
            <div class="social-source text-center mt-3">
              <div class="avatar-xs mx-auto mb-3">
                <span class="avatar-title rounded-circle bg-pink font-size-16">
                  <i class="mdi mdi-instagram text-white"></i>
                </span>
              </div>
              <h5 class="font-size-15">Instagram</h5>
              <p class="text-muted mb-0">104 sales</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </Loader>
</template>