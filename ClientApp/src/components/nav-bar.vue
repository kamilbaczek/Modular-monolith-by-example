<script>
import axios from "axios";

import i18n from "../i18n";

import simplebar from "simplebar-vue";

/**
 * Nav-bar Component
 */
export default {
  data() {
    return {
      languages: [
        {
          flag: require("@/assets/images/flags/us.jpg"),
          language: "en",
          title: "English",
        },
        {
          flag: require("@/assets/images/flags/french.jpg"),
          language: "fr",
          title: "French",
        },
        {
          flag: require("@/assets/images/flags/spain.jpg"),
          language: "es",
          title: "Spanish",
        },
        {
          flag: require("@/assets/images/flags/chaina.png"),
          language: "zh",
          title: "Chinese",
        },
        {
          flag: require("@/assets/images/flags/arabic.png"),
          language: "ar",
          title: "Arabic",
        },
      ],
      lan: i18n.locale,
      text: null,
      flag: null,
      value: null,
    };
  },
  components: { simplebar },
  mounted() {
    this.value = this.languages.find((x) => x.language === i18n.locale);
    this.text = this.value.title;
    this.flag = this.value.flag;
  },
  methods: {
    toggleMenu() {
      this.$parent.toggleMenu();
    },
    toggleRightSidebar() {
      this.$parent.toggleRightSidebar();
    },
    initFullScreen() {
      document.body.classList.toggle("fullscreen-enable");
      if (
        !document.fullscreenElement &&
        /* alternative standard method */ !document.mozFullScreenElement &&
        !document.webkitFullscreenElement
      ) {
        // current working methods
        if (document.documentElement.requestFullscreen) {
          document.documentElement.requestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) {
          document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) {
          document.documentElement.webkitRequestFullscreen(
            Element.ALLOW_KEYBOARD_INPUT
          );
        }
      } else {
        if (document.cancelFullScreen) {
          document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
          document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
          document.webkitCancelFullScreen();
        }
      }
    },
    setLanguage(locale, country, flag) {
      this.lan = locale;
      this.text = country;
      this.flag = flag;
      i18n.locale = locale;
    },
    logoutUser() {
      // eslint-disable-next-line no-unused-vars
      axios.get("http://127.0.0.1:8000/api/logout").then((res) => {
        this.$router.push({
          name: "default",
        });
      });
    },
  },
};
</script>

