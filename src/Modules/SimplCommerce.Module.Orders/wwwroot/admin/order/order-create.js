/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('OrderCreateCtrl', OrderCreateCtrl);

    /* @ngInject */
    function OrderCreateCtrl($state, orderService, translateService, userService, productService) {
        var vm = this;
        vm.translate = translateService;
        vm.customer = { fullName: '' };
        vm.cart = {};
        vm.addingProduct = {};
        vm.searchedCustomers = [];
        vm.searchedProducts = [];
        vm.isSearchingCustomers = false;
        vm.isSearchingProducts = false;

        vm.searchCustomers = function () {
            if (vm.customer.fullName.length > 1) {
                vm.isSearchingCustomers = true;
                userService.quickSearchUsers(vm.customer.fullName).then(function (result) {
                    vm.searchedCustomers = result.data;
                });
            }
        };

        vm.searchProducts = function () {
            if (vm.addingProduct.name.length > 1) {
                vm.isSearchingProducts = true;
                productService.quickSearchProducts(vm.addingProduct.name).then(function (result) {
                    vm.searchedProducts = result.data;
                });
            }
        };

        vm.selectCustomer = function (customer) {
            vm.customer = customer;
            vm.isSearchingCustomers = false;
            vm.getCart();
        };

        vm.selectProduct = function (product) {
            vm.addingProduct = product;
            vm.isSearchingProducts = false;
        };

        vm.addProduct = function () {
            if (!vm.addingProduct.id) {
                toastr.error("Product not found");
                return;
            }

            if (!vm.customer.id) {
                toastr.error("Please select customer first");
                return;
            }

            var cartItem = {
                productId: vm.addingProduct.id,
                quantity: 1
            };

            orderService.addCartItem(vm.customer.id, cartItem).then(function () {
                vm.getCart();
                vm.addingProduct = {};
            });
        };

        vm.getCart = function () {
            orderService.getCart(vm.customer.id).then(function (result) {
                vm.cart = result.data;
            });
        };

        function init() {
        }

        init();
    }
})();
