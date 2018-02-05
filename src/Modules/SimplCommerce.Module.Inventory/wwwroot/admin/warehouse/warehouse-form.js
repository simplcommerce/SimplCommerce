/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('WarehouseFormCtrl', WarehouseFormCtrl);

    /* @ngInject */
    function WarehouseFormCtrl(warehouseService, translateService, $state, $stateParams) {
        var vm = this;
        vm.translate = translateService;
        vm.warehouseId = $stateParams.id;
        vm.isEditMode = vm.warehouseId > 0;

        vm.warehouse = {};
        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.districts = [];

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
            });
        };

        getStatesOrProvinces = function (countryId) {
            warehouseService.getStatesOrProvinces(countryId).then(function (result) {
                vm.statesOrProvinces = result.data;
                vm.warehouse.stateOrProvinceId = vm.warehouse.stateOrProvinceId || vm.statesOrProvinces[0].id.toString();
            });
        };

        getDistricts = function (stateOrProvinceId) {
            warehouseService.getDistricts(stateOrProvinceId).then(function (result) {
                vm.districts = result.data;
                vm.warehouse.districtId = vm.warehouse.districtId || vm.districts[0].id;
            });
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
            getCountries();
            if (vm.isEditMode) {
                warehouseService.getWarehouse(vm.warehouseId).then(function (result) {
                    vm.warehouse = result.data;

                    if (vm.warehouse.countryId) {
                        getStatesOrProvinces(vm.warehouse.countryId);
                    }

                    if (vm.warehouse.stateOrProvinceId) {
                        getDistricts(vm.warehouse.stateOrProvinceId);
                    }
                });
            }
        }

        init();
    }
})();