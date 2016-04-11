/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.productAttribute', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('product-attribute', {
                    url: '/product-attribute',
                    templateUrl: 'admin/app/product-attribute/product-attribute-list.html',
                    controller: 'ProductAttributeListCtrl as vm'
                })
                .state('product-attribute-create', {
                    url: '/product-attribute/create',
                    templateUrl: 'admin/app/product-attribute/product-attribute-form.html',
                    controller: 'ProductAttributeFormCtrl as vm'
                })
                .state('product-attribute-edit', {
                    url: '/product-attribute/edit/:id',
                    templateUrl: 'admin/app/product-attribute/product-attribute-form.html',
                    controller: 'ProductAttributeFormCtrl as vm'
                });
        }]);
})();