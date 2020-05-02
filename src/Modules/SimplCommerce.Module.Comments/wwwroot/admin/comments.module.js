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
                        templateUrl: '_content/SimplCommerce.Module.Comments/admin/comment/comment-list.html',
                        controller: 'CommentListCtrl as vm'
                    })
                ;
            }
        ]);
})();
