/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentStripeV2')
        .factory('paymentStripeV2Service', ['$http', paymentStripeV2Service]);

    function paymentStripeV2Service($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/stripev2/config');
        }

        function updateSetting(settings) {
            return $http.put('api/stripev2/config', settings);
        }
    }
})();
