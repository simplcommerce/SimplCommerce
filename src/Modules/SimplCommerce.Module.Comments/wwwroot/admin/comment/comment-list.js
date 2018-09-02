/*global angular*/
(function () {
    angular
        .module('simplAdmin.comments')
        .controller('CommentListCtrl', CommentListCtrl);

    /* @ngInject */
    function CommentListCtrl(commentService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.translate = translateService;
        vm.comments = [];

        vm.getComments = function getComments(tableState) {
            vm.isLoading = true;
            vm.tableStateRef = tableState;
            commentService.getCommentsForGrid(tableState).then(function (result) {
                vm.comments = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.approve = function approve(comment) {
            commentService.changeCommentStatus(comment.id, 5)
                .then(function(result) {
                    comment.status = 'Approved';
                });
        };
    }
})();