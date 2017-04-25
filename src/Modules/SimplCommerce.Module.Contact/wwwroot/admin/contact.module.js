/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.contact', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('contact-categories', {
                    url: '/contact-categories',
                    templateUrl: 'modules/contact/admin/contact-categories/contact-category-list.html',
                    controller: 'ContactCategoryListCtrl as vm'
                })
                .state('contact-categories-create', {
                    url: '/contact-categories/create',
                    templateUrl: 'modules/contact/admin/contact-categories/contact-category-form.html',
                    controller: 'ContactCategoryFormCtrl as vm'
                })
                .state('contact-categories-edit', {
                    url: '/contact-categories/edit/:id',
                    templateUrl: 'modules/contact/admin/contact-categories/contact-category-form.html',
                    controller: 'ContactCategoryFormCtrl as vm'
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