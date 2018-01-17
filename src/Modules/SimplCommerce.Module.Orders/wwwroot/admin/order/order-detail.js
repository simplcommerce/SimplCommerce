/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .controller('OrderDetailCtrl', OrderDetailCtrl);

    /* @ngInject */
    function OrderDetailCtrl($state, $stateParams, orderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.orderId = $stateParams.id;
        vm.order = {};
        vm.orderStatus = [];

        vm.changeOrderStatus = function () {
            orderService.changeOrderStatus(vm.order.id, { statusId : vm.order.orderStatus, note : vm.orderStatusNote })
                .then(function () {
                    vm.order.orderStatusString = vm.orderStatus.find(function (item) { return item.id === vm.order.orderStatus; }).name;
                    toastr.success('The order now is ' + vm.order.orderStatusString);
                    vm.orderStatusNote = '';
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