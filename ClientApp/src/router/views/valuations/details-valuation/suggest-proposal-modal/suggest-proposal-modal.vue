<script>
import axios from "@/helpers/http-comunicator";
import { required } from "vuelidate/lib/validators";

export default {
  components: {},
  props: {
    valuationId: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      form: {
        currency: "USD",
        value: 0,
        description: "",
      },
      validations: {
        form: {
          value: { required },
        },
      },
      suggestModalRef: "suggest-proposal-modal",
    };
  },
  mounted() {},
  methods: {
    show() {
      this.$refs[this.suggestModalRef].show();
    },

    hide() {
      this.$refs[this.suggestModalRef].hide();
    },

    onSend() {
      axios
        .post("valuations-module/Valuations/valuations/proposals", {
          currency: this.form.currency,
          value: this.form.value,
          description: this.form.description,
          valuationId: this.valuationId,
        })
        .then(() => {
          this.hide();

          this.$etToast(
            `Valuation estimited: ${this.form.value} ${this.form.currency}`
          );
        });
    },
  },
};
</script>

<template>
  <div>
    <b-modal
      ref="suggest-proposal-modal"
      title="Suggest proposal"
      hide-footer
      size="lg"
      centered
    >
      <div class="card-body">
        <form>
          <div class="row">
            <div class="col-lg-4">
              <div class="mb-3">
                <label for="price">Price</label>
                <input
                  type="text"
                  class="form-control"
                  id="price"
                  v-model="form.value"
                  placeholder="Enter Price"
                  v-mask="'######.##'"
                />
                <div v-if="$v.form.value.$error" class="invalid-feedback">
                  <span v-if="!$v.form.value.required"
                    >This value is required.</span
                  >
                </div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-lg-12">
              <div class="mb-3">
                <label for="message">Message</label>
                <textarea
                  v-model="form.description"
                  class="form-control"
                  id="message"
                  rows="3"
                ></textarea>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-lg-12">
              <div class="text-end">
                <b-button
                  variant="success"
                  @click.prevent="onSend()"
                  class="mx-1"
                  title="Go to details"
                >
                  <i
                    class="bx bx bx-mail-send font-size-16 align-middle me-2"
                  ></i>
                  Send
                </b-button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </b-modal>
  </div>
</template>
