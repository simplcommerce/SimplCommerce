/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .controller('OrderListCtrl', OrderListCtrl);

    /* @ngInject */
    function OrderListCtrl(orderService) {
        var vm = this;
        vm.orders = [];

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