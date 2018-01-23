/*global angular*/
(function () {
    angular
        .module('simplAdmin.payments')
        .factory('paymentService', paymentService);

    /* @ngInject */
    function paymentService($http) {
        var service = {
            getPaymentsByOrder: getPaymentsByOrder
        };
        return service;

        function getPaymentsByOrder(orderId) {
            return $http.get('api/orders/' + orderId + '/payments');
        }
    }
})();