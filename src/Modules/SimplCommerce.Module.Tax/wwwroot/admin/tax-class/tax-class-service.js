/*global angular*/
(function () {
    angular
        .module('simplAdmin.tax')
        .factory('taxClassService', ['$http', taxClassService]);

    function taxClassService($http) {
        var service = {
            getTaxClass: getTaxClass,
            createTaxClass: createTaxClass,
            editTaxClass: editTaxClass,
            deleteTaxClass: deleteTaxClass,
            getTaxClasses: getTaxClasses
        };
        return service;

        function getTaxClass(id) {
            return $http.get('api/tax-classes/' + id);
        }

        function getTaxClasses() {
            return $http.get('api/tax-classes');
        }

        function createTaxClass(taxClass) {
            return $http.post('api/tax-classes', taxClass);
        }

        function editTaxClass(taxClass) {
            return $http.put('api/tax-classes/' + taxClass.id, taxClass);
        }

        function deleteTaxClass(taxClass) {
            return $http.delete('api/tax-classes/' + taxClass.id, null);
        }
    }
})();
