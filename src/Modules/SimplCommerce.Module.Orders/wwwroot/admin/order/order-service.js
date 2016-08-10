/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .factory('orderService', orderService);

    /* @ngInject */
    function orderService($http) {
        var service = {
            getOrders : getOrders,
            getOrder: getOrder,
            getOrderStatus: getOrderStatus,
            changeOrderStatus: changeOrderStatus
        };
        return service;

        function getOrders(params) {
            return $http.post('api/orders/grid', params);
        }

        function getOrder(orderId) {
            return $http.get('api/orders/' + orderId);
        }

        function getOrderStatus() {
            return $http.get('api/orders/order-status');
        }

        function changeOrderStatus(orderId, statusId) {
            return $http.post('api/orders/change-order-status/' + orderId, statusId);
        }
    }
})();