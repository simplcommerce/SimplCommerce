/*global angular*/
(function ($) {
    angular
        .module('simplAdmin.inventory')
        .controller('ManageProductsFormCtrl', ['$stateParams', 'warehouseService', 'stockService', 'translateService', ManageProductsFormCtrl]);

    function ManageProductsFormCtrl($stateParams, warehouseService, stockService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.initialWarehouseId = parseInt($stateParams.warehouseId, 10);
        vm.translate = translateService;
        vm.products = [];
        vm.warehouses = [];

        vm.getProducts = function getProducts(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            warehouseService.getProducts(vm.selectedWarehouse.id, tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.wareHouseSelectChange = function wareHouseSelectChange() {
            vm.getProducts(vm.tableStateRef);
        };

        vm.addAllProducts = function addAllProducts() {
            warehouseService.addAllProducts(vm.selectedWarehouse.id)
                .then(function (result) {
                    vm.getProducts(vm.tableStateRef);
                    toastr.success('All products have been added');
                })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        vm.addSelectedProducts = function addSelectedProducts() {
            var selectedProductIds = $('.productid-select:checked').map(function () {
                return this.value;
            }).get();

            warehouseService.addSelectedProducts(vm.selectedWarehouse.id, selectedProductIds)
                .then(function (result) {
                    vm.getProducts(vm.tableStateRef);
                    toastr.success('Selected products have been updated');
                })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        stockService.getWarehouses().then(function (result) {
            vm.warehouses = result.data;
            if (vm.warehouses.length >= 1) {
                vm.selectedWarehouse = vm.warehouses.find(function (x) { return x.id === vm.initialWarehouseId; });
            }
        });
    }
})(jQuery);
