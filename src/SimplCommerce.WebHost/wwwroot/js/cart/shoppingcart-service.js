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
                        cartItemId: itemId,
                        quantity: quantity
                    });
                }

                return {
                    getShoppingCartItems: getShoppingCartItems,
                    removeShoppingCartItem: removeShoppingCartItem,
                    updateQuantity: updateQuantity
                };
            }
        ]);
})();