(function() {
    angular
        .module('simpl.comment')
        .factory('commentService', [
            '$http',
            function ($http) {
                function addComment(comment) {
                    return $http.post('comments', comment);
                }

                function getComments(entityId, entityTypeId, search, page) {
                    return $http.get('comments?entityId=' + entityId + '&entityTypeId=' + entityTypeId + '&search=' + search + '&page=' + page);
                }

                return {
                    addComment: addComment,
                    getComments: getComments
                };
            }
        ]);
})();
