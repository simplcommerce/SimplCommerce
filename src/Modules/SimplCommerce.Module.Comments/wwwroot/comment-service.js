(function() {
    angular
        .module('simpl.comment')
        .factory('commentService', [
            '$http',
            function ($http) {
                function getShoppingCartItems() {
                    return $http.get('cart/list');
                }
                
                function addComment(comment) {
                    return $http.post('comments', comment);
                }

                return {
                    addComment: addComment
                };
            }
        ]);
})();
