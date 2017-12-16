/*global angular*/
(function () {
    angular
        .module('simplAdmin.payments')
        .factory('paymentProviderService', paymentProviderService);

    /* @ngInject */
    function paymentProviderService($http) {
        var service = {
            getPaymentProviders: getPaymentProviders,
            enableProvider: enableProvider,
            disableProvider: disableProvider
        };
        return service;

        function getPaymentProviders() {
            return $http.get('api/payments-providers');
        }

        function enableProvider(provider) {
            return $http.post('api/payments-providers/' + provider.id + '/enable');
        }

        function disableProvider(provider) {
            return $http.post('api/payments-providers/' + provider.id + '/disable');
        }
    }
})();