/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.tax')
        .controller('TaxRateFormCtrl', ['$state', '$stateParams', 'taxClassService', 'taxRateService', 'translateService', TaxRateFormCtrl]);

    function TaxRateFormCtrl($state, $stateParams, taxClassService, taxRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxRate = { rate : 0 };
        vm.taxClasses = [];
        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.taxRateId = $stateParams.id;
        vm.isEditMode = vm.taxRateId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = taxRateService.editTaxRate(vm.taxRate);
            } else {
                promise = taxRateService.createTaxRate(vm.taxRate);
            }

            promise
                .then(function (result) {
                    $state.go('tax-rates');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add/update tax rate.');
                    }
                });
        };

        vm.reloadStatesOrProvinces = function reloadStatesOrProvinces() {
            taxRateService.getStatesOrProvinces(vm.taxRate.countryId).then(function (result) {
                vm.statesOrProvinces = result.data;
            });
        };

        function getCountries() {
            taxRateService.getCountries().then(function (result) {
                vm.countries = result.data;
            });
        }

        function getTaxClasses() {
            taxClassService.getTaxClasses().then(function (result) {
                vm.taxClasses = result.data;
            });
        }

        function init() {
            getCountries();
            getTaxClasses();
            if (vm.isEditMode) {
                taxRateService.getTaxRate(vm.taxRateId).then(function (result) {
                    vm.taxRate = result.data;
                    vm.reloadStatesOrProvinces();
                });
            }
        }

        init();
    }
})(jQuery);
