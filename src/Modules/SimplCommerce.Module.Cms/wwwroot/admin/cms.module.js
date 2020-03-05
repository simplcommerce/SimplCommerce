/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.cms', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('page', {
                    url: '/page',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/page/page-list.html',
                    controller: 'PageListCtrl as vm'
                })
                .state('page-create', {
                    url: '/page/create',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-edit', {
                    url: '/page/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-translation', {
                    url: '/page-translation/:id/:culture',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/page/page-translation-form.html',
                    controller: 'PageTranslationFormCtrl as vm'
                })
                .state('menus', {
                    url: '/menus/',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/menu/menu-list.html',
                    controller: 'MenuListCtrl as vm'
                })
                .state('menus-create', {
                    url: '/menus-create/',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/menu/menu-form-create.html',
                    controller: 'MenuFormCreateCtrl as vm'
                })
                .state('menus-edit', {
                    url: '/menus-edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/menu/menu-form.html',
                    controller: 'MenuFormCtrl as vm'
                })
                .state('widget-carousel-create', {
                    url: '/widget-carousel/create',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-carousel-edit', {
                    url: '/widget-carousel/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/carousel-widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-html-create', {
                    url: '/widget-html/create',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-html-edit', {
                    url: '/widget-html/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/html-widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-spacebar-create', {
                    url: '/widget-spacebar/create',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/spacebar-widget/spacebar-widget-form.html',
                    controller: 'SpaceBarWidgetFormCtrl as vm'
                })
                .state('widget-spacebar-edit', {
                    url: '/widget-spacebar/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Cms/admin/spacebar-widget/spacebar-widget-form.html',
                    controller: 'SpaceBarWidgetFormCtrl as vm'
                });
        }]);
})();
