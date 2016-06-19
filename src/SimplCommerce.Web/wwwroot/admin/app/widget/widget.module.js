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
                    templateUrl: 'admin/app/widget/carousel-form.html',
                    controller: 'CarouselFormCtrl as vm'
                })
                .state('widget-carousel-edit', {
                    url: '/widget-carousel/edit/:id',
                    templateUrl: 'admin/app/widget/carousel-form.html',
                    controller: 'CarouselFormCtrl as vm'
                });
        }]);
})();