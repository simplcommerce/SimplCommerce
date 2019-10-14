/*global angular*/
(function () {
    angular
        .module('simplAdmin.pricing')
        .controller('CartRuleUsageListCtrl', ['cartRuleUsageService', 'translateService', CartRuleUsageListCtrl]);

    function CartRuleUsageListCtrl(cartRuleUsageService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.cartRuleUsages = [];
        vm.translate = translateService;

        vm.getCartRuleUsages = function getUsers(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            cartRuleUsageService.getCartRuleUsages(tableState).then(function (result) {
                vm.cartRuleUsages = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };
    }
})();
