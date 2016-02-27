(function() {
    angular
        .module('hvAdmin.product')
        .factory('productService', [
            '$http',
            function($http) {
                function getProducts(params) {
                    return $http.post('Admin/Product/List', params);
                }

                function createProduct(product) {
                    return $http.post('Admin/Product/Create', product);
                }

                return {
                    getProducts: getProducts,
                    createProduct: createProduct
                };
            }
        ]);
})();