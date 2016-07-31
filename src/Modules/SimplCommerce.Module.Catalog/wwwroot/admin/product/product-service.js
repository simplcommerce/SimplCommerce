/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productService', productService);

    /* @ngInject */
    function productService($http, Upload) {
        var service = {
            getProducts: getProducts,
            createProduct: createProduct,
            editProduct: editProduct,
            getProductAttrs: getProductAttrs,
            getProductTemplates: getProductTemplates,
            getProductTemplate: getProductTemplate,
            getProductOptions: getProductOptions,
            getProduct: getProduct,
            changeStatus: changeStatus,
            deleteProduct: deleteProduct
        };
        return service;

        function getProduct(id) {
            return $http.get('api/products/' + id);
        }

        function getProductAttrs() {
            return $http.get('api/product-attributes');
        }

        function getProductTemplates() {
            return $http.get('api/product-templates');
        }

        function getProductTemplate(id) {
            return $http.get('api/product-templates/' + id);
        }

        function getProductOptions() {
            return $http.get('api/product-options');
        }

        function getProducts(params) {
            return $http.post('api/products/grid', params);
        }

        function createProduct(product, thumbnailImage, productImages) {
            return Upload.upload({
                url: 'api/products',
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages
                }
            });
        }

        function editProduct(product, thumbnailImage, productImages) {
            return Upload.upload({
                url: 'api/products/' + product.id,
                method: 'PUT',
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages
                }
            });
        }

        function changeStatus(product) {
            return $http.post('api/products/change-status/' + product.id, null);
        }

        function deleteProduct(product) {
            return $http.delete('api/products/' + product.id, null);
        }
    }
})();