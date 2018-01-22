/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('countryService', countryService);

    /* @ngInject */
    function countryService($http) {
        var service = {
            getCountries: getCountries,
            editCountry: editCountry,
            getCountry: getCountry,
            createCountry: createCountry,
            deleteCountry: deleteCountry
        };
        return service;

        function getCountries(params) {
            return $http.post('api/countries/grid', params);
        }

        function getCountry(id) {
            return $http.get('api/countries/' + id, null);
        }

        function editCountry(country) {
            return $http.put('api/countries/' + country.id, country);
        }

        function createCountry(country) {
            return $http.post('api/countries/', country);
        }

        function deleteCountry(country) {
            return $http.delete('api/countries/' + country.id, null);
        }
    }
})();