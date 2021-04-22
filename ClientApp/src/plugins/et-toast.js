import Vue from "vue";

export default {
    // eslint-disable-next-line no-unused-vars
    install(vue, opts){   
        Vue.prototype.$etToast =  (title, timer = 1500, position="top-end") => {
            Vue.prototype.$swal.fire({
                position: position,
                timer: timer,
                title: title,
                icon: "success",
                toast: true,
                showConfirmButton: false,
                timerProgressBar: true,
              });
        }
    }
    
}
