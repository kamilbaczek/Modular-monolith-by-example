<script>
import MetisMenu from "metismenujs/dist/metismenujs";

import {
    menuItems
} from "./menu";

/**
 * Sidenav component
 */
export default {
    data() {
        return {
            menuItems: menuItems,
            menuData: null,
        };
    },
    mounted: function () {
    
        // eslint-disable-next-line no-unused-vars
        var menuRef = new MetisMenu("#side-menu");
        var links = document.getElementsByClassName("side-nav-link-ref");
        var matchingMenuItem = null;
        const paths = [];

        for (var i = 0; i < links.length; i++) {
            paths.push(links[i]["pathname"]);
        }
        var itemIndex = paths.indexOf(window.location.pathname);
        if (itemIndex === -1) {
            const strIndex = window.location.pathname.lastIndexOf("/");
            const item = window.location.pathname.substr(0, strIndex).toString();
            matchingMenuItem = links[paths.indexOf(item)];
        } else {
            matchingMenuItem = links[itemIndex];
        }

        if (matchingMenuItem) {
            matchingMenuItem.classList.add("active");
            var parent = matchingMenuItem.parentElement;

            /**
             * TODO: This is hard coded way of expading/activating parent menu dropdown and working till level 3.
             * We should come up with non hard coded approach
             */
            if (parent) {
                parent.classList.add("mm-active");
                const parent2 = parent.parentElement.closest("ul");
                if (parent2 && parent2.id !== "side-menu") {
                    parent2.classList.add("mm-show");

                    const parent3 = parent2.parentElement;
                    if (parent3) {
                        parent3.classList.add("mm-active");
                        var childAnchor = parent3.querySelector(".has-arrow");
                        var childDropdown = parent3.querySelector(".has-dropdown");
                        if (childAnchor) childAnchor.classList.add("mm-active");
                        if (childDropdown) childDropdown.classList.add("mm-active");

                        const parent4 = parent3.parentElement;
                        if (parent4 && parent4.id !== "side-menu") {
                            parent4.classList.add("mm-show");
                            const parent5 = parent4.parentElement;
                            if (parent5 && parent5.id !== "side-menu") {
                                parent5.classList.add("mm-active");
                                const childanchor = parent5.querySelector(".is-parent");
                                if (childanchor && parent5.id !== "side-menu") {
                                    childanchor.classList.add("mm-active");
                                }
                            }
                        }
                    }
                }
            }
        }
    },
    methods: {
        /**
         * Returns true or false if given menu item has child or not
         * @param item menuItem
         */
        hasItems(item) {
            return item.subItems !== undefined ? item.subItems.length > 0 : false;
        },

        toggleMenu(event) {
            event.currentTarget.nextElementSibling.classList.toggle("mm-show");
        },
    },
};
</script>

<template>
<!-- ========== Left Sidebar Start ========== -->

<!--- Sidemenu -->
<div id="sidebar-menu">
    <!-- Left Menu Start -->
    <ul id="side-menu" class="metismenu list-unstyled">
        <template v-for="item in menuItems">
            <li class="menu-title" v-if="item.isTitle" :key="item.id">
                {{ $t(item.label) }}
            </li>
            <li v-if="!item.isTitle && !item.isLayout" :key="item.id">
                <a v-if="hasItems(item)" href="javascript:void(0);" class="is-parent" :class="{ 'has-arrow': !item.badge, 'has-dropdown': item.badge }">
                    <i :class="`bx ${item.icon}`" v-if="item.icon"></i>
                    <span>{{ $t(item.label) }}</span>
                    <span :class="`badge rounded-pill bg-${item.badge.variant} float-end`" v-if="item.badge">{{ $t(item.badge.text) }}</span>
                </a>

                <router-link :to="item.link" v-if="!hasItems(item)" class="side-nav-link-ref">
                    <i :class="`bx ${item.icon}`" v-if="item.icon"></i>
                    <span>{{ $t(item.label) }}</span>
                    <span :class="`badge rounded-pill bg-${item.badge.variant} float-end`" v-if="item.badge">{{ $t(item.badge.text) }}</span>
                </router-link>

                <ul v-if="hasItems(item)" class="sub-menu" aria-expanded="false">
                    <li v-for="(subitem, index) of item.subItems" :key="index">
                        <router-link :to="subitem.link" v-if="!hasItems(subitem)" class="side-nav-link-ref">{{ $t(subitem.label) }}</router-link>
                        <a v-if="hasItems(subitem)" class="side-nav-link-a-ref has-arrow" href="javascript:void(0);">{{ $t(subitem.label) }}</a>
                        <ul v-if="hasItems(subitem)" class="sub-menu mm-collapse" aria-expanded="false">
                            <li v-for="(subSubitem, index) of subitem.subItems" :key="index">
                                <router-link :to="subSubitem.link" class="side-nav-link-ref">{{ $t(subSubitem.label) }}</router-link>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>
        </template>
    </ul>
</div>
<!-- Sidebar -->
</template>
