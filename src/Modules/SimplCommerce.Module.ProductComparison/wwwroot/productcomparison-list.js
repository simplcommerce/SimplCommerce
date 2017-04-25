(function () {
    angular
        .module('simpl.productComparison', [])
        .controller('productComparisonListCtrl', [
            '$scope',
            'productComparisonService',
            function ($scope, productComparisonService) {
                var vm = this;
                vm.cartViewModel = {};

                function cartDataCallback(result) {
                    vm.cartViewModel = result.data;
                    $('.cart-badge .badge').text(vm.cartViewModel.cartItems.length);
                }

                function getProductComparisonItems() {
                    productComparisonService.getProductComparisonItems().then(cartDataCallback);
                };

                vm.removeShoppingCartItem = function removeShoppingCartItem(item) {
                    productComparisonService.removeShoppingCartItem(item.id).then(cartDataCallback);
                }
                
                getProductComparisonItems();
            }
        ]);
})();