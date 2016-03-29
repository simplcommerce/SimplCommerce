(function () {
    'use strict';

    angular.module('shopAdmin.category', [])
        .config(['$stateProvider', function($stateProvider) {
            $stateProvider
                .state('category', {
                    url: '/category',
                    templateUrl: 'admin/app/category/category-list.html',
                    controller: 'categoryListCtrl as vm'
                })
                .state('category-create', {
                    url: '/category/create',
                    templateUrl: 'admin/app/category/category-form.html',
                    controller: 'categoryCreateCtrl as vm'
                })
                .state('category-edit', {
                    url: '/category/edit/:id',
                    templateUrl: 'admin/app/category/category-form.html',
                    controller: 'categoryEditCtrl as vm'
                });
        }]);
})();