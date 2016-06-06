/*global angular*/
(function () {
    angular
        .module('shopAdmin.order')
        .controller('OrderListCtrl', OrderListCtrl);

    /* @ngInject */
    function OrderListCtrl(orderService) {
        var vm = this;
        vm.orders = [];

        vm.getOrders = function getOrders(tableState) {
            vm.isLoading = true;
            orderService.getOrders(tableState).then(function (result) {
                vm.orders = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();