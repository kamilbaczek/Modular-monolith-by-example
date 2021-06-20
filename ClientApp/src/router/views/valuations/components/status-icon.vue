<script>
export default {
  props: {
    status: {
      type: String,
      default: "",
    },
    active: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    getIconByStatus() {
      switch (this.status) {
        case "WaitForProposal":
          return "bx bx-cart";
        case "WaitForClientDecision":
          return "bx bxs-user-voice";
        case "Rejected":
          return "bx bx-user-check";
        case "Approved":
          return "bx bx-user-check";
        case "Completed":
          return "bx bx-check-double";
      }
    },

    getClass() {
      if (this.active) return this.getIconByStatus() + " bx-fade-right";
      return this.getIconByStatus();
    },
  },
};
</script>

<template>
  <i class="font-size-18" :class="getClass()"></i>
</template>
