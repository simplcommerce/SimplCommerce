/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .controller('OrderDetailCtrl', ['$stateParams', 'orderService', 'translateService', OrderDetailCtrl]);

    function OrderDetailCtrl($stateParams, orderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.orderId = $stateParams.id;
        vm.order = {};
        vm.orderStatus = [];
        vm.orderHistories = [];

        vm.changeOrderStatus = function () {
            orderService.changeOrderStatus(vm.order.id, { statusId : vm.order.orderStatus, note : vm.orderStatusNote })
                .then(function () {
                    vm.order.orderStatusString = vm.orderStatus.find(function (item) { return item.id === vm.order.orderStatus; }).name;
                    toastr.success('The order now is ' + vm.order.orderStatusString);
                    vm.orderStatusNote = '';
                    getOrderHistory();
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

        function getOrderHistory() {
            orderService.getOrderHistory(vm.orderId).then(function (result) {
                vm.orderHistories = result.data;
            });
        }

        function init() {
            getOrderStatus();
            getOrder();
            getOrderHistory();
        }

        init();
    }
})();
