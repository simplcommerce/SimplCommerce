/*global angular*/
(function () {
    'use strict';

    angular
        .module('shopAdmin.product', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('product', {
                        url: '/product',
                        templateUrl: 'admin/app/product/product-list.html',
                        controller: 'ProductListCtrl as vm'
                    })
                    .state('product-create', {
                        url: '/product-create',
                        templateUrl: 'admin/app/product/product-form.html',
                        controller: 'ProductFormCtrl as vm'
                    })
                    .state('product-edit', {
                        url: '/product/edit/:id',
                        templateUrl: 'admin/app/product/product-form.html',
                        controller: 'ProductFormCtrl as vm'
                    })
                ;
            }
        ]);
})();