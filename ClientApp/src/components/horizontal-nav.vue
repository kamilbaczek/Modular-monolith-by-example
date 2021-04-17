<script>
import { layoutMethods } from "@/state/helpers";
import { menuItems } from "./horizontal-menu";

export default {
  data() {
    return {
      menuItems: menuItems,
    };
  },
  mounted() {
    var links = document.getElementsByClassName("side-nav-link-ref");
    var matchingMenuItem = null;
    for (var i = 0; i < links.length; i++) {
      if (window.location.pathname === links[i].pathname) {
        matchingMenuItem = links[i];
        break;
      }
    }

    if (matchingMenuItem) {
      matchingMenuItem.classList.add("active");
      var parent = matchingMenuItem.parentElement;

      /**
       * TODO: This is hard coded way of expading/activating parent menu dropdown and working till level 3.
       * We should come up with non hard coded approach
       */

      if (parent) {
        parent.classList.add("active");
        const parent2 = parent.parentElement;
        if (parent2) {
          parent2.classList.add("active");
          const parent3 = parent2.parentElement;
          if (parent3) {
            parent3.classList.add("active");
            const parent4 = parent3.parentElement;
            if (parent4) {
              parent4.classList.add("active");
              const parent5 = parent4.parentElement;
              if (parent5) {
                parent5.classList.add("active");
                const parent6 = parent5.parentElement;
                if (parent6) {
                  parent6.classList.add("active");
                }
              }
            }
          }
        }
      }
    }
  },
  methods: {
    ...layoutMethods,
    /**
     * Menu clicked show the submenu
     */
    onMenuClick(event) {
      event.preventDefault();
      const nextEl = event.target.nextSibling;
      if (nextEl && !nextEl.classList.contains("show")) {
        const parentEl = event.target.parentNode;
        if (parentEl) {
          parentEl.classList.remove("show");
        }
        nextEl.classList.add("show");
      } else if (nextEl) {
        nextEl.classList.remove("show");
      }
      return false;
    },
    /**
     * Returns true or false if given menu item has child or not
     * @param item menuItem
     */
    hasItems(item) {
      return item.subItems !== undefined ? item.subItems.length > 0 : false;
    },
  },
};
</script>
<template>
  <div class="topnav">
    <div class="container-fluid">
      <nav class="navbar navbar-light navbar-expand-lg topnav-menu active">
        <div class="collapse navbar-collapse active" id="topnav-menu-content">
          <ul class="navbar-nav">
            <!-- Menu data -->

            <template v-for="(item, index) of menuItems">
              <li class="nav-item dropdown" :key="index">
                <router-link
                  class="nav-link dropdown-toggle arrow-none"
                  v-if="!item.subItems"
                  id="topnav-components"
                  :to="item.link"
                  role="button"
                >
                  <i :class="`bx ${item.icon} me-2`"></i>{{ $t(item.label) }}
                  <div class="arrow-down" v-if="hasItems(item)"></div>
                </router-link>

                <a
                  v-if="item.subItems"
                  class="nav-link dropdown-toggle arrow-none"
                  @click="onMenuClick($event)"
                  id="topnav-components"
                  role="button"
                >
                  <i :class="`bx ${item.icon} me-1`"></i>
                  {{ $t(item.label) }}
                  <div class="arrow-down"></div>
                </a>

                <div
                  class="dropdown-menu"
                  aria-labelledby="topnav-dashboard"
                  v-if="hasItems(item)"
                >
                  <template v-for="(subitem, index) of item.subItems">
                    <router-link
                      class="col dropdown-item side-nav-link-ref"
                      :key="index"
                      v-if="!hasItems(subitem)"
                      :to="subitem.link"
                      >{{ $t(subitem.label) }}</router-link
                    >

                    <div class="dropdown" v-if="hasItems(subitem)" :key="index">
                      <a
                        class="dropdown-item dropdown-toggle"
                        href="javascript: void(0);"
                        @click="onMenuClick($event)"
                        >{{ $t(subitem.label) }}
                        <div class="arrow-down"></div>
                      </a>
                      <div class="dropdown-menu">
                        <template
                          v-for="(subSubitem, index) of subitem.subItems"
                        >
                          <router-link
                            class="dropdown-item side-nav-link-ref"
                            :key="index"
                            v-if="!hasItems(subSubitem)"
                            :to="subSubitem.link"
                            >{{ $t(subSubitem.label) }}</router-link
                          >
                          <div
                            class="dropdown"
                            v-if="hasItems(subSubitem)"
                            :key="index"
                          >
                            <a
                              class="dropdown-item dropdown-toggle"
                              href="javascript: void(0);"
                              @click="onMenuClick($event)"
                              >{{ $t(subSubitem.label) }}
                              <div class="arrow-down"></div>
                            </a>
                            <div class="dropdown-menu">
                              <template
                                v-for="(
                                  subSubSubitem, index
                                ) of subSubitem.subItems"
                              >
                                <router-link
                                  class="dropdown-item side-nav-link-ref"
                                  :key="index"
                                  :to="subSubSubitem.link"
                                  routerLinkActive="active"
                                  >{{ $t(subSubSubitem.label) }}</router-link
                                >
                              </template>
                            </div>
                          </div>
                        </template>
                      </div>
                    </div>
                  </template>
                </div>
              </li>
            </template>
          </ul>
        </div>
      </nav>
    </div>
  </div>
</template>