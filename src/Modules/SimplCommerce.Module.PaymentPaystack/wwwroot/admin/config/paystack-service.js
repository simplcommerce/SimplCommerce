/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentPaystack')
        .factory('paystackService', ['$http', paystackService]);

    function paystackService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/paystack/config');
        }

        function updateSetting(settings) {
            return $http.put('api/paystack/config', settings);
        }
    }
})();
