/*global angular*/
(function () {
    angular
        .module('shopAdmin.category')
        .factory('categoryService', categoryService);

    /* @ngInject */
    function categoryService($http) {
        var service = {
            getCategory: getCategory,
            createCategory: createCategory,
            editCategory: editCategory,
            deleteCategory: deleteCategory,
            getCategories: getCategories
        };
        return service;

        function getCategory(id) {
            return $http.get('Admin/Category/Get/' + id);
        }

        function getCategories() {
            return $http.get('Admin/Category/List');
        }

        function createCategory(category) {
            return $http.post('Admin/Category/Create', category);
        }

        function editCategory(category) {
            return $http.post('Admin/Category/Edit/' + category.id, category);
        }

        function deleteCategory(category) {
            return $http.post('Admin/Category/Delete/' + category.id, null);
        }
    }
})();