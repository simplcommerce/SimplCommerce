(function() {
    angular
        .module('hvAdmin.product')
        .factory('productService', [
            '$http',
            function($http) {
                function getProducts(params) {
                    return $http.post('Admin/Product/List', params);
                }

                return {
                    getProducts: getProducts
                };
            }
        ]);
})();