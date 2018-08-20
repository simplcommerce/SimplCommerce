/*global angular*/
(function () {
    angular
        .module('simplAdmin.shippings')
        .factory('shippingProviderService', shippingProviderService);

    /* @ngInject */
    function shippingProviderService($http) {
        var service = {
            getShippingProviders: getShippingProviders,
            enableProvider: enableProvider,
            disableProvider: disableProvider
        };
        return service;

        function getShippingProviders() {
            return $http.get('api/shipping-providers');
        }

        function enableProvider(provider) {
            return $http.post('api/shipping-providers/' + provider.id + '/enable');
        }

        function disableProvider(provider) {
            return $http.post('api/shipping-providers/' + provider.id + '/disable');
        }
    }
})();