/*global angular*/
(function () {
    angular
        .module('simplAdmin.reviews')
        .factory('reviewService', reviewService);

    /* @ngInject */
    function reviewService($http) {
        var service = {
            getReviews: getReviews,
            getReviewsForGrid: getReviewsForGrid,
            changeReviewStatus: changeReviewStatus
        };
        return service;

        function getReviews(status, numRecords) {
            return $http.get('api/reviews?status=' + status + '&numRecords=' + numRecords);
        }

        function getReviewsForGrid(params) {
            return $http.post('api/reviews/grid', params);
        }

        function changeReviewStatus(reviewId, statusId) {
            return $http.post('api/reviews/change-status/' + reviewId, statusId);
        }
    }
})();