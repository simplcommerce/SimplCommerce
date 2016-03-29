(function () {
    'use strict';

    angular
        .module('shopAdmin.product', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('product', {
                        url: '/product',
                        templateUrl: 'admin/app/product/product-list.html',
                        controller: 'productListCtrl as vm'
                    })
                    .state('product-create', {
                        url: '/product-create',
                        templateUrl: 'admin/app/product/product-form.html',
                        controller: 'productCreateCtrl as vm'
                    })
                ;
            }
        ]);
})();