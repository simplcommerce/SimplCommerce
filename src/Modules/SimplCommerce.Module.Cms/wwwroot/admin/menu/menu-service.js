/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('menuService', menuService);

    /* @ngInject */
    function menuService($http) {
        var service = {
            getMenu: getMenu,
            createMenu: createMenu,
            editMenu: editMenu,
            deleteMenu: deleteMenu,
            getMenus: getMenus,
            addMenuItem: addMenuItem,
            getEntities: getEntities,
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
            return $http.post('api/menus/' + menuId + '/add-items', menuItems)
        }

        function getEntities(entityTypeId, searchName) {
            return $http.get('api/entities?entityTypeId=' + entityTypeId);
        }
    }
})();