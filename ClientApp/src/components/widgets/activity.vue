<script>
import Loader from "./loader";

export default {
  components: {
    Loader,
  },
  props: {
    updating: {
      type: Boolean,
    },
  },
};
</script>
<template>
  <Loader :loading="updating">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title mb-5">Activity</h4>
        <ul class="verti-timeline list-unstyled">
          <li class="event-list">
            <div class="event-timeline-dot">
              <i class="bx bx-right-arrow-circle font-size-18"></i>
            </div>
            <div class="media">
              <div class="me-3">
                <h5 class="font-size-14">
                  22 Nov
                  <i
                    class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                  ></i>
                </h5>
              </div>
              <div class="media-body">
                <div>Responded to need “Volunteer Activities</div>
              </div>
            </div>
          </li>
          <li class="event-list">
            <div class="event-timeline-dot">
              <i class="bx bx-right-arrow-circle font-size-18"></i>
            </div>
            <div class="media">
              <div class="me-3">
                <h5 class="font-size-14">
                  17 Nov
                  <i
                    class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                  ></i>
                </h5>
              </div>
              <div class="media-body">
                <div>
                  Everyone realizes why a new common language would be
                  desirable...
                  <a href="javascript: void(0);">Read more</a>
                </div>
              </div>
            </div>
          </li>
          <li class="event-list active">
            <div class="event-timeline-dot">
              <i
                class="bx bxs-right-arrow-circle font-size-18 bx-fade-right"
              ></i>
            </div>
            <div class="media">
              <div class="me-3">
                <h5 class="font-size-14">
                  15 Nov
                  <i
                    class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                  ></i>
                </h5>
              </div>
              <div class="media-body">
                <div>Joined the group “Boardsmanship Forum”</div>
              </div>
            </div>
          </li>
          <li class="event-list">
            <div class="event-timeline-dot">
              <i class="bx bx-right-arrow-circle font-size-18"></i>
            </div>
            <div class="media">
              <div class="me-3">
                <h5 class="font-size-14">
                  12 Nov
                  <i
                    class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                  ></i>
                </h5>
              </div>
              <div class="media-body">
                <div>Responded to need “In-Kind Opportunity”</div>
              </div>
            </div>
          </li>
        </ul>
        <div class="text-center mt-4">
          <a href="javascript: void(0);" class="btn btn-primary btn-sm"
            >View More <i class="mdi mdi-arrow-right ms-1"></i></a
          >
        </div>
      </div>
    </div>
  </Loader>
</template>