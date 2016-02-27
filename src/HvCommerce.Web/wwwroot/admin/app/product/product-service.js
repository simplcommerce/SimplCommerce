(function() {
    angular
        .module('hvAdmin.product')
        .factory('productService', [
            '$http', 'Upload',
            function($http, upload) {
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

                return {
                    getProducts: getProducts,
                    createProduct: createProduct
                };
            }
        ]);
})();