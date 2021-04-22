import Vue from "vue";

export default {
    // eslint-disable-next-line no-unused-vars
    install(vue, opts){   
        Vue.prototype.$etConfirm =  () => {
              return Vue.prototype.$swal({
                title: "Are you sure?",
                icon: "warning",
                showCancelButton: true
              })
        }
    }
}
