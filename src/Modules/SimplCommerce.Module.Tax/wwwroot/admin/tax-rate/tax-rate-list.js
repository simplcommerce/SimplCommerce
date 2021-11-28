/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.tax')
        .controller('TaxRateListCtrl', ['taxRateService', 'translateService', TaxRateListCtrl]);

    function TaxRateListCtrl(taxRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxRates = [];

        vm.getTaxRates = function getTaxRates() {
            taxRateService.getTaxRates().then(function (result) {
                vm.taxRates = result.data;
            });
        };

        vm.deleteTaxRate = function deleteTaxRate(taxRate) {
            bootbox.confirm('Are you sure you want to delete this taxRate: ' + simplUtil.escapeHtml(taxRate.name), function (result) {
                if (result) {
                    taxRateService.deleteTaxRate(taxRate)
                        .then(function (result) {
                            vm.getTaxRates();
                            toastr.success(taxRate.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        vm.getTaxRates();
    }
})();
