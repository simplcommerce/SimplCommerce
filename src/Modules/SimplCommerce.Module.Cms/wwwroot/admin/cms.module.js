/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.cms', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('page', {
                    url: '/page',
                    templateUrl: 'modules/cms/admin/page/page-list.html',
                    controller: 'PageListCtrl as vm'
                })
                .state('page-create', {
                    url: '/page/create',
                    templateUrl: 'modules/cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-edit', {
                    url: '/page/edit/:id',
                    templateUrl: 'modules/cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('menus', {
                    url: '/menus/',
                    templateUrl: 'modules/cms/admin/menu/menu-list.html',
                    controller: 'MenuListCtrl as vm'
                })
                .state('menus-create', {
                    url: '/menus-create/',
                    templateUrl: 'modules/cms/admin/menu/menu-form-create.html',
                    controller: 'MenuFormCreateCtrl as vm'
                })
                .state('menus-edit', {
                    url: '/menus-edit/:id',
                    templateUrl: 'modules/cms/admin/menu/menu-form.html',
                    controller: 'MenuFormCtrl as vm'
                })
                .state('widget-carousel-create', {
                    url: '/widget-carousel/create',
                    templateUrl: 'modules/cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-carousel-edit', {
                    url: '/widget-carousel/edit/:id',
                    templateUrl: 'modules/cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-html-create', {
                    url: '/widget-html/create',
                    templateUrl: 'modules/cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-html-edit', {
                    url: '/widget-html/edit/:id',
                    templateUrl: 'modules/cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-spacebar-create', {
                    url: '/widget-spacebar/create',
                    templateUrl: 'modules/cms/admin/spacebar-widget/spacebar-widget-form.html',
                    controller: 'SpaceBarWidgetFormCtrl as vm'
                })
                .state('widget-spacebar-edit', {
                    url: '/widget-spacebar/edit/:id',
                    templateUrl: 'modules/cms/admin/spacebar-widget/spacebar-widget-form.html',
                    controller: 'SpaceBarWidgetFormCtrl as vm'
                })
                .state('widget-homeproduct-create', {
                    url: '/widget-homeproduct/create',
                    templateUrl: 'modules/cms/admin/homeproducts-widget/homeproduct-widget-form.html',
                    controller: 'HomeProductWidgetFormCtrl as vm'
                })
                .state('widget-homeproduct-edit', {
                    url: '/widget-homeproduct/edit/:id',
                    templateUrl: 'modules/cms/admin/homeproducts-widget/homeproduct-widget-form.html',
                    controller: 'HomeProductWidgetFormCtrl as vm'
                });
        }]);
})();