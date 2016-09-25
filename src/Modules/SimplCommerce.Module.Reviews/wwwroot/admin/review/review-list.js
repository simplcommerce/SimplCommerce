/*global angular*/
(function () {
    angular
        .module('simplAdmin.reviews')
        .controller('ReviewListCtrl', ReviewListCtrl);

    /* @ngInject */
    function ReviewListCtrl(reviewService) {
        var vm = this;
        vm.reviews = [];

        vm.getReviews = function getReviews(tableState) {
            vm.isLoading = true;
            reviewService.getReviewsForGrid(tableState).then(function (result) {
                vm.reviews = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.approve = function approve(review) {
            reviewService.changeReviewStatus(review.id, 5)
                .then(function(result) {
                    review.status = 'Approved';
                });
        };
    }
})();