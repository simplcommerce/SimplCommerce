(function() {
    angular
        .module('hvAdmin.category')
        .controller('categoryCreateCtrl', [
            '$state', 'categoryService',
            function($state, categoryService) {
                var vm = this;
                this.category = {};
                this.categories = [];

                this.create = function create() {
                    categoryService.createCategory(vm.category).then(function (result) {
                        $state.go('category');
                    });
                };

                this.getCategories = function getCategories() {
                    categoryService.getCategories().then(function(result) {
                        vm.categories = result.data;
                    });
                };

                this.getCategories();
            }
        ]);
})();