/*global angular*/
(function () {
    angular
        .module('simplAdmin.pricing')
        .controller('CartRuleUsageListCtrl', CartRuleUsageListCtrl);

    /* @ngInject */
    function CartRuleUsageListCtrl(cartRuleUsageService, translateService) {
        var vm = this,
            tableStateRef;
        vm.cartRuleUsages = [];
        vm.translate = translateService;

        vm.getCartRuleUsages = function getUsers(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            cartRuleUsageService.getCartRuleUsages(tableState).then(function (result) {
                vm.cartRuleUsages = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();