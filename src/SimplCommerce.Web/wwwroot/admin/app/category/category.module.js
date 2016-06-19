/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.category', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('category', {
                    url: '/category',
                    templateUrl: 'admin/app/category/category-list.html',
                    controller: 'CategoryListCtrl as vm'
                })
                .state('category-create', {
                    url: '/category/create',
                    templateUrl: 'admin/app/category/category-form.html',
                    controller: 'CategoryFormCtrl as vm'
                })
                .state('category-edit', {
                    url: '/category/edit/:id',
                    templateUrl: 'admin/app/category/category-form.html',
                    controller: 'CategoryFormCtrl as vm'
                });
        }]);
})();