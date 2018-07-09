/*global angular*/
(function () {
    angular
        .module('simplAdmin.reviews')
        .factory('reviewReplyService', reviewReplyService);

    /* @ngInject */
    function reviewReplyService($http) {
        var service = {
            getReplies: getReplies,
            getRepliesForGrid: getRepliesForGrid,
            changeReplyStatus: changeReplyStatus
        };
        return service;

        function getReplies(status, numRecords) {
            return $http.get('api/review-replies?status=' + status + '&numRecords=' + numRecords);
        }

        function getRepliesForGrid(params) {
            return $http.post('api/review-replies/grid', params);
        }

        function changeReplyStatus(replyId, statusId) {
            return $http.post('api/review-replies/change-status/' + replyId, statusId);
        }
    }
})();