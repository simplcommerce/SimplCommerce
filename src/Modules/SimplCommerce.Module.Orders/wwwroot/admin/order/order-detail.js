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
        vm.orderStatus = [];
        vm.isStatusFormOpen = false;

        vm.changeOrderStatus = function () {
            orderService.changeOrderStatus(vm.order.id, vm.order.orderStatus)
                .then(function () {
                    vm.isStatusFormOpen = false;
                    vm.order.orderStatusString = vm.orderStatus.find(function (item) { return item.id === vm.order.orderStatus; }).name;
                    toastr.success('The order now is ' + vm.order.orderStatusString);
                })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        function getOrder() {
            orderService.getOrder(vm.orderId).then(function (result) {
                vm.order = result.data;
            });
        }

        function getOrderStatus() {
            orderService.getOrderStatus().then(function (result) {
                vm.orderStatus = result.data;
            });
        }

        function init() {
            getOrderStatus();
            getOrder();
        }

        init();
    }
})();