/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentMomo')
        .factory('paymentMomoService', ['$http', paymentMomoService]);

    function paymentMomoService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/momo/config');
        }

        function updateSetting(settings) {
            return $http.put('api/momo/config', settings);
        }
    }
})();
