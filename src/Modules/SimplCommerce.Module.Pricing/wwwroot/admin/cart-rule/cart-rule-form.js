/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.pricing')
        .controller('CartRuleFormCtrl', ['$state', '$stateParams', 'cartRuleService', 'translateService', CartRuleFormCtrl]);

    function CartRuleFormCtrl($state, $stateParams, cartRuleService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.cartRule = { isCouponRequired: true };
        vm.cartRule.products = [];
        vm.cartRuleId = $stateParams.id;
        vm.isEditMode = vm.cartRuleId > 0;

        vm.datePickerStartOn = {};
        vm.datePickerEndOn = {};

        vm.openCalendar = function (e, picker) {
            vm[picker].open = true;
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = cartRuleService.editCartRule(vm.cartRule);
            } else {
                promise = cartRuleService.createCartRule(vm.cartRule);
            }

            promise
                .then(function (result) {
                    $state.go('cart-rules');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add cartRule.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                cartRuleService.getCartRule(vm.cartRuleId).then(function (result) {
                    vm.cartRule = result.data;
                });
            }
        }

        init();
    }
})(jQuery);
