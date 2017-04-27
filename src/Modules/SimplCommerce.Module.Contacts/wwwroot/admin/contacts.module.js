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
                });
                //.state('contact-items', {
                //    url: '/contact-items',
                //    templateUrl: 'modules/contact/admin/contact-items/contact-item-list.html',
                //    controller: 'NewsItemListCtrl as vm'
                //})
                //.state('contact-items-create', {
                //    url: '/contact-items/create',
                //    templateUrl: 'modules/news/admin/news-items/news-item-form.html',
                //    controller: 'NewsItemFormCtrl as vm'
                //})
                //.state('news-items-edit', {
                //    url: '/news-items/edit/:id',
                //    templateUrl: 'modules/news/admin/news-items/news-item-form.html',
                //    controller: 'NewsItemFormCtrl as vm'
                //});
        }]);
})();