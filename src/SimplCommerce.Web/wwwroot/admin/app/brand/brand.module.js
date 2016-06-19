/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.brand', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('brand', {
                    url: '/brand',
                    templateUrl: 'admin/app/brand/brand-list.html',
                    controller: 'BrandListCtrl as vm'
                })
                .state('brand-create', {
                    url: '/brand/create',
                    templateUrl: 'admin/app/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                })
                .state('brand-edit', {
                    url: '/brand/edit/:id',
                    templateUrl: 'admin/app/brand/brand-form.html',
                    controller: 'BrandFormCtrl as vm'
                });
        }]);
})();