(function () {
    angular
        .module('simpl.comment', ['ui.bootstrap'])
        .controller('CommentCtrl', [
            '$scope',
            'commentService',
            function ($scope, commentService) {
                var vm = this;
                vm.comment = {};
                vm.comments = [];
                vm.currentPage = 1;
                $scope.currentPage = 1;

                vm.addComment = function addComment() {
                    commentService.addComment(vm.comment).then(function (result) {
                        comments.push(result.data);
                    });
                };

                vm.commentCount = 100;
            }
        ]);
})();
