(function() {
    angular
        .module('hvAdmin.category')
        .controller('categoryListCtrl', [
            'categoryService',
            function(categoryService) {
                var ctrl = this;
                this.categories = [];

                this.getCategories = function getCategories() {
                    categoryService.getCategories().then(function(result) {
                        ctrl.categories = result.data;
                    });
                };

                this.getCategories();
            }
        ]);
})();