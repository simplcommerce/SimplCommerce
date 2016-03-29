(function() {
    angular
        .module('shopAdmin.product')
        .factory('productService', [
            '$http', 'Upload',
            function ($http, upload) {
                var vm = {};
                vm.getProducts = getProducts;
                vm.createProduct = createProduct;
                vm.getProductAttrs = getProductAttrs;
                vm.getProduct = getProduct;
                return vm;

                function getProduct(id) {
                    return $http.get('Admin/Product/Get/' + id);
                }

                function getProductAttrs() {
                    return $http.get('Admin/ProductAttribute/List');
                }

                function getProducts(params) {
                    return $http.post('Admin/Product/List', params);
                }

                function createProduct(product, thumbnailImage, productImages) {
                    return upload.upload({
                        url: 'Admin/Product/Create',
                        data: {
                            product: product,
                            thumbnailImage: thumbnailImage,
                            productImages: productImages
                        }
                    });
                }
            }
        ]);
})();