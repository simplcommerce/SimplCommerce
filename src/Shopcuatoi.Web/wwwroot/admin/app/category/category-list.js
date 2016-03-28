(function() {
    angular
        .module('hvAdmin.category')
        .controller('categoryListCtrl', [
            'categoryService',
            function(categoryService) {
                var vm = this;
                this.categories = [];

                this.getCategories = function getCategories() {
                    categoryService.getCategories().then(function(result) {
                        vm.categories = result.data;
                    });
                };

                this.delete = function deleteCategory(category) {
                    if (confirm("Are you sure?")) {
                        categoryService.deleteCategory(category).then(function(result) {
                            vm.getCategories();
                        });
                    }
                };

                this.getCategories();
            }
        ]);
})();