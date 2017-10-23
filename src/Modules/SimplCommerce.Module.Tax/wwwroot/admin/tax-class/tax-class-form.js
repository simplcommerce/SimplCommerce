/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.tax')
        .controller('TaxRateFormCtrl', TaxRateFormCtrl);

    /* @ngInject */
    function TaxRateFormCtrl($state, $stateParams, taxRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxRate = {};
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
                        vm.validationErrors.push('Could not add tax rate.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                taxRateService.getTaxRate(vm.taxRateId).then(function (result) {
                    vm.taxRate = result.data;
                });
            }
        }

        init();
    }
})(jQuery);