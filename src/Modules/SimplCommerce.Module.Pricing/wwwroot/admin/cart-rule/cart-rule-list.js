/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.pricing')
        .controller('CartRuleListCtrl', CartRuleListCtrl);

    /* @ngInject */
    function CartRuleListCtrl(cartRuleService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.cartRules = [];

        vm.getCartRules = function getCartRules(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            cartRuleService.getCartRules(tableState).then(function (result) {
                vm.cartRules = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.deleteCartRule = function deleteCartRule(cartRule) {
            bootbox.confirm('Are you sure you want to delete this rule: ' + cartRule.name, function (result) {
                if (result) {
                    cartRuleService.deleteCartRule(cartRule)
                       .then(function (result) {
                           vm.getCartRules(tableStateRef);
                           toastr.success(cartRule.name + ' has been deleted');
                       })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                       });
                }
            });
        };
    }
})();