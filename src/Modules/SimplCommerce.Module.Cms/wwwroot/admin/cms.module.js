/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.cms', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('page', {
                    url: '/page',
                    templateUrl: 'cms/admin/page/page-list.html',
                    controller: 'PageListCtrl as vm'
                })
                .state('page-create', {
                    url: '/page/create',
                    templateUrl: 'cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-edit', {
                    url: '/page/edit/:id',
                    templateUrl: 'cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('widget-carousel-create', {
                    url: '/widget-carousel/create',
                    templateUrl: 'cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-carousel-edit', {
                    url: '/widget-carousel/edit/:id',
                    templateUrl: 'cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-html-create', {
                    url: '/widget-html/create',
                    templateUrl: 'cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-html-edit', {
                    url: '/widget-html/edit/:id',
                    templateUrl: 'cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                });
        }]);
})();