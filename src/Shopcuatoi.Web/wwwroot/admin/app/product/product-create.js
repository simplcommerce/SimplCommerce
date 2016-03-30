(function() {
    angular
        .module('shopAdmin.product')
        .controller('productCreateCtrl', [
            '$state', '$http', 'categoryService', 'productService', 'summerNoteService',
            function($state, $http, categoryService, productService, summerNoteService) {
                var vm = this;
                // declare shoreDescription and description for summernote
                this.product = { shortDescription: '', description: '', specification: '' };
                this.product.categoryIds = [];
                this.product.attributes = [];
                this.product.variations = [];
                this.categories = [];
                this.thumbnailImage = null;
                this.productImages = [];
                this.attributes = [];
                this.addingAttribute = null;

                this.shortDescUpload = function (files) {
                    summerNoteService.upload(files[0])
                        .success(function(url) {
                            $(vm.shortDescEditor).summernote('insertImage', url);
                        });
                };

                this.descUpload = function (files) {
                    summerNoteService.upload(files[0])
                        .success(function(url) {
                            $(vm.descEditor).summernote('insertImage', url);
                        });
                };

                this.specUpload = function (files) {
                    summerNoteService.upload(files[0])
                        .success(function(url) {
                            $(vm.specEditor).summernote('insertImage', url);
                        });
                };

                this.addAttribute = function addAttribute() {
                    vm.addingAttribute.values = [];
                    var index = vm.attributes.indexOf(vm.addingAttribute);
                    vm.product.attributes.push(vm.addingAttribute);
                    vm.attributes.splice(index, 1);
                    vm.addingAttribute = null;
                };

                this.deleteAttr = function deleteAttr(attr) {
                    var index = vm.product.attributes.indexOf(attr);
                    vm.product.attributes.splice(index, 1);
                    vm.attributes.push(attr);
                };

                this.generateAttrCombination = function generateAttrCombination() {
                    var maxIndexAttr = vm.product.attributes.length - 1;
                    vm.product.variations = [];

                    function helper(arr, attrIndex) {
                        var j, l, variation, attrCombinations, attrValue;

                        for (j = 0, l = vm.product.attributes[attrIndex].values.length; j < l; j++) {
                            attrCombinations = arr.slice(0);
                            attrValue = {
                                attributeName: vm.product.attributes[attrIndex].name,
                                attributeId: vm.product.attributes[attrIndex].id,
                                value: vm.product.attributes[attrIndex].values[j]
                            };
                            attrCombinations.push(attrValue);

                            if (attrIndex === maxIndexAttr) {
                                variation = {
                                    name: attrCombinations.map(function(item) {
                                        return item.value;
                                    }).join('-'),
                                    attributeCombinations: attrCombinations
                                };
                                vm.product.variations.push(variation);
                            } else {
                                helper(attrCombinations, attrIndex + 1);
                            }
                        }
                    }

                    helper([], 0);
                };

                this.deleteVariation = function deleteVariation(variation) {
                    var index = vm.product.variations.indexOf(variation);
                    vm.product.variations.splice(index, 1);
                };

                this.save = function save() {
                    productService.createProduct(vm.product, vm.thumbnailImage, vm.productImages)
                        .success(function (result) {
                            $state.go('product');
                        });
                };

                function getCategories() {
                    categoryService.getCategories().then(function(result) {
                        vm.categories = result.data;
                    });
                };

                function getProductAttrs() {
                    productService.getProductAttrs().then(function(result) {
                        vm.attributes = result.data;
                    });
                }

                this.toggleCategories = function toggleCategories(categoryId) {
                    var index = vm.product.categoryIds.indexOf(categoryId);
                    if (index > -1) {
                        vm.product.categoryIds.splice(index, 1);
                    } else {
                        vm.product.categoryIds.push(categoryId);
                    }
                }

                function init() {
                    getProductAttrs();
                    getCategories();
                }

                init();
            }
        ]);
})();