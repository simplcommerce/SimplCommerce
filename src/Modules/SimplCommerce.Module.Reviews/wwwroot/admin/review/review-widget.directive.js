(function() {
    angular
        .module('simplAdmin.reviews')
        .directive('reviewWidget', reviewWidget);

    function reviewWidget() {
        var directive = {
            restrict: 'E',
            templateUrl: '_content/SimplCommerce.Module.Reviews/admin/review/review-widget.directive.html',
            scope: {
                status: '=',
                numRecords: '='
            },
            controller: ['reviewService', 'translateService', ReviewWidgetCtrl],
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

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
