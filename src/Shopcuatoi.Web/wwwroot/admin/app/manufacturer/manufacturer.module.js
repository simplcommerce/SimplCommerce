/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.manufacturer', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('manufacturer', {
                    url: '/manufacturer',
                    templateUrl: 'admin/app/manufacturer/manufacturer-list.html',
                    controller: 'ManufacturerListCtrl as vm'
                })
                .state('manufacturer-create', {
                    url: '/manufacturer/create',
                    templateUrl: 'admin/app/manufacturer/manufacturer-form.html',
                    controller: 'ManufacturerCreateCtrl as vm'
                })
                .state('manufacturer-edit', {
                    url: '/manufacturer/edit/:id',
                    templateUrl: 'admin/app/manufacturer/manufacturer-form.html',
                    controller: 'ManufacturerEditCtrl as vm'
                });
        }]);
})();