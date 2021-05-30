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

    getValidationState({ dirty, validated, valid = null }) {
      return dirty || validated ? valid : null;
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
        <validation-observer ref="observer" v-slot="{ invalid, handleSubmit }">
          <b-form @submit.stop.prevent="handleSubmit(onSend)">
            <div class="row">
              <div class="col-lg-7">
                <validation-provider
                  name="Price"
                  rules="required|min:1"
                  v-slot="validationContext"
                >
                  <b-form-group label="Price">
                    <b-form-input
                      id="price"
                      name="price"
                      v-mask="'#####.##'"
                      v-model="form.value"
                      :state="getValidationState(validationContext)"
                    />
                    <b-form-invalid-feedback>
                      {{ validationContext.errors[0] }}
                    </b-form-invalid-feedback>
                  </b-form-group>
                </validation-provider>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-7">
                <validation-provider
                  name="Message"
                  rules="required|min:3|max:255"
                  v-slot="validationContext"
                >
                  <b-form-group label="Message">
                    <b-form-textarea
                      id="message"
                      name="message"
                      v-model="form.description"
                      :state="getValidationState(validationContext)"
                      rows="3"
                    />
                    <b-form-invalid-feedback>
                      {{ validationContext.errors[0] }}
                    </b-form-invalid-feedback>
                  </b-form-group>
                </validation-provider>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-12">
                <div class="text-end">
                  <b-button
                    variant="success"
                    @click.prevent="onSend()"
                    :disabled="invalid"
                    class="mx-1"
                    title="Send proposal"
                  >
                    <i
                      class="bx bx bx-mail-send font-size-16 align-middle me-2"
                    ></i>
                    Send
                  </b-button>
                </div>
              </div>
            </div>
          </b-form>
        </validation-observer>
      </div>
    </b-modal>
  </div>
</template>
