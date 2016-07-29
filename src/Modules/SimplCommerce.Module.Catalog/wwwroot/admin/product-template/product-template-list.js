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
            if (confirm("Are you sure?")) {
                productTemplateService.deleteProductTemplate(productTemplate)
                    .success(function (result) {
                        vm.getProductTemplates();
                    });
            }
        };

        vm.getProductTemplates();
    }
})();