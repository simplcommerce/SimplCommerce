/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentBtcPayServer')
        .factory('paymentBtcPayServerService', paymentBtcPayServerService);

    /* @ngInject */
    function paymentBtcPayServerService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/btcpayserver/config');
        }

        function updateSetting(settings) {
            return $http.put('api/btcpayserver/config', settings);
        }
        
        
    }
})();
