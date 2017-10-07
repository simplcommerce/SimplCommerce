/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .controller('OrderListCtrl', OrderListCtrl);

    /* @ngInject */
    function OrderListCtrl(orderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.orders = [];

        orderService.getOrderStatus().then(function (result) {
            vm.orderStatus = result.data;
        });

        vm.getOrders = function getOrders(tableState) {
            vm.isLoading = true;
            orderService.getOrdersForGrid(tableState).then(function (result) {
                vm.orders = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();