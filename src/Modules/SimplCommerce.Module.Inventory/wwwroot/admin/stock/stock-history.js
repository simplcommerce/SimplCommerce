/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('StockHistoryCtrl', StockHistoryCtrl);

    /* @ngInject */
    function StockHistoryCtrl($state, $stateParams, stockService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.warehouseId = $stateParams.warehouseId;
        vm.productId = $stateParams.productId;
        vm.history = {};

        function getStockHistory() {
            stockService.getStockHistory(vm.warehouseId, vm.productId).then(function (result) {
                vm.history = result.data;
            });
        }

        function init() {
            getStockHistory();
        }

        init();
    }
})();
