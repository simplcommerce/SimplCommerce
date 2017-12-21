/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentStripe')
        .factory('paymentSripeService', paymentSripeService);

    /* @ngInject */
    function paymentSripeService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/stripe/config');
        }

        function updateSetting(settings) {
            return $http.put('api/stripe/config', settings);
        }
    }
})();