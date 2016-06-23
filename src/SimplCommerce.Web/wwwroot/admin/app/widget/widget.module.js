/*global angular*/
(function () {
    'use strict';

    angular.module('shopAdmin.widget', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('widget', {
                    url: '/widget',
                    templateUrl: 'admin/app/widget/widget-instance-list.html',
                    controller: 'WidgetInstanceListCtrl as vm'
                })
                .state('widget-carousel-create', {
                    url: '/widget-carousel/create',
                    templateUrl: 'admin/app/widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-carousel-edit', {
                    url: '/widget-carousel/edit/:id',
                    templateUrl: 'admin/app/widget/carousel-widget-form.html',
                    controller: 'CarouselWidgetFormCtrl as vm'
                })
                .state('widget-html-create', {
                    url: '/widget-html/create',
                    templateUrl: 'admin/app/widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                })
                .state('widget-html-edit', {
                    url: '/widget-html/edit/:id',
                    templateUrl: 'admin/app/widget/html-widget-form.html',
                    controller: 'HtmlWidgetFormCtrl as vm'
                });
        }]);
})();