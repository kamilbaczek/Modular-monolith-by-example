<template>
  <Layout>
    <PageHeader :title="title" :items="items" />

    <div class="row">
      <div class="col-lg-12">
        <div class="card">
          <div class="card-body">
            <h4 class="card-title mb-4">New Service</h4>
            <form class="outer-repeater">
              <div class="outer">
                <div class="outer">
                  <div class="mb-3">
                    <label>Category:</label>
                    <div class="input-group mb-3">
                      <select class="form-select" style="max-width: 90px" v-model="selected">
                        <option v-for="option in categories" :key="option.id" :value="option.name" :data-id="option.id">{{option.name}}</option>
                      </select>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label for="formservicename">Service name:</label>
                    <input
                      id="formservicename"
                      type="text"
                      class="form-control"
                      placeholder="Enter service name..."
                      v-model="name"
                    />
                  </div>

                  <div class="mb-3">
                    <label for="formservicedescription">Service Description:</label>
                    <input
                      id="formservicedescription"
                      type="textarea"
                      class="form-control"
                      placeholder="Enter description..."
                      v-model="description"
                    />
                  </div>

                  <div class="inner-repeater mb-4">
                    <div class="inner mb-3">
                      <label>Options:</label>
                      <div
                        v-for="(data, index) in option"
                        :key="data.id"
                        class="inner mb-3 row"
                      >
                        <div class="col-md-10 col-8">
                          <input
                            v-model="data.option"
                            type="text"
                            class="inner form-control"
                            placeholder="Enter option name"
                          />
                        </div>
                        <div class="col-md-2 col-4">
                          <div class="d-grid">
                            <input
                              type="button"
                              class="btn btn-primary btn-block inner"
                              value="Delete"
                              @click="deleteOption(index)"
                            />
                          </div>
                        </div>
                      </div>
                    </div>
                    <input
                      type="button"
                      class="btn btn-success inner"
                      value="Add new option"
                      @click="addOption"
                    />
                  </div>
                  <div class="mb-3">
                    <label for="formmessage">Message :</label>
                    <textarea
                      id="formmessage"
                      class="form-control"
                      rows="3"
                    ></textarea>
                  </div>
                  <button type="submit" class="btn btn-primary" @click="addService()">Submit</button>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </Layout>
</template>

<script>
import Layout from "../../../layouts/main";
import PageHeader from "@/components/page-header";
import appConfig from "@/app.config";
import axios from "@/helpers/http-comunicator";

/**
 * Form-repeater Component
 */
export default {
  page: {
    title: "New Service",
    meta: [{ name: "description", content: appConfig.description }],
  },
  components: { Layout, PageHeader },
  data() {
    return {
      title: "Form Repeater",
      items: [
        {
          text: "Forms",
          href: "/",
        },
        {
          text: "Form Repeater",
          active: true,
        },
      ],

      name: '',
      description: '',
      selected: '',
      fields: [{ id: 1 }],
      option: [{ id: 1}],
      categories: []

    };
  },

  methods: {
    /**
     * Push the row in form
     */
    AddformData() {
      this.fields.push({ name: "", email: "", subject: "", message: "" });
    },
    /**
     * Delete the row
     */
    deleteRow(index) {
      if (confirm("Are you sure you want to delete this element?"))
        this.fields.splice(index, 1);
    },
    /**
     * Add option in form
     */
    addOption() {
      this.option.push({ option: "" });
    },
    deleteOption(index) {
      this.option.splice(index, 1);
    },
    addService() {
            axios.post("services-module/Services", {
              name: this.name,
              description: this.description,
              categoryId: this.categories[0].id
            })
            .then((res) => {
              return res;
              
            });
    }
  },
  mounted() {
    axios.get("services-module/Categories").then((res) => {
      this.categories = res.data;
    });
  }
};
</script>