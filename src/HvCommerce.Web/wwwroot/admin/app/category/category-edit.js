(function() {
    angular
        .module('hvAdmin.category')
        .controller('categoryEditCtrl', [
            '$q', '$state', '$stateParams', 'categoryService',
            function($q, $state, $stateParams, categoryService) {
                var vm = this;
                this.category = {};
                this.categories = [];

                this.save = function save() {
                    categoryService.editCategory(vm.category).then(function (result) {
                        $state.go('category');
                    });
                };

                function init() {
                    $q.all([
                            categoryService.getCategories(),
                            categoryService.getCategory($stateParams.id)
                        ])
                        .then(function (result) {
                            var index;
                            vm.categories = result[0].data;
                            vm.category = result[1].data;

                            index = vm.categories.map(function (item) {
                                return item.id;
                            }).indexOf(vm.category.id);
                            vm.categories.splice(index, 1);
                        });
                }

                init();
            }
        ]);
})();