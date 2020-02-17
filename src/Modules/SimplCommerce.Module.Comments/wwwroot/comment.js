(function () {
    angular
        .module('simpl.comment', ['angularUtils.directives.dirPagination'])
        .controller('CommentCtrl', [
            '$scope',
            'commentService',
            function ($scope, commentService) {
                var vm = this;
                vm.comment = { entityId: window.simplCommentEntity.entityId, entityTypeId: window.simplCommentEntity.entityTypeId };
                vm.comments = [];
                vm.search = '';
                vm.commentCount = 0;
                vm.pagination = {
                    current: 1
                };

                $scope.$watch(angular.bind(this, function () { return this.search; }),
                    function (newVal) {
                        if (newVal && newVal.length > 0) {
                            getComments(1);
                        }
                });

                vm.saveComment = function saveComment() {
                    commentService.addComment(vm.comment).then(function (result) {
                        getComments(1);
                        vm.comment.commentText = '';
                    });
                };

                vm.saveReply = function saveReply(comment) {
                    comment.newReply.parentId = comment.id;
                    commentService.addComment(comment.newReply).then(function (result) {
                        comment.replies.push(result.data);
                        comment.newReply.commentText = '';
                    });
                };

                vm.addReply = function addReply(comment) {
                    comment.newReply = { entityId: vm.comment.entityId, entityTypeId: vm.comment.entityTypeId };
                };

                vm.pageChanged = function pageChanged(newPage) {
                    getComments(newPage);
                };

                function getComments(page) {
                    commentService.getComments(vm.comment.entityId, vm.comment.entityTypeId, vm.search, page).then(function (result) {
                        vm.comments = result.data.items;
                        vm.commentCount = result.data.totalItems;
                    });
                }

                getComments(1); 
            }
        ]);
})();