<template>
  <header id="page-topbar">
    <div class="navbar-header">
      <div class="d-flex">
        <!-- LOGO -->
        <div class="navbar-brand-box">
          <router-link tag="a" to="/" class="logo logo-dark">
            <span class="logo-sm">
              <img src="@/assets/images/logo.svg" alt height="22" />
            </span>
            <span class="logo-lg">
              <img src="@/assets/images/logo-dark.png" alt height="17" />
            </span>
          </router-link>

          <router-link tag="a" to="/" class="logo logo-light">
            <span class="logo-sm">
              <img src="@/assets/images/logo-light.svg" alt height="22" />
            </span>
            <span class="logo-lg">
              <img src="@/assets/images/logo-light.png" alt height="19" />
            </span>
          </router-link>
        </div>

        <button
          id="vertical-menu-btn"
          type="button"
          class="btn btn-sm px-3 font-size-16 header-item"
          @click="toggleMenu"
        >
          <i class="fa fa-fw fa-bars"></i>
        </button>

        <!-- App Search-->
        <form class="app-search d-none d-lg-block">
          <div class="position-relative">
            <input
              type="text"
              class="form-control"
              :placeholder="$t('navbar.search.text')"
            />
            <span class="bx bx-search-alt"></span>
          </div>
        </form>
      </div>

      <div class="d-flex">
        <b-dropdown
          class="d-inline-block d-lg-none ms-2"
          variant="black"
          menu-class="dropdown-menu-lg p-0"
          toggle-class="header-item noti-icon"
          right
        >
          <template v-slot:button-content>
            <i class="mdi mdi-magnify"></i>
          </template>

          <form class="p-3">
            <div class="form-group m-0">
              <div class="input-group">
                <input
                  type="text"
                  class="form-control"
                  placeholder="Search ..."
                  aria-label="Recipient's username"
                />
                <div class="input-group-append">
                  <button class="btn btn-primary" type="submit">
                    <i class="mdi mdi-magnify"></i>
                  </button>
                </div>
              </div>
            </div>
          </form>
        </b-dropdown>

        <b-dropdown variant="white" right toggle-class="header-item">
          <template v-slot:button-content>
            <img class :src="flag" alt="Header Language" height="16" />
            {{ text }}
          </template>
          <b-dropdown-item
            class="notify-item"
            v-for="(entry, i) in languages"
            :key="`Lang${i}`"
            :value="entry"
            @click="setLanguage(entry.language, entry.title, entry.flag)"
            :class="{ active: lan === entry.language }"
          >
            <img
              :src="`${entry.flag}`"
              alt="user-image"
              class="me-1"
              height="12"
            />
            <span class="align-middle">{{ entry.title }}</span>
          </b-dropdown-item>
        </b-dropdown>

        <div class="dropdown d-none d-lg-inline-block ms-1">
          <button
            type="button"
            class="btn header-item noti-icon"
            @click="initFullScreen"
          >
            <i class="bx bx-fullscreen"></i>
          </button>
        </div>

        <b-dropdown
          right
          menu-class="dropdown-menu-lg p-0 dropdown-menu-end"
          toggle-class="header-item noti-icon"
          variant="black"
        >
          <template v-slot:button-content>
            <i class="bx bx-bell bx-tada"></i>
            <span class="badge bg-danger rounded-pill">{{
              $t("navbar.dropdown.notification.badge")
            }}</span>
          </template>

          <div class="p-3">
            <div class="row align-items-center">
              <div class="col">
                <h6 class="m-0">
                  {{ $t("navbar.dropdown.notification.text") }}
                </h6>
              </div>
              <div class="col-auto">
                <a href="#" class="small">{{
                  $t("navbar.dropdown.notification.subtext")
                }}</a>
              </div>
            </div>
          </div>
          <simplebar style="max-height: 230px">
            <a href="javascript: void(0);" class="text-reset notification-item">
              <div class="media">
                <div class="avatar-xs me-3">
                  <span
                    class="avatar-title bg-primary rounded-circle font-size-16"
                  >
                    <i class="bx bx-cart"></i>
                  </span>
                </div>
                <div class="media-body">
                  <h6 class="mt-0 mb-1">
                    {{ $t("navbar.dropdown.notification.order.title") }}
                  </h6>
                  <div class="font-size-12 text-muted">
                    <p class="mb-1">
                      {{ $t("navbar.dropdown.notification.order.text") }}
                    </p>
                    <p class="mb-0">
                      <i class="mdi mdi-clock-outline"></i>
                      {{ $t("navbar.dropdown.notification.order.time") }}
                    </p>
                  </div>
                </div>
              </div>
            </a>
            <a href="javascript: void(0);" class="text-reset notification-item">
              <div class="media">
                <img
                  src="@/assets/images/users/avatar-3.jpg"
                  class="me-3 rounded-circle avatar-xs"
                  alt="user-pic"
                />
                <div class="media-body">
                  <h6 class="mt-0 mb-1">
                    {{ $t("navbar.dropdown.notification.james.title") }}
                  </h6>
                  <div class="font-size-12 text-muted">
                    <p class="mb-1">
                      {{ $t("navbar.dropdown.notification.james.text") }}
                    </p>
                    <p class="mb-0">
                      <i class="mdi mdi-clock-outline"></i>
                      {{ $t("navbar.dropdown.notification.james.time") }}
                    </p>
                  </div>
                </div>
              </div>
            </a>
            <a href="javascript: void(0);" class="text-reset notification-item">
              <div class="media">
                <div class="avatar-xs me-3">
                  <span
                    class="avatar-title bg-success rounded-circle font-size-16"
                  >
                    <i class="bx bx-badge-check"></i>
                  </span>
                </div>
                <div class="media-body">
                  <h6 class="mt-0 mb-1">
                    {{ $t("navbar.dropdown.notification.item.title") }}
                  </h6>
                  <div class="font-size-12 text-muted">
                    <p class="mb-1">
                      {{ $t("navbar.dropdown.notification.item.text") }}
                    </p>
                    <p class="mb-0">
                      <i class="mdi mdi-clock-outline"></i>
                      {{ $t("navbar.dropdown.notification.item.time") }}
                    </p>
                  </div>
                </div>
              </div>
            </a>
            <a href="javascript: void(0);" class="text-reset notification-item">
              <div class="media">
                <img
                  src="@/assets/images/users/avatar-4.jpg"
                  class="me-3 rounded-circle avatar-xs"
                  alt="user-pic"
                />
                <div class="media-body">
                  <h6 class="mt-0 mb-1">
                    {{ $t("navbar.dropdown.notification.salena.title") }}
                  </h6>
                  <div class="font-size-12 text-muted">
                    <p class="mb-1">
                      {{ $t("navbar.dropdown.notification.salena.text") }}
                    </p>
                    <p class="mb-0">
                      <i class="mdi mdi-clock-outline"></i>
                      {{ $t("navbar.dropdown.notification.salena.time") }}
                    </p>
                  </div>
                </div>
              </div>
            </a>
          </simplebar>
          <div class="p-2 border-top d-grid">
            <a
              class="btn btn-sm btn-link font-size-14 text-center"
              href="javascript:void(0)"
            >
              <i class="mdi mdi-arrow-right-circle me-1"></i>
              {{ $t("navbar.dropdown.notification.button") }}
            </a>
          </div>
        </b-dropdown>

        <b-dropdown
          right
          variant="black"
          toggle-class="header-item"
          menu-class="dropdown-menu-end"
        >
          <template v-slot:button-content>
            <img
              class="rounded-circle header-profile-user"
              src="@/assets/images/users/avatar-1.jpg"
              alt="Header Avatar"
            />
            <span class="d-none d-xl-inline-block ms-1">{{
              $t("navbar.dropdown.henry.text")
            }}</span>
            <i class="mdi mdi-chevron-down d-none d-xl-inline-block"></i>
          </template>
          <!-- item-->
          <b-dropdown-item>
            <router-link tag="span" to="/contacts/profile">
              <i class="bx bx-user font-size-16 align-middle me-1"></i>
              {{ $t("navbar.dropdown.henry.list.profile") }}
            </router-link>
          </b-dropdown-item>
          <b-dropdown-item href="javascript: void(0);">
            <i class="bx bx-wallet font-size-16 align-middle me-1"></i>
            {{ $t("navbar.dropdown.henry.list.mywallet") }}
          </b-dropdown-item>
          <b-dropdown-item class="d-block" href="javascript: void(0);">
            <span class="badge bg-success float-end">11</span>
            <i class="bx bx-wrench font-size-16 align-middle me-1"></i>
            {{ $t("navbar.dropdown.henry.list.settings") }}
          </b-dropdown-item>
          <b-dropdown-item href="javascript: void(0);">
            <i class="bx bx-lock-open font-size-16 align-middle me-1"></i>
            {{ $t("navbar.dropdown.henry.list.lockscreen") }}
          </b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
          <a href="/logout" class="dropdown-item text-danger">
            <i
              class="bx bx-power-off font-size-16 align-middle me-1 text-danger"
            ></i>
            {{ $t("navbar.dropdown.henry.list.logout") }}
          </a>
        </b-dropdown>
      </div>
    </div>
  </header>
</template>
