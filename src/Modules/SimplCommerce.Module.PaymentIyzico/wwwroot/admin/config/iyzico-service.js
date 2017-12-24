/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentIyzico')
        .factory('iyzicoService', iyzicoService);

    /* @ngInject */
    function iyzicoService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/iyzico/config');
        }

        function updateSetting(settings) {
            return $http.put('api/iyzico/config', settings);
        }
    }
})();