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
        <h4 class="card-title mb-4">Top Cities Selling Product</h4>

        <div class="text-center">
          <div class="mb-4">
            <i class="bx bx-map-pin text-primary display-4"></i>
          </div>
          <h3>1,456</h3>
          <p>San Francisco</p>
        </div>

        <div class="table-responsive mt-4">
          <table class="table table-centered">
            <tbody>
              <tr>
                <td style="width: 140px">
                  <p class="mb-0">San Francisco</p>
                </td>
                <td style="width: 120px">
                  <h5 class="mb-0">1,456</h5>
                </td>
                <td>
                  <b-progress
                    :value="94"
                    variant="primary"
                    height="5px"
                  ></b-progress>
                </td>
              </tr>
              <tr>
                <td>
                  <p class="mb-0">Los Angeles</p>
                </td>
                <td>
                  <h5 class="mb-0">1,123</h5>
                </td>
                <td>
                  <b-progress
                    :value="82"
                    variant="success"
                    height="5px"
                  ></b-progress>
                </td>
              </tr>
              <tr>
                <td>
                  <p class="mb-0">San Diego</p>
                </td>
                <td>
                  <h5 class="mb-0">1,026</h5>
                </td>
                <td>
                  <b-progress
                    :value="70"
                    variant="warning"
                    height="5px"
                  ></b-progress>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </Loader>
</template>
