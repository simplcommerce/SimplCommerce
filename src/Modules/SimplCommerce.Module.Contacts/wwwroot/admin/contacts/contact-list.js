/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .controller('ContactListCtrl', ContactListCtrl);

    /* @ngInject */
    function ContactListCtrl(contactService, contactAreaService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.contacts = [];

        contactAreaService.getContactAreas().then(function (result) {
            vm.contactAreas = result.data;
        });

        vm.getContacts = function getContacts(tableState) {            
            tableStateRef = tableState;
            vm.isLoading = true;
            contactService.getContacts(tableState).then(function (result) {               
                vm.contacts = result.data.items
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;;
            });
        };        

        vm.deleteContact = function deleteContact(contact) {
            bootbox.confirm('Are you sure you want to delete this contact: ' + contact.fullName, function (result) {
                if (result) {
                    contactService.deleteContact(contact)
                       .then(function (result) {
                           vm.getContacts(tableStateRef);
                           toastr.success(contact.name + ' has been deleted');
                       })
                       .catch(function (response) {
                           toastr.error(response.data.error);
                       });
                }
            });
        };
    }
})();