/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.comments', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('comments', {
                        url: '/comments',
                        templateUrl: 'modules/comments/admin/comment/comment-list.html',
                        controller: 'CommentListCtrl as vm'
                    })
                ;
            }
        ]);
})();