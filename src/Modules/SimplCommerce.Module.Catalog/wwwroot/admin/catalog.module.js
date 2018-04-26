/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.catalog', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('brand', {
                    url: '/brand',
                    templateUrl: 'modules/catalog/admin/brand/brand-list.html',
                    controller: 'BrandListCtrl as vm'
                })
                .state('brand-create', {
                    url: '/brand/create',
                    templateUrl: 'modules/catalog/admin/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                })
                .state('brand-edit', {
                    url: '/brand/edit/:id',
                    templateUrl: 'modules/catalog/admin/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                })
                .state('category', {
                    url: '/category',
                    templateUrl: 'modules/catalog/admin/category/category-list.html',
                    controller: 'CategoryListCtrl as vm'
                })
               .state('category-create', {
                   url: '/category/create',
                   templateUrl: 'modules/catalog/admin/category/category-form.html',
                   controller: 'CategoryFormCtrl as vm'
               })
               .state('category-edit', {
                   url: '/category/edit/:id',
                   templateUrl: 'modules/catalog/admin/category/category-form.html',
                   controller: 'CategoryFormCtrl as vm'
               })
                .state('product-option', {
                    url: '/product-option',
                    templateUrl: 'modules/catalog/admin/product-option/product-option-list.html',
                    controller: 'ProductOptionListCtrl as vm'
                })
                .state('product-option-create', {
                    url: '/product-option/create',
                    templateUrl: 'modules/catalog/admin/product-option/product-option-form.html',
                    controller: 'ProductOptionFormCtrl as vm'
                })
                .state('product-option-edit', {
                    url: '/product-option/edit/:id',
                    templateUrl: 'modules/catalog/admin/product-option/product-option-form.html',
                    controller: 'ProductOptionFormCtrl as vm'
                })
                .state('product-attribute-group', {
                    url: '/product-attribute-group',
                    templateUrl: 'modules/catalog/admin/product-attribute-group/product-attribute-group-list.html',
                    controller: 'ProductAttributeGroupListCtrl as vm'
                })
                .state('product-attribute-group-create', {
                    url: '/product-attribute-group/create',
                    templateUrl: 'modules/catalog/admin/product-attribute-group/product-attribute-group-form.html',
                    controller: 'ProductAttributeGroupFormCtrl as vm'
                })
                .state('product-attribute-group-edit', {
                    url: '/product-attribute-group/edit/:id',
                    templateUrl: 'modules/catalog/admin/product-attribute-group/product-attribute-group-form.html',
                    controller: 'ProductAttributeGroupFormCtrl as vm'
                })
                .state('product-attribute', {
                    url: '/product-attribute',
                    templateUrl: 'modules/catalog/admin/product-attribute/product-attribute-list.html',
                    controller: 'ProductAttributeListCtrl as vm'
                })
                .state('product-attribute-create', {
                    url: '/product-attribute/create',
                    templateUrl: 'modules/catalog/admin/product-attribute/product-attribute-form.html',
                    controller: 'ProductAttributeFormCtrl as vm'
                })
                .state('product-attribute-edit', {
                    url: '/product-attribute/edit/:id',
                    templateUrl: 'modules/catalog/admin/product-attribute/product-attribute-form.html',
                    controller: 'ProductAttributeFormCtrl as vm'
                })
                .state('product-template', {
                    url: '/product-template',
                    templateUrl: 'modules/catalog/admin/product-template/product-template-list.html',
                    controller: 'ProductTemplateListCtrl as vm'
                })
                .state('product-template-create', {
                    url: '/product-template/create',
                    templateUrl: 'modules/catalog/admin/product-template/product-template-form.html',
                    controller: 'ProductTemplateFormCtrl as vm'
                })
                .state('product-template-edit', {
                    url: '/product-template/edit/:id',
                    templateUrl: 'modules/catalog/admin/product-template/product-template-form.html',
                    controller: 'ProductTemplateFormCtrl as vm'
                })
                .state('product', {
                    url: '/product',
                    templateUrl: 'modules/catalog/admin/product/product-list.html',
                    controller: 'ProductListCtrl as vm'
                })
                .state('product-create', {
                    url: '/product-create',
                    templateUrl: 'modules/catalog/admin/product/product-form.html',
                    controller: 'ProductFormCtrl as vm'
                })
                .state('product-edit', {
                    url: '/product/edit/:id',
                    templateUrl: 'modules/catalog/admin/product/product-form.html',
                    controller: 'ProductFormCtrl as vm'
                })
                .state('widget-product-create', {
                    url: '/widget-product/create',
                    templateUrl: 'modules/catalog/admin/product-widget/product-widget-form.html',
                    controller: 'ProductWidgetFormCtrl as vm'
                })
                .state('widget-product-edit', {
                    url: '/widget-product/edit/:id',
                    templateUrl: 'modules/catalog/admin/product-widget/product-widget-form.html',
                    controller: 'ProductWidgetFormCtrl as vm'
                })
                .state('widget-category-create', {
                    url: '/widget-category/create',
                    templateUrl: 'modules/catalog/admin/category-widget/category-widget-form.html',
                    controller: 'CategoryWidgetFormCtrl as vm'
                })
                .state('widget-category-edit', {
                    url: '/widget-category/edit/:id',
                    templateUrl: 'modules/catalog/admin/category-widget/category-widget-form.html',
                    controller: 'CategoryWidgetFormCtrl as vm'
                })
                .state('widget-simple-product-create', {
                    url: '/widget-simple-product/create',
                    templateUrl: 'modules/catalog/admin/simple-product-widget/simple-product-widget-form.html',
                    controller: 'SimpleProductWidgetFormCtrl as vm'
                })
                .state('widget-simple-product-edit', {
                    url: '/widget-simple-product/edit/:id',
                    templateUrl: 'modules/catalog/admin/simple-product-widget/simple-product-widget-form.html',
                    controller: 'SimpleProductWidgetFormCtrl as vm'
                });
        }]);
})();