/**
 * Created by Michael on 04/05/14.
 */

describe('dirPagination directive', function() {

    var $compile;
    var $scope;
    var $timeout;
    var containingElement;
    var myCollection;
    var myObjectCollection;

    beforeEach(module('angularUtils.directives.dirPagination'));
    beforeEach(module('templates-main'));

    // used to test the paginationTemplateProvider (see end of file)
    var templateProvider;
    angular.module('customTemplateTestApp', []);
    beforeEach(module('customTemplateTestApp', function(paginationTemplateProvider) {
        templateProvider = paginationTemplateProvider;
    }));

    beforeEach(inject(function($rootScope, _$compile_, _$timeout_) {

        $compile = _$compile_;
        $timeout = _$timeout_;
        $scope = $rootScope.$new();
        containingElement = angular.element('<div></div>');

        myCollection = [];
        for(var i = 1; i <= 100; i++) {
            myCollection.push('item ' + i);
        }
    }));

    function compileElement(collection, itemsPerPage, currentPage, customExpression, totalItems) {
        var expression;
        var totalItemsHtml;
        var html;
        $scope.collection = collection;
        $scope.itemsPerPage = itemsPerPage;
        $scope.currentPage = currentPage || 1;
        $scope.totalItems = totalItems || undefined;
        totalItemsHtml =  (typeof totalItems !== 'undefined') ? 'total-items="totalItems"' : '';
        expression = customExpression || "item in collection | itemsPerPage: itemsPerPage";
        html = '<ul class="list"><li dir-paginate="'+ expression + '" current-page="currentPage" ' + totalItemsHtml + ' >{{ item }}</li></ul> ' +
            '<dir-pagination-controls></dir-pagination-controls>';
        containingElement.append($compile(html)($scope));
        $scope.$apply();
    }

    function getListItems() {
        return containingElement.find('ul.list li').map(function() {
            return $(this).text().trim();
        }).get();
    }

    function getPageLinksArray() {
        return containingElement.find('ul.pagination li').map(function() {
            return $(this).text().trim();
        }).get();
    }

    describe('paginated list', function() {

        it('should throw an exception if itemsPerPage filter not set', function() {
            function compile() {
                var customExpression = "item in collection";
                compileElement(myCollection, 5, 1, customExpression);
            }
            expect(compile).toThrow("pagination directive: the 'itemsPerPage' filter must be set.");
        });

        it('should repeat the items like ng-repeat', function() {
            compileElement(myCollection);
            var listItems = getListItems();

            expect(listItems.length).toBe(100);
        });

        it('should limit the items to match itemsPerPage = 10', function() {
            var listItems;

            compileElement(myCollection, 10);
            listItems = getListItems();
            expect(listItems.length).toBe(10);
        });

        it('should limit the items to match itemsPerPage = 50', function() {
            var listItems;

            compileElement(myCollection, 50);
            listItems = getListItems();
            expect(listItems.length).toBe(50);
        });

        it('should not mutate the collection itself ', function() {
            compileElement(myCollection);
            expect($scope.collection.length).toBe(100);
            compileElement(myCollection, 50);
            expect($scope.collection.length).toBe(100);
            compileElement(myCollection, 5);
            expect($scope.collection.length).toBe(100);
        });

        it('should work correctly with other filters (filter)', function() {
            $scope.filterBy = '2';
            var customExpression = "item in collection | filter: filterBy | itemsPerPage: itemsPerPage";
            compileElement(myCollection, 5, 1, customExpression);

            var listItems = getListItems();
            expect(listItems).toEqual(['item 2', 'item 12', 'item 20', 'item 21', 'item 22']);
        });

        it('should work correctly with other filters (orderBy)', function() {
            var customExpression = "item in collection | orderBy:'toString()':true | itemsPerPage: itemsPerPage";
            compileElement(myCollection, 5, 1, customExpression);

            var listItems = getListItems();
            expect(listItems).toEqual(['item 99', 'item 98', 'item 97', 'item 96', 'item 95']);
        });

        it('should work inside a transcluded directive (ng-if)', function() {
            $scope.collection = myCollection;
            var html = '<div ng-if="true">' +
                '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 5">{{ item }}</li></ul> ' +
                '<dir-pagination-controls></dir-pagination-controls>' +
                '</div>';
            containingElement.append($compile(html)($scope));
            $scope.$apply();

            var listItems = getListItems();
            expect(listItems).toEqual(['item 1', 'item 2', 'item 3', 'item 4', 'item 5']);
        });

        it('should display the second page when compiled with currentPage = 2', function() {
            var listItems;
            compileElement(myCollection, 3, 2);
            listItems = getListItems();
            expect(listItems).toEqual(['item 4', 'item 5', 'item 6']);
        });

        it('should display the next page when the currentPage changes', function() {
            var listItems;
            compileElement(myCollection, 3);
            listItems = getListItems();
            expect(listItems).toEqual(['item 1', 'item 2', 'item 3']);

            $scope.$apply(function() {
                $scope.currentPage = 2;
            });
            listItems = getListItems();
            expect(listItems).toEqual(['item 4', 'item 5', 'item 6']);

            $scope.$apply(function() {
                $scope.currentPage = 3;
            });
            listItems = getListItems();
            expect(listItems).toEqual(['item 7', 'item 8', 'item 9']);
        });


        it('should work if itemsPerPage is a literal value', function() {
            var customExpression = "item in collection | itemsPerPage: 2";
            compileElement(myCollection, null, 1, customExpression);

            var listItems = getListItems();
            expect(listItems.length).toEqual(2);
            expect(listItems).toEqual(['item 1', 'item 2']);
        });

        // see https://github.com/michaelbromley/angularUtils/issues/233
        function testPaginationId(paginationIdString) {
            $scope.collection = myCollection;
            var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 2"  pagination-id="' + paginationIdString + '" >{{ item }}</li></ul> ' +
                '<dir-pagination-controls pagination-id="some.string"></dir-pagination-controls>';
            containingElement.append($compile(html)($scope));
            $scope.$apply();

            var listItems = getListItems();
            expect(listItems.length).toEqual(2);
            expect(listItems).toEqual(['item 1', 'item 2']);
        }

        it('should work when the pagination-id evaluates to a string containing a period.', function() {
            testPaginationId('some.string');
        });

        it('should work when the pagination-id evaluates to a string containing a hyphen.', function() {
            testPaginationId('some-string');
        });

    });

    describe('paginating over an object', function() {
        beforeEach(function() {
            myObjectCollection = {};
            for(var i = 1; i <= 100; i++) {
                myObjectCollection['key_' + i] = 'item ' + i;
            }
        });

        it('should not throw an exception when the collection is an object', function() {
            function compile() {
                compileElement(myObjectCollection, 10, 1, "(key, item) in collection | itemsPerPage: itemsPerPage");
            }
            expect(compile).not.toThrow();
        });

        it('should correctly paginate with simple syntax', function() {
            compileElement(myObjectCollection, 5, 1, "item in collection | itemsPerPage: itemsPerPage");
            expect(getListItems()).toEqual(['item 1', 'item 2', 'item 3', 'item 4', 'item 5']);
        });

        it('should correctly paginate with (key, value) syntax', function() {
            compileElement(myObjectCollection, 5, 1, "(key, item) in collection | itemsPerPage: itemsPerPage");
            expect(getListItems()).toEqual(['item 1', 'item 2', 'item 3', 'item 4', 'item 5']);
        });

        it('should show the correct items for the currentPage', function() {
            compileElement(myObjectCollection, 5, 4, "(key, item) in collection | itemsPerPage: itemsPerPage");
            expect(getListItems()).toEqual(['item 16', 'item 17', 'item 18', 'item 19', 'item 20']);
        });

        it('should display the correct pagination links', function() {
            compileElement(myObjectCollection, 20, 1, "item in collection | itemsPerPage: itemsPerPage");
            var paginationLinks = getPageLinksArray();

            expect(paginationLinks).toEqual(['‹','1', '2', '3', '4', '5', '›']);
        });

    });

    describe('valid expressions', function() {

        beforeEach(function() {
            $scope.getPageSize = function() {
                return 10;
            };
        });

        it('should allow a space after itemsPerPage and before the colon', function() {
            function compile() {
                compileElement(myCollection, 5, 1, "item in collection | itemsPerPage : 10");
            }
            expect(compile).not.toThrow();
        });

        it('should allow parentheses around the itemsPerPage filter', function() {
            function compile() {
                compileElement(myCollection, 5, 1, "item in filtered = (collection | filter: '1' | itemsPerPage: itemsPerPage)");
            }

            expect(compile).not.toThrow();
            expect(getListItems()).toEqual(['item 1', 'item 10', 'item 11', 'item 12', 'item 13']);
            expect($scope.filtered.length).toEqual(5);
        });

        it('should allow the itemsPerPage to be a scope method 1', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage: getPageSize()");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        it('should allow the itemsPerPage to be a scope method 2', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage: getPageSize(myvar)");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        it('should allow the itemsPerPage to be a scope method 3', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in filtered = (collection | itemsPerPage: getPageSize(_myvar))");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        it('should allow alias syntax', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection  | itemsPerPage: 10 as myAlias");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
            expect($scope.myAlias.length).toEqual(10);
        });

        it('should allow alias syntax 2', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection  | itemsPerPage: getPageSize() as myAlias");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
            expect($scope.myAlias.length).toEqual(10);
        });

        it('should allow alias syntax 3', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in alias1 = (collection  | itemsPerPage: getPageSize()) as alias2");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
            expect($scope.alias1.length).toEqual(10);
            expect($scope.alias2.length).toEqual(10);
        });

        it('should allow dot and bracket notation', function() {
            function compile() {
                $scope.foo = {
                    name: 'myCollection',
                    myCollection: myCollection,
                    perPage: 10
                };
                compileElement(myCollection, 5, 1,  "item in foo[foo.name] | itemsPerPage:foo.perPage");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        // see https://github.com/michaelbromley/angularUtils/issues/241
        // the actual issue was caused by the work "sharedTasksFilters", which was
        // being matched by the part of the regex that looks for "as" alias syntax.
        it('should allow deeply nested, long-winded object for itemsPerPage', function() {
            function compile() {
                $scope.eventsCtrl = { eventsFilters: { sharedTasksFilters: { eventsPerPage: 10 } } };
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage:eventsCtrl.eventsFilters.sharedTasksFilters.eventsPerPage");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });


        it('should allow track by syntax 1', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage: 10 track by $index");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        it('should allow track by syntax 2', function() {
            function compile() {
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage: 10 track by item");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

        it('should allow track by with dot in itemsPerPage', function() {
            function compile() {
                $scope.foo = { perPage : 10 };
                compileElement(myCollection, 5, 1,  "item in collection | itemsPerPage: foo.perPage track by item");
            }
            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(10);
        });

    });

    describe('if currentPage attribute is not set', function() {

        beforeEach(function() {
            $scope.collection = myCollection;
            html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 3">{{ item }}</li></ul> ' +
                '<dir-pagination-controls></dir-pagination-controls>';
            containingElement.append($compile(html)($scope));
            $scope.$apply();
        });

        it('should compile', function() {
            var listItems = getListItems();
            expect(listItems).toEqual(['item 1', 'item 2', 'item 3']);
        });

        it('should page correctly', function() {
            var pagination = containingElement.find('ul.pagination');

            pagination.children().eq(3).find('a').triggerHandler('click');
            $scope.$apply();
            expect($scope.__default__currentPage).toBe(3);
            var listItems = getListItems();
            expect(listItems).toEqual(['item 7', 'item 8', 'item 9']);
        });
    });

    describe('pagination controls', function() {

        beforeEach(function(){
            spyOn(console, 'warn');
        });

        it('should throw a warning if the dir-paginate directive has not been set up', function() {

            function compile() {
                var html = '<dir-pagination-controls></dir-pagination-controls>';
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            compile();

            expect(console.warn).toHaveBeenCalledWith('Pagination directive: the pagination controls cannot be used without the corresponding pagination directive, which was not found at link time.');
        });

        it('should not display pagination if all rows fit on one page', function() {
            compileElement(myCollection, 9999);
            var paginationLinks = getPageLinksArray();

            expect(paginationLinks.length).toBe(0);
        });

        it('should paginate by default if all items do not fit on page', function() {
            compileElement(myCollection, 40);
            var paginationLinks = getPageLinksArray();

            expect(paginationLinks).toEqual(['‹','1', '2', '3', '›']);
        });

        it('should update the currentPage property of $scope when links clicked', function() {
            compileElement(myCollection, 40);
            var pagination = containingElement.find('ul.pagination');

            pagination.children().eq(3).find('a').triggerHandler('click');
            $scope.$apply();
            expect($scope.currentPage).toBe(3);

            pagination.children().eq(2).find('a').triggerHandler('click');
            $scope.$apply();
            expect($scope.currentPage).toBe(2);

            pagination.children().eq(1).find('a').triggerHandler('click');
            $scope.$apply();
            expect($scope.currentPage).toBe(1);
        });

        it('should set the pagination.current value to 5 when compiled with currentPage = 5', function() {
            compileElement(myCollection, 3, 5);
            var activePageItem = containingElement.find('li.active').eq(0);
            var activePage = activePageItem.text().trim();

            expect(activePage).toEqual('5');
        });

        it('should show the correct pagination links at start of sequence', function() {
            compileElement(myCollection, 1);
            var pageLinks = getPageLinksArray();

            expect(pageLinks).toEqual(['‹','1', '2', '3', '4', '5', '6', '7', '...', '100', '›']);
        });

        it('should show the correct pagination links in middle sequence', function() {
            compileElement(myCollection, 1);
            $scope.$apply(function() {
                $scope.currentPage = 50;
            });
            var pageLinks = getPageLinksArray();

            expect(pageLinks).toEqual(['‹','1', '...', '48', '49', '50', '51', '52', '...', '100', '›']);
        });

        it('should show the correct pagination links at end of sequence', function() {
            compileElement(myCollection, 1);
            $scope.$apply(function() {
                $scope.currentPage = 99;
            });
            var pageLinks = getPageLinksArray();

            expect(pageLinks).toEqual(['‹','1', '...', '94', '95', '96', '97', '98', '99', '100', '›']);
        });

        it('should show the correct pagination links after item removed from cllection', function() {
            compileElement(myCollection, 1);
            $scope.$apply(function() {
                $scope.currentPage = 98;
            });

            $scope.$apply(function() {
                $scope.collection.pop();
            });
            var pageLinks = getPageLinksArray();

            expect(pageLinks).toEqual(['‹','1', '...', '93', '94', '95', '96', '97', '98', '99', '›']);
        });

        it('should calculate pages based off collection after all filters are applied', function() {
            $scope.filterBy = '2';
            var customExpression = "item in collection | filter: filterBy | itemsPerPage: itemsPerPage";
            compileElement(myCollection, 5, 1, customExpression);

            var pageLinks = getPageLinksArray();
            expect(pageLinks.length).toEqual(6);
        });

        it('should update the active page to reflect the value of the current-page property', function() {
            compileElement(myCollection, 10, 3);

            var activeLink = containingElement.find('ul.pagination li.active');
            expect(activeLink.html()).toContain(3);

            $scope.$apply(function() {
                $scope.currentPage = 1;
            });

            activeLink = containingElement.find('ul.pagination li.active');
            expect(activeLink.html()).toContain(1);
        });

        /**
         * Issue raised here https://github.com/michaelbromley/angularUtils/issues/78
         * Where the dir-paginate directive is inside an ngSwitch block (which is initially hidden), so the linking function is not immediately executed.
         * The dir-pagination-controls directive is *outside* the switch block, so it gets both compiled *and* linked on page load.
         */
        it('should allow paginate directive to be defined in a deferred-linking situation without error', function() {
            function compile() {
                var html;
                $scope.collection = myCollection;
                $scope.showList = false;
                html = '<div ng-if="showList">' +
                    '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 10">{{ item }}</li></ul> ' +
                    '</div>' +
                    '<dir-pagination-controls></dir-pagination-controls>';
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            expect(compile).not.toThrow();
            expect(getListItems().length).toEqual(0);

            $scope.$apply(function() {
                $scope.showList = true;
            });
            expect(getListItems().length).toEqual(10);
        });

        describe('optional attributes', function() {

            function compileWithAttributes(attributes) {
                $scope.collection = myCollection;
                $scope.currentPage = 1;
                var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 10" current-page="currentPage">{{ item }}</li></ul> ' +
                    '<dir-pagination-controls ' + attributes + ' ></dir-pagination-controls>';
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }


            it('should accept a max-size attribute to limit the length of the control', function() {
                compileWithAttributes(' max-size="5" ');

                var pageLinks = getPageLinksArray();

                expect(pageLinks).toEqual(['‹','1', '2', '3', '...', '10', '›']);
            });

            it('should alter links array when value of max-size changes', function() {
                $scope.maxSize = 5;
                compileWithAttributes(' max-size="maxSize" ');

                var pageLinks = getPageLinksArray();

                expect(pageLinks).toEqual(['‹','1', '2', '3', '...', '10', '›']);

                $scope.$apply(function() {
                    $scope.maxSize = 9;
                });

                pageLinks = getPageLinksArray();

                expect(pageLinks).toEqual(['‹','1', '2', '3', '4', '5', '6', '7', '...', '10', '›']);
            });

            it('should impose a minimum max-size of 5', function() {
                compileWithAttributes(' max-size="2" ');

                var pageLinks = getPageLinksArray();

                expect(pageLinks).toEqual(['‹','1', '2', '3', '...', '10', '›']);
            });

            it('should go to the last page when clicking the end arrow', function() {
                compileWithAttributes(' boundary-links="true" ');
                var pagination = containingElement.find('ul.pagination');

                pagination.children().eq(10).find('a').triggerHandler('click');
                $scope.$apply();
                expect($scope.currentPage).toBe(10);
            });

            it('should go to the first page when clicking the end arrow', function() {
                compileWithAttributes(' boundary-links="true" ');
                var pagination = containingElement.find('ul.pagination');

                $scope.$apply(function() {
                    $scope.currentPage = 5;
                });
                expect($scope.currentPage).toBe(5);

                pagination.children().eq(0).find('a').triggerHandler('click');
                $scope.$apply();
                expect($scope.currentPage).toBe(1);
            });

            it('should page forward', function() {
                compileWithAttributes('  ');
                var pagination = containingElement.find('ul.pagination');

                pagination.children().eq(10).find('a').triggerHandler('click');
                $scope.$apply();
                expect($scope.currentPage).toBe(2);
            });

            describe('on-page-change callback', function() {

                beforeEach(function() {
                    $scope.myCallback = function(currentPage) {
                        return "The current page is " + currentPage;
                    };
                    spyOn($scope, 'myCallback');
                });

                it('should call the callback once when page link clicked', function() {
                    compileWithAttributes(' on-page-change="myCallback(newPageNumber)" ');
                    var pagination = containingElement.find('ul.pagination');

                    expect($scope.myCallback.calls.count()).toEqual(0);
                    pagination.children().eq(2).find('a').triggerHandler('click');
                    $scope.$apply();
                    expect($scope.myCallback).toHaveBeenCalled();
                    expect($scope.myCallback.calls.count()).toEqual(1);
                });

                it('should not call the callback on loading first page, even with controls appearing above the pagination', function() {
                    function compileWithControlsFirst(attributes) {
                        $scope.currentPage = 1;
                        var html = '<dir-pagination-controls ' + attributes + ' ></dir-pagination-controls>' +
                            '<table>' +
                            '<tr dir-paginate="item in collection | itemsPerPage: 10"><td>{{ item }}</td></tr>' +
                            '</table>';
                        containingElement.append($compile(html)($scope));
                        $scope.$apply();
                    }

                    compileWithControlsFirst(' on-page-change="myCallback(newPageNumber)" ');

                    $scope.$apply(function() {
                        $scope.collection = myCollection;
                    });

                    var pagination = containingElement.find('ul.pagination');

                    expect($scope.myCallback.calls.count()).toEqual(0);
                    pagination.children().eq(2).find('a').triggerHandler('click');
                    $scope.$apply();
                    expect($scope.myCallback).toHaveBeenCalled();
                    expect($scope.myCallback.calls.count()).toEqual(1);
                });

                it('should pass the current page number to the callback', function() {
                    compileWithAttributes(' on-page-change="myCallback(newPageNumber)" ');
                    var pagination = containingElement.find('ul.pagination');

                    pagination.children().eq(2).find('a').triggerHandler('click');
                    $scope.$apply();
                    expect($scope.myCallback).toHaveBeenCalledWith(2);
                });

                it('should pass the previous page number to the callback', function() {
                    compileWithAttributes(' on-page-change="myCallback(oldPageNumber)" ');
                    var pagination = containingElement.find('ul.pagination');

                    pagination.children().eq(3).find('a').triggerHandler('click');
                    $scope.$apply();
                    expect($scope.myCallback).toHaveBeenCalledWith(1);
                });
            });

            describe('total-items attribute', function() {

                it('should give correct pagination at 200', function() {
                    compileElement(myCollection, 100, 1, false, 200);

                    var pageLinks = getPageLinksArray();
                    expect(pageLinks).toEqual(['‹','1', '2', '›']);
                });

                it('should give correct pagination at 500', function() {
                    compileElement(myCollection, 100, 1, false, 500);

                    var pageLinks = getPageLinksArray();
                    expect(pageLinks).toEqual(['‹','1', '2','3','4','5', '›']);
                });

                it('should correctly display the second page of results', function() {
                    compileElement(myCollection, 100, 2, false, 500);
                    listItems = getListItems();
                    expect(listItems.length).toEqual(100);
                });
            });

            describe('auto-hide attribute', function () {
                function compileWithAttributesAndItemsPerPage(attributes, itemsPerPage) {
                    $scope.collection = myCollection;
                    $scope.currentPage = 1;
                    var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: ' +
                        itemsPerPage + '" current-page="currentPage">{{ item }}</li></ul> ' +
                        '<dir-pagination-controls ' + attributes + ' ></dir-pagination-controls>';
                    containingElement.append($compile(html)($scope));
                    $scope.$apply();
                }

                it('when not set, should not generate pagination controls, with not enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('', 100);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(0);
                });

                it('when not set, should generate pagination controls, with enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('', 99);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(1);
                });

                it('when set to false, should generate pagination controls, with not enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('auto-hide="false"', 100);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(1);
                    var pageLinks = containingElement.find('ul.pagination li.disabled');
                    expect(pageLinks.length).toEqual(3);
                });

                it('when set to false, should generate pagination controls, with enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('auto-hide="false"', 99);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(1);
                });

                it('when set to true, should generate pagination controls, with enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('auto-hide="true"', 100);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(0);
                });

                it('when set to true, should generate pagination controls, with not enough items to paginate over', function () {
                    compileWithAttributesAndItemsPerPage('auto-hide="true"', 99);
                    var pagination = containingElement.find('ul.pagination');
                    expect(pagination.length).toEqual(1);
                });
            });
        });

    });

    describe('multiple pagination instances per page', function() {

        var collection1, collection2, currentPage1, currentPage2;

        beforeEach(function() {
            collection1 = [];
            collection2 = [];
            for (var i = 0; i < 20; i++) {
                collection1.push('c1:' + i);
                collection2.push('c2:' + i);
            }
            spyOn(console, 'warn');
        });

        /**
         * Compile function for multiple pagination directives on a single page
         * @param collection
         * @param itemsPerPage
         * @param currentPage
         * @param paginationId
         * @param customExpression
         */
        function compileMultipleInstance(collection, itemsPerPage, currentPage, paginationId, customExpression) {
            var expression;
            var html;
            if ($scope.collection === undefined) {
                $scope.collection = {};
            }
            if ($scope.itemsPerPage === undefined) {
                $scope.itemsPerPage = {};
            }
            if ($scope.currentPage === undefined) {
                $scope.currentPage = {};
            }
            $scope.collection[paginationId] = collection;
            $scope.itemsPerPage[paginationId] = itemsPerPage;
            $scope.currentPage[paginationId] = currentPage || 1;
            expression = customExpression || "item in collection." + paginationId + " | itemsPerPage: itemsPerPage." + paginationId;
            html = '<ul class="list"><li dir-paginate="'+ expression + '" current-page="currentPage.' + paginationId + '" pagination-id="' + paginationId + '" >{{ item }}</li></ul> ' +
                '<dir-pagination-controls pagination-id="' + paginationId + '"></dir-pagination-controls>';
            containingElement.append($compile(html)($scope));
            $scope.$apply();
        }

        function clickPaginationLink(paginationId, index) {
            var pagination = containingElement.find('dir-pagination-controls[pagination-id="' + paginationId + '"]');

            pagination.find('li').eq(index).find('a').triggerHandler('click');
            $scope.$apply();
        }

        function getMultiPageLinksArray(paginationId) {
            return containingElement.find('dir-pagination-controls[pagination-id="' + paginationId + '"] li').map(function() {
                return $(this).text().trim();
            }).get();
        }

        function getMultiListItems(paginationId) {
            return containingElement.find('li[pagination-id="' + paginationId + '"]').map(function() {
                return $(this).text().trim();
            }).get();
        }

        it('should allow pagination-id to control a specific collection', function() {
            compileMultipleInstance(collection1, 5, 1, "c1" );
            compileMultipleInstance(collection2, 5, 1, "c2" );

            clickPaginationLink("c1", 2);
            clickPaginationLink("c2", 4);

            expect($scope.currentPage.c1).toEqual(2);
            expect($scope.currentPage.c2).toEqual(4);
        });

        it('should allow independent changing of items per page', function() {
            compileMultipleInstance(collection1, 5, 1, "c1" );
            compileMultipleInstance(collection2, 5, 1, "c2" );

            expect(getMultiPageLinksArray("c1").length).toBe(6);
            expect(getMultiPageLinksArray("c2").length).toBe(6);

            $scope.$apply(function() {
                $scope.itemsPerPage.c1 = 10;
            });

            expect(getMultiPageLinksArray("c1").length).toBe(4);
            expect(getMultiPageLinksArray("c2").length).toBe(6);

            $scope.$apply(function() {
                $scope.itemsPerPage.c2 = 7;
            });

            expect(getMultiPageLinksArray("c1").length).toBe(4);
            expect(getMultiPageLinksArray("c2").length).toBe(5);
        });

        it('should allow independent filtering', function() {
            compileMultipleInstance(collection1, 5, 1, "c1", "item in collection.c1 | filter: filter1 | itemsPerPage: itemsPerPage.c1: 'c1'");
            compileMultipleInstance(collection2, 5, 1, "c2", "item in collection.c2 | filter: filter2 | itemsPerPage: itemsPerPage.c2: 'c2'" );

            $scope.$apply(function() {
                $scope.filter1 = "7";
                $scope.filter2 = "8";
            });

            expect(getMultiListItems("c1")).toEqual(['c1:7', 'c1:17']);
            expect(getMultiListItems("c2")).toEqual(['c2:8', 'c2:18']);

        });

        it('should allow independent setting of current-page externally', function() {
            compileMultipleInstance(collection1, 2, 1, "c1" );
            compileMultipleInstance(collection2, 2, 1, "c2" );

            $scope.$apply(function() {
                $scope.currentPage.c1 = 2;
                $scope.currentPage.c2 = 4;
            });

            expect(getMultiListItems("c1")).toEqual(['c1:2', 'c1:3']);
            expect(getMultiListItems("c2")).toEqual(['c2:6', 'c2:7']);
        });

        it('should print a warning if a non-existant paginationId is set in the pagination-controls', function() {
            $scope.collection = [1,2,3,4,5];

            function compile() {
                var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 3 : \'id1\'" pagination-id="id1" >{{ item }}</li></ul> ' +
                    '<dir-pagination-controls pagination-id="id2"></dir-pagination-controls>';

                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }
            compile();
            expect(console.warn).toHaveBeenCalledWith('Pagination directive: the pagination controls (id: id2) cannot be used without the corresponding pagination directive, which was not found at link time.');
        });

        it('should throw an exception if a non-existant paginationId is set in the itemsPerPage filter', function() {
            $scope.collection = [1,2,3,4,5];

            function compile() {
                var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 3 : \'id2\'" pagination-id="id1" >{{ item }}</li></ul> ' +
                    '<dir-pagination-controls pagination-id="id1"></dir-pagination-controls>';

                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            expect(compile).toThrow("pagination directive: the itemsPerPage id argument (id: id2) does not match a registered pagination-id.");
        });

        describe('valid expressions with pagination id', function() {

            it('should allow track by syntax', function() {
                function compile() {
                    compileMultipleInstance(collection1, 10, 1, "c1", "item in collection.c1 | itemsPerPage: itemsPerPage.c1 track by $index");
                }
                expect(compile).not.toThrow();
                expect(getListItems().length).toEqual(10);
            });

            it('should allow track by with other filter syntax', function() {
                function compile() {
                    compileMultipleInstance(collection1, 10, 1, "c1", "item in collection.c1 | orderBy: reverse | itemsPerPage: itemsPerPage.c1 track by $index");
                }
                expect(compile).not.toThrow();
                expect(getListItems().length).toEqual(10);
            });
        });

        describe('dymanic pagination-id', function() {

            function compileWithDynamicId(paginationId, customExpression) {
                var html;
                html = '<ul class="list"><li dir-paginate="'+ customExpression + '" current-page="1" pagination-id="' + paginationId + '" >{{ item }}</li></ul> ' +
                    '<dir-pagination-controls pagination-id="' + paginationId + '"></dir-pagination-controls>';
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            it('should allow object reference', function() {
                function compile() {
                    $scope.myId = {
                        foo: 'foo'
                    };
                    $scope.collection = myCollection;
                    compileWithDynamicId('myId.foo', 'item in collection | itemsPerPage: 10');
                }

                expect(compile).not.toThrow();
                expect(getListItems().length).toEqual(10);
            });
        });

    });

    describe('pagination controls template API', function() {
        function compile() {
            var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: 3" current-page="currentPage">{{ item }}</li></ul> ' +
                '<dir-pagination-controls template-url="directives/pagination/testTemplate.tpl.html"></dir-pagination-controls>';
            $scope.collection = [1,2,3,4,5,6,7];
            $scope.currentPage = 1;
            containingElement.append($compile(html)($scope));
            $scope.$apply();
        }

        it('should provide correct values for current page', function() {
            compile();

            expect(containingElement.find('#tt-pagination-current').html()).toEqual('1');
            $scope.$apply(function() {
                $scope.currentPage = 2;
            });
            expect(containingElement.find('#tt-pagination-current').html()).toEqual('2');
        });

        it('should provide correct value for last page', function() {
            compile();
            expect(containingElement.find('#tt-pagination-last').html()).toEqual('3');
        });

        it('should provide correct value for range.lower', function() {
            compile();
            expect(containingElement.find('#tt-range-lower').html()).toEqual('1');
            $scope.$apply(function() {
                $scope.currentPage = 2;
            });
            expect(containingElement.find('#tt-range-lower').html()).toEqual('4');
            $scope.$apply(function() {
                $scope.currentPage = 3;
            });
            expect(containingElement.find('#tt-range-lower').html()).toEqual('7');
        });

        it('should provide correct value for range.upper', function() {
            compile();
            expect(containingElement.find('#tt-range-upper').html()).toEqual('3');
            $scope.$apply(function() {
                $scope.currentPage = 2;
            });
            expect(containingElement.find('#tt-range-upper').html()).toEqual('6');
            $scope.$apply(function() {
                $scope.currentPage = 3;
            });
            expect(containingElement.find('#tt-range-upper').html()).toEqual('7');
        });

        it('should provide correct value for range.total', function() {
            compile();
            expect(containingElement.find('#tt-range-total').html()).toEqual('7');
            $scope.$apply(function() {
                $scope.currentPage = 2;
            });
            expect(containingElement.find('#tt-range-total').html()).toEqual('7');
        });
    });

    describe('multi element functionality', function() {

        function compileMultiElement(collection, itemsPerPage, currentPage) {
            var html;
            $scope.collection = collection;
            $scope.itemsPerPage = itemsPerPage || 10;
            $scope.currentPage = currentPage || 1;
            html = '<div>' +
                '<div dir-paginate-start="item in collection | itemsPerPage: itemsPerPage" current-page="currentPage">header</div>' +
                '<p>{{ item }}</p>' +
                '<div dir-paginate-end>footer</div>' +
                '</div> ';
            containingElement.append($compile(html)($scope));
            $scope.$apply();
        }

        it('should compile with multi element syntax', function() {
            function compile() {
                compileMultiElement([]);
            }
            expect(compile).not.toThrow();
        });

        it('should display the list correctly', function() {
            compileMultiElement(myCollection, 3);
            expect(containingElement.find('p').length).toEqual(3);
        });

        it('should page correctly', function() {
            compileMultiElement(myCollection, 3);

            expect(containingElement.find('p').eq(0).html()).toEqual('item 1');

            $scope.$apply(function() {
                $scope.currentPage = 2;
            });

            expect(containingElement.find('p').eq(0).html()).toEqual('item 4');
        });

        it('should work with data-dir-paginate-start syntax', function() {
            function compile() {
                var html = '<div>' +
                    '<h1 data-dir-paginate-start="item in collection | itemsPerPage: 3">{{ item }}</h1>' +
                    '<p data-dir-paginate-end>stuff</p>' +
                    '</div> ';
                $scope.collection = myCollection;
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            expect(compile).not.toThrow();
            expect(containingElement.find('h1').length).toEqual(3);
            expect(containingElement.find('p').length).toEqual(3);
        });

        /**
         * See https://github.com/michaelbromley/angularUtils/issues/92
         */
        it('should correctly compile an inner ng-repeat', function() {
            function compile() {
                var html = '<div>' +
                    '<h1 dir-paginate-start="item in collection | itemsPerPage: 3" current-page="currentPage">{{ item }}</h1>' +
                    '<div dir-paginate-end> yo <ul class="options"><li ng-repeat="option in options">{{ option }} : {{ item }}</li></ul></div>' +
                    '</div> ';
                $scope.options = ['option1', 'option2', 'option3'];
                $scope.collection = myCollection;
                $scope.currentPage = 1;
                containingElement.append($compile(html)($scope));
                $scope.$apply();
            }

            compile();

            var options = containingElement.find('.options').eq(0).find('li');
            expect(options.length).toEqual(3);
            expect(options.eq(0).text()).toEqual('option1 : item 1');
        });
    });

    /**
     * THis suite tests out the ability to handle dynamically-generated pagination ids. The main use case is when
     * there are multiple dir-pagination instances being generated by an ng-repeat, and the pagination id is
     * only known at run-time.
     */
    describe('dynamic pagination ids', function() {
        function compile() {
            var html = '<div ng-repeat="list in lists"><ul class="list">' +
                '<li dir-paginate="item in list.collection | itemsPerPage: 3" pagination-id="list.id">{{ item }}</li>' +
                '</ul>' +
                '<dir-pagination-controls pagination-id="list.id"></dir-pagination-controls>' +
                '</div>';

            $scope.lists = [
                {
                    id: 'list1',
                    collection: [1, 2, 3, 4, 5]
                },
                {
                    id: 'list2',
                    collection: ['a', 'b', 'c', 'd', 'e']
                }
            ];
            containingElement.append($compile(html)($scope));
            $scope.$apply();
        }

        function getListItems($list) {
            return $list.find('li').map(function() {
                return $(this).text().trim();
            }).get();
        }

        it('should not throw an exception', function() {
            expect(compile).not.toThrow();
        });

        it('should allow independent pagination', function() {
            compile();

            var $list1 = containingElement.find('ul.list').eq(0);
            var $list2 = containingElement.find('ul.list').eq(1); 

            expect(getListItems($list1)).toEqual([ '1', '2', '3' ]);
            expect(getListItems($list2)).toEqual([ 'a', 'b', 'c' ]);

            // click the "page 2" link on the first set of pagination
            var pagination1 = $list1.parent().find('ul.pagination');
            pagination1.children().eq(2).find('a').triggerHandler('click');
            $scope.$apply();

            // ensure only the first set of pagination changes
            expect(getListItems($list1)).toEqual([ '4', '5' ]);
            expect(getListItems($list2)).toEqual([ 'a', 'b', 'c' ]);
        });

    });

    describe('paginationTemplateProvider', function() {

        beforeEach(inject(function($templateCache) {
            $templateCache.put('setPath_template', '<div class="set-path-template"><span>Test Template</span>{{ pages.length }}</div>');
            $templateCache.put('templateUrl_template', '<div class="template-url-template"><span>Test TemplateUrl Template</span>{{ pages.length }}</div>');
        }));

        it('should use the custom template specified by setPath()', function() {
            templateProvider.setPath('setPath_template');
            compileElement(myCollection, 10);

            expect(containingElement.find('.set-path-template').html()).toContain('Test Template');
        });

        it('should use the custom template specified by setString()', function() {
            templateProvider.setString('<div class="set-string-template"><span>Test Template String</span>{{ pages.length }}</div>');
            compileElement(myCollection, 10);

            expect(containingElement.find('.set-string-template').html()).toContain('Test Template String');
        });

        it('should prioritize setString() if both path and string have been set', function() {
            templateProvider.setString('<div class="set-string-template"><span>Test Template String</span>{{ pages.length }}</div>');
            templateProvider.setPath('setPath_template');
            compileElement(myCollection, 10);

            expect(containingElement.find('.set-path-template').html()).toBeUndefined();
            expect(containingElement.find('.set-string-template').html()).toContain('Test Template String');
        });

        it('should prioritize setString() over path and template-url attribute.', function() {
            templateProvider.setString('<div class="set-string-template"><span>Test Template String</span>{{ pages.length }}</div>');
            templateProvider.setPath('setPath_template');

            var html = '<ul class="list"><li dir-paginate="item in collection | itemsPerPage: itemsPerPage" current-page="currentPage">{{ item }}</li></ul> ' +
                '<dir-pagination-controls template-url="templateUrl_template"></dir-pagination-controls>';
            containingElement.append($compile(html)($scope));
            $scope.$apply();

            expect(containingElement.find('.set-path-template').html()).toBeUndefined();
            expect(containingElement.find('.template-url-template').html()).toBeUndefined();
            expect(containingElement.find('.set-string-template').html()).toContain('Test Template String');
        });

    });

});
