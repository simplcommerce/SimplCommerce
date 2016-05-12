/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.productOption', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('product-option', {
                    url: '/product-option',
                    templateUrl: 'admin/app/product-option/product-option-list.html',
                    controller: 'ProductOptionListCtrl as vm'
                })
                .state('product-option-create', {
                    url: '/product-option/create',
                    templateUrl: 'admin/app/product-option/product-option-form.html',
                    controller: 'ProductOptionFormCtrl as vm'
                })
                .state('product-option-edit', {
                    url: '/product-option/edit/:id',
                    templateUrl: 'admin/app/product-option/product-option-form.html',
                    controller: 'ProductOptionFormCtrl as vm'
                });
        }]);
})();