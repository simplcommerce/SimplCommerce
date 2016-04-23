(function() {
    angular
        .module('hv.shoppingCart')
        .factory('shoppingCartService', [
            '$http',
            function ($http) {
                function getShoppingCartItems() {
                    return $http.get('Cart/List');
                }
                
                function removeShoppingCartItem(itemId) {
                    return $http.post('Cart/Remove', itemId);
                }

                function updateQuantity(itemId, quantity) {
                    return $http.post('Cart/UpdateQuantity', {
                        ItemId: itemId,
                        Quantity: quantity
                    });
                }

                function resetTotalPrice(shoppingCartItems) {
                    var totalPrice = 0;
                    $.each(shoppingCartItems, function () {
                        this.totalPrice = this.quantity * this.price;
                        totalPrice += this.totalPrice;
                    });
                    return totalPrice;
                }

                return {
                    getShoppingCartItems: getShoppingCartItems,
                    removeShoppingCartItem: removeShoppingCartItem,
                    updateQuantity: updateQuantity,
                    resetTotalPrice: resetTotalPrice
                };
            }
        ]);
})();