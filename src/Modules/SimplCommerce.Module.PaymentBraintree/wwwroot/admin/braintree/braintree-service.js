/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentBraintree')
        .factory('paymentBraintreeService', ['$http', paymentBraintreeService]);

    function paymentBraintreeService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/braintree/config');
        }

        function updateSetting(settings) {
            return $http.put('api/braintree/config', settings);
        }
    }
})();
