/*global angular*/
(function () {
    angular
        .module('simplAdmin.reviews')
        .controller('ReviewReplyListCtrl', ['reviewReplyService', 'translateService', ReviewReplyListCtrl]);

    function ReviewReplyListCtrl(reviewReplyService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.replies = [];

        vm.getReplies = function getReplies(tableState) {
            vm.isLoading = true;
            reviewReplyService.getRepliesForGrid(tableState).then(function(result) {
                vm.replies = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.approve = function approve(reply) {
            reviewReplyService.changeReplyStatus(reply.id, 5)
                .then(function(result) {
                    reply.status = 'Approved';
                });
        };
    }
})();
