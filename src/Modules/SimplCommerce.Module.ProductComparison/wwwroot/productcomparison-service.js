(function () {
    angular
        .module('simpl.productComparison')
        .factory('productComparisonService', [
            '$http',
            function ($http) {
                function getProductComparisonItems() {
                    return $http.get('Cart/List');
                }

                function removeProductComparisonItem(itemId) {
                    return $http.post('Cart/Remove', itemId);
                }                

                return {
                    getProductComparisonItems: getProductComparisonItems,
                    removeProductComparisonItem: removeProductComparisonItem
                };
            }
        ]);
})();