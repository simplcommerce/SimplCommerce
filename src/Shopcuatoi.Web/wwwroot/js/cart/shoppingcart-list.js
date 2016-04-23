(function () {
    angular
        .module('hv.shoppingCart', [])
        .controller('shoppingCartListCtrl', [
            '$scope',
            'shoppingCartService',
            function ($scope, shoppingCartService) {
                var vm = this;
                vm.shoppingCartItems = [];
                vm.totalPrice = 0;
                getShoppingCartItems();

                function getShoppingCartItems() {
                    shoppingCartService.getShoppingCartItems().then(function (result) {
                        vm.shoppingCartItems = result.data;
                        $.each(result.data, function () {
                            vm.totalPrice += this.totalPrice;
                        });
                    });
                };

                vm.removeShoppingCartItem = function removeShoppingCartItem(item) {
                    var index = vm.shoppingCartItems.indexOf(item);
                    vm.shoppingCartItems.splice(index, 1);

                    vm.totalPrice = shoppingCartService.resetTotalPrice(vm.shoppingCartItems);
                    shoppingCartService.removeShoppingCartItem(item.id);
                }

                vm.increaseQuantity = function increaseQuantity(item) {
                    item.quantity += 1;
                    vm.totalPrice = shoppingCartService.resetTotalPrice(vm.shoppingCartItems);
                    shoppingCartService.updateQuantity(item.id, item.quantity);
                }

                vm.decreaseQuantity = function decreaseQuantity(item) {
                    item.quantity -= 1;
                    vm.totalPrice = shoppingCartService.resetTotalPrice(vm.shoppingCartItems);
                    shoppingCartService.updateQuantity(item.id, item.quantity);
                }
            }
        ]);
})();