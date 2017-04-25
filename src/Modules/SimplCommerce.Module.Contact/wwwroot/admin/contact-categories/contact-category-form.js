 /*global angular*/
(function () {
    angular
        .module('simplAdmin.contact')
        .controller('ContactCategoryFormCtrl', ContactCategoryFormCtrl);

    /* @ngInject */
    function ContactCategoryFormCtrl($state, $stateParams, contactCategoryService) {
        var vm = this;
        vm.contactCategory = {};
        vm.contactCategoryId = $stateParams.id;
        vm.isEditMode = vm.contactCategoryId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = contactCategoryService.editContactCategory(vm.contactCategory);
            } else {
                promise = contactCategoryService.createContactCategory(vm.contactCategory);
            }

            promise
                .then(function (result) {
                    $state.go('contact-categories');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add contact category.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                contactCategoryService.getContactCategory(vm.contactCategoryId).then(function (result) {
                    vm.contactCategory = result.data;
                });
            }
        }

        init();
    }
})();