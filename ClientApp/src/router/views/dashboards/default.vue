<script>
import Layout from "../../layouts/main";
import appConfig from "@/app.config";
import PageHeader from "@/components/page-header";
/**
 * Dashboard Component
 */
export default {
  page: {
    title: "Dashboard",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  components: {
    Layout,
    PageHeader,
  },
  data() {
    return {
      title: "Dashboard",
      items: [
        {
          text: "Dashboards",
          href: "/",
        },
        {
          text: "Default",
          active: true,
        },
      ],
      statData: [
        {
          icon: "bx bx-copy-alt",
          title: "Orders",
          value: "1,235",
        },
        {
          icon: "bx bx-archive-in",
          title: "Revenue",
          value: "$35, 723",
        },
        {
          icon: "bx bx-purchase-tag-alt",
          title: "Average Price",
          value: "$16.2",
        },
      ],
      transactions: [
        {
          id: "#SK2540",
          name: "Neal Matthews",
          date: "07 Oct, 2019",
          total: "$400",
          status: "Paid",
          payment: ["fa-cc-mastercard", "Mastercard"],
          index: 1,
        },
        {
          id: "#SK2541",
          name: "Jamal Burnett",
          date: "07 Oct, 2019",
          total: "$380",
          status: "Chargeback",
          payment: ["fa-cc-visa", "Visa"],
          index: 2,
        },
        {
          id: "#SK2542",
          name: "Juan Mitchell",
          date: "06 Oct, 2019",
          total: "$384",
          status: "Paid",
          payment: ["fab fa-cc-paypal", "Paypal"],
          index: 3,
        },
        {
          id: "#SK2543",
          name: "Barry Dick",
          date: "05 Oct, 2019",
          total: "$412",
          status: "Paid",
          payment: ["fa-cc-mastercard", "Mastercard"],
          index: 4,
        },
        {
          id: "#SK2544",
          name: "Ronald Taylor",
          date: "04 Oct, 2019",
          total: "$404",
          status: "Refund",
          payment: ["fa-cc-visa", "Visa"],
          index: 5,
        },
        {
          id: "#SK2545",
          name: "Jacob Hunter",
          date: "04 Oct, 2019",
          total: "$392",
          status: "Paid",
          payment: ["fab fa-cc-paypal", "Paypal"],
          index: 6,
        },
      ],
      showModal: false,
      isLoading: false,
      fullPage: true,
      canCancel: false,
      useSlot: false,
      loader: "spinner",
      color: "#007bff",
      bgColor: "#ffffff",
      height: 128,
      width: 128,
      timeout: 3000, //ms
      fetchingStats: true,
      earningStatus: true,
    };
  },
  mounted() {
    setTimeout(() => {
      this.showModal = true;
    }, 1500);
  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />
  
  </Layout>
</template>
