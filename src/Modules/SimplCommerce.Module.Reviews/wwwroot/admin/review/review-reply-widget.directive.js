(function() {
    angular
        .module('simplAdmin.reviews')
        .directive('reviewReplyWidget', reviewReplyWidget);

    function reviewReplyWidget() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/reviews/admin/review/review-reply-widget.directive.html',
            scope: {
                status: '=',
                numRecords: '='
            },
            controller: ['reviewReplyService', 'translateService', ReviewReplyWidgetCtrl],
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    function ReviewReplyWidgetCtrl(reviewReplyService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.replies = [];

        vm.$onInit = function () {
            reviewReplyService.getReplies(vm.status, vm.numRecords).then(function (result) {
                vm.replies = result.data;
            });
        };
    }
})();
