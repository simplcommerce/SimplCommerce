/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.productAttributeGroup', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('product-attribute-group', {
                    url: '/product-attribute-group',
                    templateUrl: 'admin/app/product-attribute-group/product-attribute-group-list.html',
                    controller: 'ProductAttributeGroupListCtrl as vm'
                })
                .state('product-attribute-group-create', {
                    url: '/product-attribute-group/create',
                    templateUrl: 'admin/app/product-attribute-group/product-attribute-group-form.html',
                    controller: 'ProductAttributeGroupFormCtrl as vm'
                })
                .state('product-attribute-group-edit', {
                    url: '/product-attribute-group/edit/:id',
                    templateUrl: 'admin/app/product-attribute-group/product-attribute-group-form.html',
                    controller: 'ProductAttributeGroupFormCtrl as vm'
                });
        }]);
})();