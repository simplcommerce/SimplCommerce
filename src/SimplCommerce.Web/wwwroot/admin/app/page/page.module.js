/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.page', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('page', {
                    url: '/page',
                    templateUrl: 'admin/app/page/page-list.html',
                    controller: 'PageListCtrl as vm'
                })
                .state('page-create', {
                    url: '/page/create',
                    templateUrl: 'admin/app/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-edit', {
                    url: '/page/edit/:id',
                    templateUrl: 'admin/app/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                });
        }]);
})();