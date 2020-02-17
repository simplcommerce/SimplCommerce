/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .controller('ContactAreaListCtrl', ['contactAreaService', 'translateService', ContactAreaListCtrl]);

    function ContactAreaListCtrl(contactAreaService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.contactAreas = [];

        vm.getContactAreas = function getContactAreas() {
            contactAreaService.getContactAreas().then(function (result) {
                vm.contactAreas = result.data;
            });
        };

        vm.deleteContactArea = function deleteContactArea(contactArea) {
            bootbox.confirm('Are you sure you want to delete this Contact Area: ' + contactArea.name, function (result) {
                if (result) {
                    contactAreaService.deleteContactArea(contactArea)
                       .then(function (result) {
                           vm.getContactAreas();
                           toastr.success(contactArea.name + ' has been deleted');
                       })
                       .catch(function (response) {
                           toastr.error(response.data.error);
                       });
                }
            });
        };

        vm.getContactAreas();
    }
})();
