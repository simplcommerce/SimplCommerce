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
        vm.shippingAddress = {};

        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.districts = [];
        vm.shippingOptions = []

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

        getCountries = function () {
            orderService.getCountries().then(function (result) {
                vm.countries = result.data;
            });
        };

        getStatesOrProvinces = function (countryId) {
            orderService.getStatesOrProvinces(countryId).then(function (result) {
                vm.statesOrProvinces = result.data;
            });
        };

        getDistricts = function (stateOrProvinceId) {
            orderService.getDistricts(stateOrProvinceId).then(function (result) {
                vm.districts = result.data;
            });
        };

        vm.onStateOrProvinceSelected = function (stateOrProvinceId) {
            getDistricts(stateOrProvinceId);
            updateTaxAndShippingPrice();
        };

        vm.onCountrySelected = function (countryId) {
            vm.statesOrProvinces = [];
            vm.districts = [];
            getStatesOrProvinces(countryId);
        };

        function updateTaxAndShippingPrice() {
            orderService.updateTaxAndShippingPrice(
                vm.cart.id,
                {
                    newShippingAddress: vm.shippingAddress
                }
            ).then(function (result) {
                vm.shippingOptions = result.data.shippingPrices;
                if (vm.shippingOptions.length === 0) {
                    toastr.error("Sorry, this items can't be shipped to your selected address");
                } else {
                    vm.selectedShippingOption = vm.shippingOptions[0].name;
                }
            });
        }

        vm.createOrder = function createOrder() {
            orderService.createOrder(
                vm.cart.id,
                {
                    shippingMethod: vm.selectedShippingOption,
                    newAddressForm : vm.shippingAddress
                }
            ).then(function (result) {
                toastr.success("Order created");
                $state.go('order-detail', { id: result.data.id });
            }).catch(function (response) {
                toastr.error(response.data);
            });
        };

        function init() {
            getCountries();
        }

        init();
    }
})();
