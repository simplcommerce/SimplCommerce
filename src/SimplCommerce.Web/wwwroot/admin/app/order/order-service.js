/*global angular*/
(function () {
    angular
        .module('shopAdmin.order')
        .factory('orderService', orderService);

    /* @ngInject */
    function orderService($http) {
        var service = {
            getOrders : getOrders
        };
        return service;

        function getOrders(params) {
            return $http.post('Admin/Order/List', params);
        }
    }
})();