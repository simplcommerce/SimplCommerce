(function () {
    angular
        .module('simplAdmin.c')
        .directive('recentlyViewedProducts', recentlyViewedProducts);

    function recentlyViewedProducts() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/recently-viewed-products/admin/recently-viewed-products.directive.html',
            scope: {},
            controller: RecentlyViewedProductCtrl,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function RecentlyViewedProductCtrl(RecentlyViewedProductCtrlService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.products = [];

        RecentlyViewedProductCtrlService.getRecentlyViewedEntities(3).then(function (result) {
            vm.products = result.data;
        });
    }
})();