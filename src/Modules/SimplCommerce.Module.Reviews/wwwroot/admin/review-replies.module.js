/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.review-replies', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('review-replies', {
                        url: '/review-replies',
                        templateUrl: 'modules/reviews/admin/review/review-reply-list.html',
                        controller: 'ReviewReplyListCtrl as vm'
                    })
                    ;
            }
        ]);
})();
