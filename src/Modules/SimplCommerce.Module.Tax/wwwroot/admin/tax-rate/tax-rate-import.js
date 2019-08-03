/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.tax')
        .controller('TaxRateImportFormCtrl', ['$state', 'taxRateService', 'translateService', TaxRateImportFormCtrl]);

    function TaxRateImportFormCtrl($state, taxRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxRateImport = { csvDelimiter: ',', includeHeader: true };

        vm.save = function save() {
            taxRateService.importTaxRates(vm.taxRateImport)
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
                        vm.validationErrors.push('Could not import tax rates.');
                    }
                });
        };
    }
})(jQuery);
