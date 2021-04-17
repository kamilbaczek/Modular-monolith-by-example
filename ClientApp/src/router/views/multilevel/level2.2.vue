<script>
import Layout from "../../layouts/main";
import PageHeader from "@/components/page-header";

import { todoMethods, todoComputed } from "@/state/helpers";

export default {
  components: { Layout, PageHeader },
  data() {
    return {
      todo: this.$store ? this.$store.state.todo.todos : {} || {},
      title: "Multi Level",
      items: [
        {
          text: "Level 1.2",
          href: "/",
        },
        {
          text: "Level 2.2",
          active: true,
        },
      ],
      totalRows: 1,
      currentPage: 1,
      perPage: 5,
    };
  },
  computed: {
    ...todoComputed,
    rows() {
      return this.todo.length;
    },
  },
  created() {
    this.fetchTodos();
  },
  mounted() {
    setTimeout(() => {
      this.fetchTodos();
    }, 1000);
  },
  methods: {
    ...todoMethods,
  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />
    <div class="card">
      <div class="card-body">
        {{todo}}
        <b-table
          striped
          :items="todo"
          :per-page="perPage"
          :current-page="currentPage"
        ></b-table>
        <b-pagination
          class="pagination-rounded"
          v-model="currentPage"
          :total-rows="rows"
          :per-page="perPage"
        ></b-pagination>
      </div>
    </div>
  </Layout>
</template>
