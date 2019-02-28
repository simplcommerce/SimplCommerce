(function () {
    angular
        .module('simpl.comment', ['angularUtils.directives.dirPagination'])
        .controller('CommentCtrl', [
            'commentService',
            function (commentService) {
                var vm = this;
                vm.comment = { entityId: window.simplCommentEntity.entityId, entityTypeId: window.simplCommentEntity.entityTypeId };
                vm.reply = { entityId: vm.comment.entityId, entityTypeId: vm.comment.entityTypeId };
                vm.comments = [];
                vm.commentCount = 0;
                vm.pagination = {
                    current: 1
                };              

                vm.saveComment = function saveComment() {
                    commentService.addComment(vm.comment).then(function (result) {
                        getComments(1);
                        vm.comment.commentText = '';
                    });
                };

                vm.saveReply = function saveReply(comment) {
                    vm.reply.parentId = comment.id;
                    commentService.addComment(vm.reply).then(function (result) {
                        comment.replies.push(result.data);
                        vm.reply.commentText = '';
                    });
                };

                vm.pageChanged = function pageChanged(newPage) {
                    getComments(newPage);
                };

                function getComments(page) {
                    commentService.getComments(vm.comment.entityId, vm.comment.entityTypeId, page).then(function (result) {
                        vm.comments = result.data.items;
                        vm.commentCount = result.data.totalItems;
                    });
                }

                getComments(1); 
            }
        ]);
})();
