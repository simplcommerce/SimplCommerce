/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .factory('orderService', orderService);

    /* @ngInject */
    function orderService($http) {
        var service = {
            getOrders : getOrders,
            getOrder : getOrder
        };
        return service;

        function getOrders(params) {
            return $http.post('api/orders/grid', params);
        }

        function getOrder(orderId) {
            return $http.get('api/orders/' + orderId);
        }
    }
})();