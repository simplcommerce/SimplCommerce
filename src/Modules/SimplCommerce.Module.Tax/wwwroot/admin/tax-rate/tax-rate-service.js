/*global angular*/
(function () {
    angular
        .module('simplAdmin.tax')
        .factory('taxRateService', taxRateService);

    /* @ngInject */
    function taxRateService($http) {
        var service = {
            getTaxRate: getTaxRate,
            createTaxRate: createTaxRate,
            editTaxRate: editTaxRate,
            deleteTaxRate: deleteTaxRate,
            getTaxRates: getTaxRates
        };
        return service;

        function getTaxRate(id) {
            return $http.get('api/tax-classes/' + id);
        }

        function getTaxRates() {
            return $http.get('api/tax-classes');
        }

        function createTaxRate(taxRate) {
            return $http.post('api/tax-classes', taxRate);
        }

        function editTaxRate(taxRate) {
            return $http.put('api/tax-classes/' + taxRate.id, taxRate);
        }

        function deleteTaxRate(taxRate) {
            return $http.delete('api/tax-classes/' + taxRate.id, null);
        }
    }
})();