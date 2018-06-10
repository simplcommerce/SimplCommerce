/*global angular*/
(function () {
    angular
        .module('simplAdmin.tax')
        .factory('taxRateService', taxRateService);

    /* @ngInject */
    function taxRateService($http, Upload) {
        var service = {
            getTaxRate: getTaxRate,
            createTaxRate: createTaxRate,
            importTaxRates: importTaxRates,
            editTaxRate: editTaxRate,
            deleteTaxRate: deleteTaxRate,
            getTaxRates: getTaxRates,
            getCountries: getCountries,
            getStatesOrProvinces: getStatesOrProvinces
        };
        return service;

        function getTaxRate(id) {
            return $http.get('api/tax-rates/' + id);
        }

        function getTaxRates() {
            return $http.get('api/tax-rates');
        }

        function createTaxRate(taxRate) {
            return $http.post('api/tax-rates', taxRate);
        }

        function importTaxRates(taxRateImport) {
            return Upload.upload({
                url: 'api/tax-rates/import',
                data: taxRateImport
            });
        }

        function editTaxRate(taxRate) {
            return $http.put('api/tax-rates/' + taxRate.id, taxRate);
        }

        function deleteTaxRate(taxRate) {
            return $http.delete('api/tax-rates/' + taxRate.id, null);
        }

        function getCountries() {
            return $http.get('api/countries');
        }

        function getStatesOrProvinces(countryId) {
            return $http.get('api/countries/' + countryId + '/states-provinces');
        }
    }
})();