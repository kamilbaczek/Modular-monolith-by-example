<script>
export default {
  props: {
    status: {
      type: String,
      default: "",
    },
  },
  methods: {
    getClassByStatus() {
      switch (this.status) {
        case "Request":
          return "bg-info";
        case "WaitForClientDecision":
          return "bg-warning";
        case "Rejected":
          return "bg-danger";
        case "Approved" || "Completed":
          return "bg-success";
      }
    },
  },
};
</script>

<template>
  <span class="badge et-badge" :class="getClassByStatus()"> {{ status }}</span>
</template>

<style scoped>
.et-badge {
  font-size: 0.9em;
}
</style>
