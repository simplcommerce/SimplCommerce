/*global angular*/
(function () {
    angular
        .module('simplAdmin.shippings')
        .factory('shippingProviderService', shippingProviderService);

    /* @ngInject */
    function shippingProviderService($http) {
        var service = {
            getShippingProviders: getShippingProviders
        };
        return service;

        function getShippingProviders() {
            return $http.get('api/shipping-providers');
        }
    }
})();