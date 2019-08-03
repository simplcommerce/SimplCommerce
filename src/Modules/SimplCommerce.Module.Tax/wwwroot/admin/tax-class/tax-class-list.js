/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.tax')
        .controller('TaxClassListCtrl', ['taxClassService', 'translateService', TaxClassListCtrl]);

    function TaxClassListCtrl(taxClassService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxClasses = [];

        vm.getTaxClasses = function getTaxClasses() {
            taxClassService.getTaxClasses().then(function (result) {
                vm.taxClasses = result.data;
            });
        };

        vm.deleteTaxClass = function deleteTaxClass(taxClass) {
            bootbox.confirm('Are you sure you want to delete this taxClass: ' + taxClass.name, function (result) {
                if (result) {
                    taxClassService.deleteTaxClass(taxClass)
                        .then(function (result) {
                            vm.getTaxClasses();
                            toastr.success(taxClass.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        vm.getTaxClasses();
    }
})();
