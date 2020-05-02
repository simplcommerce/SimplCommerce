/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.contacts', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('contact-area', {
                    url: '/contact-area',
                    templateUrl: '_content/SimplCommerce.Module.Contacts/admin/contact-area/contact-area-list.html',
                    controller: 'ContactAreaListCtrl as vm'
                })
                .state('contact-area-create', {
                    url: '/contact-area/create',
                    templateUrl: '_content/SimplCommerce.Module.Contacts/admin/contact-area/contact-area-form.html',
                    controller: 'ContactAreaFormCtrl as vm'
                })
                .state('contact-area-edit', {
                    url: '/contact-area/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Contacts/admin/contact-area/contact-area-form.html',
                    controller: 'ContactAreaFormCtrl as vm'
                })
                .state('contact', {
                    url: '/contact',
                    templateUrl: '_content/SimplCommerce.Module.Contacts/admin/contacts/contact-list.html',
                    controller: 'ContactListCtrl as vm'
                })
                .state('contact-preview', {
                    url: '/contact/preview/:id',
                    templateUrl: '_content/SimplCommerce.Module.Contacts/admin/contacts/contact.html',
                    controller: 'ContactCtrl as vm'
                });
        }]);
})();
