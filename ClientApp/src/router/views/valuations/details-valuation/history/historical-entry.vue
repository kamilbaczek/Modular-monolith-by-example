<template>
  <li class="event-list">
    <div class="event-timeline-dot">
      <StatusIcon :status="status" :active="active"></StatusIcon>
    </div>
    <div class="media">
      <div class="me-3">
        <h5 class="font-size-14">
          {{ changeDate }}
          <i
            class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2 "
          ></i>
        </h5>
      </div>
      <div class="media-body">
        <div>{{ status }}</div>
      </div>
    </div>
  </li>
</template>
<script>
import StatusIcon from "../../components/status-icon.vue";
export default {
  components: {
    StatusIcon,
  },

  props: {
    changeDate: {
      type: String,
      required: true,
    },
    status: {
      type: String,
      required: true,
    },
    active: {
      type: Boolean,
      default: false,
    },
  },

  data() {
    return {
      historicalEntries: [],
    };
  },
};
</script>
