(function() {
    angular
        .module('shopAdmin.category')
        .factory('categoryService', [
            '$http',
            function ($http) {
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

                return {
                    getCategory: getCategory,
                    createCategory: createCategory,
                    editCategory: editCategory,
                    deleteCategory: deleteCategory,
                    getCategories: getCategories
                };
            }
        ]);
})();