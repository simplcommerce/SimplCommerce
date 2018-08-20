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
                        templateUrl: 'modules/reviews/admin/review/review-list.html',
                        controller: 'ReviewListCtrl as vm'
                    })
                    .state('review-replies', {
                        url: '/review-replies',
                        templateUrl: 'modules/reviews/admin/review/review-reply-list.html',
                        controller: 'ReviewReplyListCtrl as vm'
                    })
                ;
            }
        ]);
})();