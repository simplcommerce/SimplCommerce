/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentNganLuong')
        .factory('paymentNganLuongService', ['$http', paymentNganLuongService]);

    function paymentNganLuongService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/ngan-luong/config');
        }

        function updateSetting(settings) {
            return $http.put('api/ngan-luong/config', settings);
        }
    }
})();
