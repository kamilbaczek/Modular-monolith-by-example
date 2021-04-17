<script>
import Loader from "./loader";

/**
 * Transactions component
 */
export default {
  components: {
    Loader,
  },
  props: {
    transactions: {
      type: Array,
      default: function () {
        return [];
      },
    },
    updating: {
      type: Boolean,
    },
  },
  data() {
    return {
      showModal: false,
    };
  },
};
</script>

<template>
  <Loader :loading="updating">
    <div class="table-responsive mb-0">
      <table class="table align-middle table-nowrap">
        <thead class="table-light">
          <tr>
            <th style="width: 20px">
              <div class="form-check font-size-16 align-middle">
                <input
                  class="form-check-input"
                  type="checkbox"
                  id="transactionCheck01"
                />
                <label
                  class="form-check-label"
                  for="transactionCheck01"
                ></label>
              </div>
            </th>
            <th class="align-middle">Order ID</th>
            <th class="align-middle">Billing Name</th>
            <th class="align-middle">Date</th>
            <th class="align-middle">Total</th>
            <th class="align-middle">Payment Status</th>
            <th class="align-middle">Payment Method</th>
            <th class="align-middle">View Details</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="data in transactions" :key="data.id">
            <td>
              <div class="form-check font-size-16">
                <input
                  class="form-check-input"
                  type="checkbox"
                  :id="`transactionCheck${data.index}`"
                />
                <label
                  class="form-check-label"
                  :for="`transactionCheck${data.index}`"
                ></label>
              </div>
            </td>
            <td>
              <a href="javascript: void(0);" class="text-body fw-bold">{{
                data.id
              }}</a>
            </td>
            <td>{{ data.name }}</td>
            <td>{{ data.date }}</td>
            <td>{{ data.total }}</td>
            <td>
              <span
                class="badge badge-pill badge-soft-success font-size-11"
                :class="{
                  'badge-soft-danger': `${data.status}` === 'Chargeback',
                  'badge-soft-warning': `${data.status}` === 'Refund',
                }"
                >{{ data.status }}</span
              >
            </td>
            <td>
              <i :class="`fab ${data.payment[0]} me-1`"></i>
              {{ data.payment[1] }}
            </td>
            <td>
              <!-- Button trigger modal -->
              <button
                type="button"
                class="btn btn-primary btn-sm btn-rounded"
                @click="$bvModal.show(data.id)"
              >
                View Details
              </button>
            </td>
            <b-modal :id="data.id" title="Order Details" centered>
              <p class="mb-2">
                Product id:
                <span class="text-primary">#SK2540</span>
              </p>
              <p class="mb-4">
                Billing Name:
                <span class="text-primary">Neal Matthews</span>
              </p>
              <div class="table-responsive">
                <table class="table table-centered table-nowrap">
                  <thead>
                    <tr>
                      <th scope="col">Product</th>
                      <th scope="col">Product Name</th>
                      <th scope="col">Price</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <th scope="row">
                        <div>
                          <img
                            src="@/assets/images/product/img-7.png"
                            alt
                            class="avatar-sm"
                          />
                        </div>
                      </th>
                      <td>
                        <div>
                          <h5 class="text-truncate font-size-14">
                            Wireless Headphone (Black)
                          </h5>
                          <p class="text-muted mb-0">$ 225 x 1</p>
                        </div>
                      </td>
                      <td>$ 255</td>
                    </tr>
                    <tr>
                      <th scope="row">
                        <div>
                          <img
                            src="@/assets/images/product/img-4.png"
                            alt
                            class="avatar-sm"
                          />
                        </div>
                      </th>
                      <td>
                        <div>
                          <h5 class="text-truncate font-size-14">
                            Phone patterned cases
                          </h5>
                          <p class="text-muted mb-0">$ 145 x 1</p>
                        </div>
                      </td>
                      <td>$ 145</td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <h6 class="m-0 text-end">Sub Total:</h6>
                      </td>
                      <td>$ 400</td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <h6 class="m-0 text-end">Shipping:</h6>
                      </td>
                      <td>Free</td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <h6 class="m-0 text-end">Total:</h6>
                      </td>
                      <td>$ 400</td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <template v-slot:modal-footer>
                <b-button variant="secondary" @click="showModal = false"
                  >Close</b-button
                >
              </template>
            </b-modal>
          </tr>
        </tbody>
      </table>
    </div>
    <!-- end table -->
  </Loader>
</template>