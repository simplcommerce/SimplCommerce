/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.productTemplate', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('product-template', {
                    url: '/product-template',
                    templateUrl: 'admin/app/product-template/product-template-list.html',
                    controller: 'ProductTemplateListCtrl as vm'
                })
                .state('product-template-create', {
                    url: '/product-template/create',
                    templateUrl: 'admin/app/product-template/product-template-form.html',
                    controller: 'ProductTemplateFormCtrl as vm'
                })
                .state('product-template-edit', {
                    url: '/product-template/edit/:id',
                    templateUrl: 'admin/app/product-template/product-template-form.html',
                    controller: 'ProductTemplateFormCtrl as vm'
                });
        }]);
})();