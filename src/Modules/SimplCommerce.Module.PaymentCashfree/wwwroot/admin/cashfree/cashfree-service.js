/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentCashfree')
        .factory('paymentCashfreeService', ['$http', paymentCashfreeService]);

    function paymentCashfreeService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/cashfree/config');
        }

        function updateSetting(settings) {
            return $http.put('api/cashfree/config', settings);
        }
    }
})();
