/*global angular*/
(function () {
    angular
        .module('simplAdmin.comments')
        .factory('commentService', commentService);

    /* @ngInject */
    function commentService($http) {
        var service = {
            getComments: getComments,
            getCommentsForGrid: getCommentsForGrid,
            changeCommentStatus: changeCommentStatus
        };

        return service;

        function getComments(status, numRecords) {
            return $http.get('api/comments?status=' + status + '&numRecords=' + numRecords);
        }

        function getCommentsForGrid(params) {
            return $http.post('api/comments/grid', params);
        }

        function changeCommentStatus(commentId, statusId) {
            return $http.post('api/comments/change-status/' + commentId, statusId);
        }
    }
})();