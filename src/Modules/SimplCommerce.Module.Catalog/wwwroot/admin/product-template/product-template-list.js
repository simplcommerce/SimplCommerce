/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductTemplateListCtrl', ProductTemplateListCtrl);

    /* @ngInject */
    function ProductTemplateListCtrl(productTemplateService) {
        var vm = this;
        vm.productTemplates = [];

        vm.getProductTemplates = function getProductTemplates() {
            productTemplateService.getProductTemplates().then(function (result) {
                vm.productTemplates = result.data;
            });
        };

        vm.deleteProductTemplate = function deleteProductTemplate(productTemplate) {
            bootbox.confirm('Are you sure you want to delete this template: ' + productTemplate.name, function (result) {
                if (result) {
                    productTemplateService.deleteProductTemplate(productTemplate)
                       .then(function (result) {
                           vm.getProductTemplates();
                           toastr.success(productTemplate.name + ' has been deleted');
                       })
                       .catch(function (error) {
                           toastr.error(error.data.error);
                       });
                }
            });
        };

        vm.getProductTemplates();
    }
})();