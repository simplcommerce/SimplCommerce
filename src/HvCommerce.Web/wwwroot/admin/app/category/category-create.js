(function () {
    angular
        .module('hvAdmin.category')
        .controller('categoryCreateCtrl', ['$state', 'categoryService',
            function ($state, categoryService) {
                var ctrl = this;
                this.category = {};
                this.categories = [];

                this.create = function create() {
                    categoryService.createCategory(ctrl.category).then(function(result) {
                        $state.go('category');
                    });
                };

                this.getCategories = function getCategories() {
                    categoryService.getCategories().then(function (result) {
                        ctrl.categories = result.data;
                    });
                };

                this.getCategories();
            }
        ]);
})()