/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .controller('OrderDetailCtrl', OrderDetailCtrl);

    /* @ngInject */
    function OrderDetailCtrl($state, $stateParams, orderService) {
        var vm = this;

        vm.orderId = $stateParams.id;
        vm.order = {};

        vm.getOrder = function getOrder() {
            orderService.getOrder(vm.orderId).then(function (result) {
                vm.order = result.data;
            });
        };

        function init() {
            vm.getOrder();
        }

        init();
    }
})();