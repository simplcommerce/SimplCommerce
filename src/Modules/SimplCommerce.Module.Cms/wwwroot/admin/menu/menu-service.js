/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('menuService', ['$http', menuService]);

    function menuService($http) {
        var service = {
            getMenu: getMenu,
            createMenu: createMenu,
            editMenu: editMenu,
            deleteMenu: deleteMenu,
            getMenus: getMenus,
            addMenuItem: addMenuItem,
            deleteMenuItem: deleteMenuItem,
            getEntities: getEntities,
            getEntityTypes: getEntityTypes
        };
        return service;

        function getMenu(id) {
            return $http.get('api/menus/' + id);
        }

        function getMenus() {
            return $http.get('api/menus');
        }

        function createMenu(menu) {
            return $http.post('api/menus', menu);
        }

        function editMenu(menu) {
            return $http.put('api/menus/' + menu.id, menu);
        }

        function deleteMenu(menu) {
            return $http.delete('api/menus/' + menu.id, null);
        }

        function addMenuItem(menuId, menuItems) {
            return $http.post('api/menus/' + menuId + '/add-items', menuItems);
        }

        function deleteMenuItem(menuItemId) {
            return $http.delete('api/menus/delete-item/' + menuItemId, null);
        }

        function getEntities() {
            return $http.get('api/entities');
        }

        function getEntityTypes() {
            return $http.get('api/entity-types/menuable');
        }
    }
})();
