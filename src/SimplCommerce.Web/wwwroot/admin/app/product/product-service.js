/*global angular*/
(function () {
    angular
        .module('shopAdmin.product')
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
            getProduct: getProduct
        };
        return service;

        function getProduct(id) {
            return $http.get('Admin/Product/Get/' + id);
        }

        function getProductAttrs() {
            return $http.get('Admin/ProductAttribute/List');
        }

        function getProductTemplates() {
            return $http.get('Admin/ProductTemplate/List');
        }

        function getProductTemplate(id) {
            return $http.get('Admin/ProductTemplate/Get/' + id);
        }

        function getProductOptions() {
            return $http.get('Admin/ProductOption/List');
        }

        function getProducts(params) {
            return $http.post('Admin/Product/List', params);
        }

        function createProduct(product, thumbnailImage, productImages) {
            return Upload.upload({
                url: 'Admin/Product/Create',
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages
                }
            });
        }

        function editProduct(product, thumbnailImage, productImages) {
            return Upload.upload({
                url: 'Admin/Product/Edit/' + product.id,
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages
                }
            });
        }
    }
})();