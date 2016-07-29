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
                });
        }]);
})();