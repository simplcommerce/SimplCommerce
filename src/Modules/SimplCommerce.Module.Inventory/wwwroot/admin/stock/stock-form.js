/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('StockFormCtrl', StockFormCtrl);

    /* @ngInject */
    function StockFormCtrl(stockService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.translate = translateService;
        vm.stocks = [];
        vm.warehouses = [];

        vm.getStocks = function getStocks(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            stockService.getStocks(vm.selectedWarehouseId, tableState).then(function (result) {
                vm.stocks = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.wareHouseSelectChange = function wareHouseSelectChange() {
            vm.getStocks(vm.tableStateRef);
        };

        vm.addAllProducts = function addAllProducts() {
            stockService.addAllProducts(vm.selectedWarehouseId)
                .then(function (result) {
                    vm.getStocks(vm.tableStateRef);
                    toastr.success('All products have been added');
                })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        vm.save = function save() {
            stockService.updateStocks(vm.selectedWarehouseId, vm.stocks).then(function (result) {
                vm.getStocks(vm.tableStateRef);
                toastr.success('Stocks have been updated');
            })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        stockService.getWarehouses().then(function (result) {
            vm.warehouses = result.data;
            if (vm.warehouses.length >= 1) {
                vm.selectedWarehouseId = vm.warehouses[0].id;
            }
        });
    }
})();