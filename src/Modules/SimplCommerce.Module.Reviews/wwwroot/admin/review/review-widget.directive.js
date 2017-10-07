(function() {
    angular
        .module('simplAdmin.reviews')
        .directive('reviewWidget', reviewWidget);

    function reviewWidget() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/reviews/admin/review/review-widget.directive.html',
            scope: {
                status: '=',
                numRecords: '='
            },
            controller: ReviewWidgetCtrl,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function ReviewWidgetCtrl(reviewService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.reviews = [];

        vm.$onInit = function () {
            reviewService.getReviews(vm.status, vm.numRecords).then(function (result) {
                vm.reviews = result.data;
            });
        };
    }
})();
