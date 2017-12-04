/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipping-tablerate')
        .factory('shippingTableRateService', shippingTableRateService);

    /* @ngInject */
    function shippingTableRateService($http) {
        var service = {
            updateSetting: updateSetting,
            getPricesAndDestinations: getPricesAndDestinations,
            getCountries: getCountries,
            getStatesOrProvinces: getStatesOrProvinces,
            addPriceAndDestination: addPriceAndDestination,
            updatePriceAndDestination: updatePriceAndDestination,
            deletePriceAndDestination: deletePriceAndDestination
        };
        return service;

        function updateSetting(settings) {
            return $http.post('api/shippings/tablerate/setting', settings);
        }

        function getPricesAndDestinations() {
            return $http.get('api/shippings/table-rate/price-destinations');
        }

        function getCountries() {
            return $http.get('api/countries?shippingEnabled=true');
        }

        function getStatesOrProvinces(countryId) {
            return $http.get('api/countries/' + countryId + '/states-provinces');
        }

        function addPriceAndDestination(priceAndDestination) {
            return $http.post('api/shippings/table-rate/price-destinations', priceAndDestination);
        }

        function updatePriceAndDestination(priceAndDestination) {
            return $http.put('api/shippings/table-rate/price-destinations/' + priceAndDestination.id , priceAndDestination);
        }

        function deletePriceAndDestination(id) {
            return $http.delete('api/shippings/table-rate/price-destinations/' + id);
        }
    }
})();