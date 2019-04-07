/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentBtcPayServer')
        .factory('paymentBtcPayServerService', paymentBtcPayServerService);

    /* @ngInject */
    function paymentBtcPayServerService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting,
            unpair: unpair
        };
        return service;

        function getSettings() {
            return $http.get('api/btcpayserver/config');
        }

        function updateSetting(settings) {
            return $http.put('api/btcpayserver/config', settings);
        }
        function unpair() {
            return $http.get('api/btcpayserver/unpair');
        }
        
        
    }
})();
