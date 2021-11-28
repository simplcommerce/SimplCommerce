/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.reviews', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('reviews', {
                        url: '/reviews',
                        templateUrl: '_content/SimplCommerce.Module.Reviews/admin/review/review-list.html',
                        controller: 'ReviewListCtrl as vm'
                    })
                    .state('review-replies', {
                        url: '/review-replies',
                        templateUrl: '_content/SimplCommerce.Module.Reviews/admin/review/review-reply-list.html',
                        controller: 'ReviewReplyListCtrl as vm'
                    })
                ;
            }
        ]);
})();
