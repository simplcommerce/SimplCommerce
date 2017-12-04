/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('countryService', countryService);

    /* @ngInject */
    function countryService($http) {
        var service = {
            getCountries: getCountries,
            editCountry: editCountry
        };
        return service;

        function getCountries(params) {
            return $http.post('api/countries/grid', params);
        }

        function editCountry(country) {
            return $http.put('api/countries/' + country.id, country);
        }
    }
})();