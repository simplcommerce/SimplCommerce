/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.catalog', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('brand', {
                    url: '/brand',
                    templateUrl: 'catalog/admin/brand/brand-list.html',
                    controller: 'BrandListCtrl as vm'
                })
                .state('brand-create', {
                    url: '/brand/create',
                    templateUrl: 'catalog/admin/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                })
                .state('brand-edit', {
                    url: '/brand/edit/:id',
                    templateUrl: 'catalog/admin/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                })
                .state('category', {
                    url: '/category',
                    templateUrl: 'catalog/admin/category/category-list.html',
                    controller: 'CategoryListCtrl as vm'
                })
               .state('category-create', {
                   url: '/category/create',
                   templateUrl: 'catalog/admin/category/category-form.html',
                   controller: 'CategoryFormCtrl as vm'
               })
               .state('category-edit', {
                   url: '/category/edit/:id',
                   templateUrl: 'catalog/admin/category/category-form.html',
                   controller: 'CategoryFormCtrl as vm'
               });
        }]);
})();