/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('WarehouseListCtrl', WarehouseListCtrl);

    /* @ngInject */
    function WarehouseListCtrl(warehouseService, translateService, $state) {
        var vm = this,
            tableStateRef;
        vm.warehouses = [];
        vm.translate = translateService;

        vm.getWarehouses = function (tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            warehouseService.getWarehouses(tableState).then(function (result) {
                vm.warehouses = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };


        vm.deleteCountry = function (country) {
            bootbox.confirm('Are you sure you want to delete this country: ' + country.name, function (result) {
                if (result) {
                    countryService.deleteCountry(country)
                        .then(function (result) {
                            vm.getCountries(tableStateRef);
                            toastr.success(country.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };
    }
})();