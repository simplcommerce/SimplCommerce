/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('OrderCreateCtrl', OrderCreateCtrl);

    /* @ngInject */
    function OrderCreateCtrl($state, $q, orderService, translateService, userService, productService) {
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
        vm.selectedShippingAddressId = 0;
        vm.customerAddress = { addresses: [] };

        vm.countries = [];
        vm.countryStatesOrProvinces = { statesOrProvinces : [] };
        vm.districts = [];
        vm.shippingOptions = [];

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
            $q.all([
                orderService.getCart(customer.id),
                orderService.getCustomerAddresses(customer.id)
            ]).then(function (result) {
                vm.cart = result[0].data;

                vm.customerAddress = result[1].data;
                if (vm.customerAddress.defaultShippingAddressId) {
                    vm.selectedShippingAddressId = vm.customerAddress.defaultShippingAddressId.toString();
                }

                vm.updateTaxAndShippingPrice();
            });
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

        vm.updateCartItemQuantity = function (item) {
            orderService.updateCartItem(item).then(function (result) {
                vm.getCart();
            });
        };

        vm.removeCartItem = function (item) {
            orderService.removeCartItem(item.id).then(function (result) {
                vm.getCart();
            });
        };

        vm.getCart = function () {
            orderService.getCart(vm.customer.id).then(function (result) {
                vm.cart = result.data;
                vm.updateTaxAndShippingPrice();
            });
        };

        function getCountries () {
            orderService.getCountries().then(function (result) {
                vm.countries = result.data;
            });
        }

        function getStatesOrProvinces (countryId) {
            orderService.getStatesOrProvinces(countryId).then(function (result) {
                vm.countryStatesOrProvinces = result.data;
            });
        }

        function getDistricts (stateOrProvinceId) {
            orderService.getDistricts(stateOrProvinceId).then(function (result) {
                vm.districts = result.data;
            });
        }

        vm.onStateOrProvinceSelected = function (stateOrProvinceId) {
            getDistricts(stateOrProvinceId);
            vm.updateTaxAndShippingPrice();
        };

        vm.onCountrySelected = function (countryId) {
            vm.countryStatesOrProvinces = { statesOrProvinces : [] };
            vm.districts = [];
            vm.shippingOptions = [];
            getStatesOrProvinces(countryId);
        };

        vm.updateTaxAndShippingPrice = function updateTaxAndShippingPrice() {
            if (vm.selectedShippingAddressId === '0' && !vm.shippingAddress.stateOrProvinceId) {
                vm.shippingOptions = [];
                return;
            }
            if (!vm.cart.id) {
                return;
            }
            orderService.updateTaxAndShippingPrice(
                vm.cart.id,
                {
                    existingShippingAddressId: vm.selectedShippingAddressId,
                    newShippingAddress: vm.shippingAddress,
                    selectedShippingMethodName: vm.selectedShippingOption
                }
            ).then(function (result) {
                vm.shippingOptions = result.data.shippingPrices;
                vm.cart = result.data.cart;
                if (vm.shippingOptions.length === 0) {
                    toastr.error("Sorry, this items can't be shipped to your selected address");
                } else {
                    vm.selectedShippingOption = result.data.selectedShippingMethodName;
                }
            });
        };

        vm.createOrder = function createOrder() {
            orderService.createOrder(
                vm.cart.id,
                {
                    shippingMethod: vm.selectedShippingOption,
                    shippingAddressId: vm.selectedShippingAddressId,
                    newAddressForm: vm.shippingAddress,
                    orderNote: vm.cart.orderNote
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
