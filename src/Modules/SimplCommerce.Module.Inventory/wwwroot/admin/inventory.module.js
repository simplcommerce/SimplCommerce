/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.inventory', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('stocks', {
                    url: '/stocks',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/stock/stock-form.html',
                    controller: 'StockFormCtrl as vm'
                })
                .state('warehouses', {
                    url: '/warehouses',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/warehouse/warehouse-list.html',
                    controller: 'WarehouseListCtrl as vm'
                })
                .state('warehouse-create', {
                    url: '/warehouse/create',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/warehouse/warehouse-form.html',
                    controller: 'WarehouseFormCtrl as vm'
                })
                .state('warehouse-edit', {
                    url: '/warehouses/edit/:id',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/warehouse/warehouse-form.html',
                    controller: 'WarehouseFormCtrl as vm'
                })
                .state('warehouse-manage-products', {
                    url: '/warehouses/:warehouseId/products',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/warehouse/manage-products-form.html',
                    controller: 'ManageProductsFormCtrl as vm'
                })
                .state('stock-history',
                {
                    url: '/stock/history?warehouseId&productId',
                    templateUrl: '_content/SimplCommerce.Module.Inventory/admin/stock/stock-history.html',
                    controller: 'StockHistoryCtrl as vm'
                });
        }]);
})();
