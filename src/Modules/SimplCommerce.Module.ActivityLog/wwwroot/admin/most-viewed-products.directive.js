(function() {
    angular
        .module('simplAdmin.activityLog')
        .directive('mostViewedProducts', mostViewedProducts);

    function mostViewedProducts() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/activity-log/admin/most-viewed-products.directive.html',
            scope: {},
            controller: MostMostViewedProductCtrl,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function MostMostViewedProductCtrl(activityLogService) {
        var vm = this;
        vm.products = [];

        activityLogService.getMostViewedEntities(3).then(function (result) {
            vm.products = result.data;
        });
    }
})();
