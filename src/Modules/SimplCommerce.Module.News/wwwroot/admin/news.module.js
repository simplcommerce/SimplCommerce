/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.news', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('news-categories', {
                    url: '/news-categories',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-categories/news-category-list.html',
                    controller: 'NewsCategoryListCtrl as vm'
                })
                .state('news-categories-create', {
                    url: '/news-categories/create',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-categories/news-category-form.html',
                    controller: 'NewsCategoryFormCtrl as vm'
                })
                .state('news-categories-edit', {
                    url: '/news-categories/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-categories/news-category-form.html',
                    controller: 'NewsCategoryFormCtrl as vm'
                })
                .state('news-items', {
                    url: '/news-items',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-items/news-item-list.html',
                    controller: 'NewsItemListCtrl as vm'
                })
                .state('news-items-create', {
                    url: '/news-items/create',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-items/news-item-form.html',
                    controller: 'NewsItemFormCtrl as vm'
                })
                .state('news-items-edit', {
                    url: '/news-items/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.News/admin/news-items/news-item-form.html',
                    controller: 'NewsItemFormCtrl as vm'
                });
        }]);
})();
