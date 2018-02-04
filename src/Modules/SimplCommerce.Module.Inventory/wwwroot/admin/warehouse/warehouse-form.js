/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('WarehouseFormCtrl', WarehouseFormCtrl);

    /* @ngInject */
    function WarehouseFormCtrl(warehouseService, translateService, $state, $stateParams) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.warehouseId = $stateParams.id;
        vm.isEditMode = vm.warehouseId > 0;

        vm.warehouse = {};
        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.districts = [];

        vm.getStocks = function getStocks(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            stockService.getStocks(vm.selectedWarehouseId, tableState).then(function (result) {
                vm.stocks = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = warehouseService.editWarehouse(vm.warehouse);
            } else {
                promise = warehouseService.createWarehouse(vm.warehouse);
            }

            promise
                .then(function (result) {
                    $state.go('warehouses');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push(translateService.get('Could not save Warehouse.'));
                    }
                });
        };

        getCountries = function () {
            warehouseService.getCountries().then(function (result) {
                vm.countries = result.data;
                vm.warehouse.countryId = vm.warehouse.countryId || vm.countries[0].id.toString();
            }).catch(function (err) { });
        };

        getStatesOrProvinces = function (countryId) {
            warehouseService.getStatesOrProvinces(countryId).then(function (result) {
                vm.statesOrProvinces = result.data;
                vm.warehouse.stateOrProvinceId = vm.warehouse.stateOrProvinceId || vm.statesOrProvinces[0].id.toString();
            }).catch(function (err) { });
        };

        getDistricts = function (stateOrProvinceId) {
            warehouseService.getDistricts(stateOrProvinceId).then(function (result) {
                vm.districts = result.data;
                vm.warehouse.districtId = vm.warehouse.districtId || vm.districts[0].id.toString();
            }).catch(function (err) { });
        };


        vm.onStateOrProvinceSelected = function (stateOrProvinceId) {
            getDistricts(stateOrProvinceId);
        };

        vm.onCountrySelected = function (countryId) {
            vm.statesOrProvinces = [];
            vm.districts = [];
            getStatesOrProvinces(countryId);
        };

        function init() {
            if (vm.isEditMode) {
                warehouseService.getWarehouse(vm.warehouseId).then(function (result) {
                    vm.warehouse = result.data;

                    getCountries();

                    getStatesOrProvinces(vm.warehouse.countryId);

                    getDistricts(vm.warehouse.stateOrProvinceId);
                });
            } else {
                getCountries();
            }


        }

        init();

    }
})();