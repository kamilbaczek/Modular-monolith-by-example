<script>
import {
    layoutComputed
} from "@/state/helpers";
import Vertical from "./vertical";
import Horizontal from "./horizontal";

export default {
    components: {
        Vertical,
        Horizontal,
    },
    data() {
        return {};
    },
    computed: {
        ...layoutComputed,
    },
    methods: {},
};
</script>

<template>
<div>
    <vertical v-if="layoutType === 'vertical'" :layout="layoutType">
        <slot />
    </vertical>

    <Horizontal v-if="layoutType === 'horizontal'" :layout="layoutType">
        <slot />
    </Horizontal>
</div>
</template>
