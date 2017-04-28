/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.contacts', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('contact-area', {
                    url: '/contact-area',
                    templateUrl: 'modules/contacts/admin/contact-area/contact-area-list.html',
                    controller: 'ContactAreaListCtrl as vm'
                })
                .state('contact-area-create', {
                    url: '/contact-area/create',
                    templateUrl: 'modules/contacts/admin/contact-area/contact-area-form.html',
                    controller: 'ContactAreaFormCtrl as vm'
                })
                .state('contact-area-edit', {
                    url: '/contact-area/edit/:id',
                    templateUrl: 'modules/contacts/admin/contact-area/contact-area-form.html',
                    controller: 'ContactAreaFormCtrl as vm'
                })
                .state('contact', {
                    url: '/contact',
                    templateUrl: 'modules/contacts/admin/contacts/contact-list.html',
                    controller: 'ContactListCtrl as vm'
                })
                .state('contact-preview', {
                    url: '/contact/preview/:id',
                    templateUrl: 'modules/contacts/admin/contacts/contact.html',
                    controller: 'ContactCtrl as vm'
                });
        }]);
})();