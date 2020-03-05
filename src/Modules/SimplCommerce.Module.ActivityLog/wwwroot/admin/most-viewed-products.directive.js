(function() {
    angular
        .module('simplAdmin.activityLog')
        .directive('mostViewedProducts', mostViewedProducts);

    function mostViewedProducts() {
        var directive = {
            restrict: 'E',
            templateUrl: '_content/SimplCommerce.Module.ActivityLog/admin/most-viewed-products.directive.html',
            scope: {},
            controller: ['activityLogService', 'translateService', MostMostViewedProductCtrl],
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    function MostMostViewedProductCtrl(activityLogService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.products = [];

        activityLogService.getMostViewedEntities("Product").then(function (result) {
            vm.products = result.data;
        });
    }
})();
