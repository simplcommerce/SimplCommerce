/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.resource', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('resource', {
                    url: '/resource',
                    templateUrl: 'admin/app/resource/resource-list.html',
                    controller: 'ResourceListCtrl as vm'
                })
                .state('resource-edit', {
                    url: '/resource/edit/:id',
                    templateUrl: 'admin/app/resource/resource-form.html',
                    controller: 'ResourceFormCtrl as vm'
                });
        }]);
})();