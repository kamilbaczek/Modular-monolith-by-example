<template>
  <div v-if="historicalEntries">
    <h4 class="card-title mb-5">History</h4>
    <ul class="verti-timeline list-unstyled">
      <HistoricalEntry
        v-for="historicalEntry in historicalEntries"
        :key="historicalEntry.id"
        :changeDate="historicalEntry.changeDateFormatted"
        :status="historicalEntry.status"
        :active="recentHistoricalEntryId === historicalEntry.id"
      ></HistoricalEntry>
    </ul>
  </div>
</template>
<script>
import axios from "@/helpers/http-comunicator";
import HistoricalEntry from "./historical-entry.vue";
export default {
  components: {
    HistoricalEntry,
  },

  props: {
    valuationId: {
      type: String,
      required: true,
    },
  },

  data() {
    return {
      historicalEntries: [],
      recentHistoricalEntryId: "",
    };
  },

  mounted() {
    this.getHistory();
  },

  methods: {
    getHistory() {
      axios
        .get(
          `valuations-module/Valuations/valuations/history/${this.valuationId}`
        )
        .then((res) => {
          this.historicalEntries = res.data.valuationHistoricalEntries;
          this.recentHistoricalEntryId = res.data.recentHistoricalEntryId;
        });
    },
  },
};
</script>
