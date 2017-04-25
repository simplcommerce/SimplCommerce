/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.contact')
        .controller('ContactCategoryListCtrl', ContactCategoryListCtrl);

    /* @ngInject */
    function ContactCategoryListCtrl(contactCategoryService) {
        var vm = this;
        vm.contactCategorys = [];

        vm.getContactCategories = function getContactCategories() {
            contactCategoryService.getContactCategories().then(function (result) {
                vm.contactCategorys = result.data;
            });
        };

        vm.deleteContactCategory = function deleteContactCategory(contactCategory) {
            bootbox.confirm('Are you sure you want to delete this contact category: ' + contactCategory.name, function (result) {
                if (result) {
                    contactCategoryService.deleteContactCategory(contactCategory)
                       .then(function (result) {
                           vm.getContactCategories();
                           toastr.success(contactCategory.name + ' has been deleted');
                       })
                       .catch(function (response) {
                           toastr.error(response.data.error);
                       });
                }
            });
        };

        vm.getContactCategories();
    }
})();