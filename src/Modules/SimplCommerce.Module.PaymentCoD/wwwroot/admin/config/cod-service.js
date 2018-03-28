/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentCoD')
        .factory('paymentCoDService', paymentCoDService);

    /* @ngInject */
    function paymentCoDService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/cod/config');
        }

        function updateSetting(settings) {
            return $http.put('api/cod/config', settings);
        }
    }
})();