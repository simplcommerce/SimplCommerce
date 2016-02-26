(function () {
    'use strict';

    angular.module('hvAdmin.category', [])
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
                });
        }]);
})();