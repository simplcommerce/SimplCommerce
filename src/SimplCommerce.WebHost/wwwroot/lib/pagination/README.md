# Pagination Directive

### No longer maintained
(20/04/2017) - I am no longer actively maintaining this project. I no longer use AngularJS in my own projects and do not have the time to dedicate to maintiaining this project as well as my other active open source projects. Thank you for your understanding.

---

## Another one?

Yes, there are quite a few pagination solutions for Angular out there already, but what I wanted to do was make
something that would be truly plug-n-play - no need to do any set-up or logic in your controller. Just add
an attribute, drop in your navigation wherever you like, and boom - instant, full-featured pagination.

(**Looking for the Angular2 version? [Right here!](https://github.com/michaelbromley/ng2-pagination)**)

## Demo

[Here is a working demo on Plunker](http://plnkr.co/edit/Wtkv71LIqUR4OhzhgpqL?p=preview) which demonstrates some cool features such as live-binding the "itemsPerPage" and
filtering of the collection.

# Table of Contents

- [Basic Example](#basic-example)
- [Installation](#installation)
- [Usage](#usage)
	- [Specifying The Template](#customising--specifying-the-template)
- [Directives API](#directives-api)
	- [dir-paginate](#dir-paginate)
	- [dir-pagination-controls](#dir-pagination-controls)
- [Writing A Custom Pagination-Controls Template](#writing-a-custom-pagination-controls-template)
- [Special Repeat Start and End Points](#special-repeat-start-and-end-points)
- [Multiple Pagination Instances on One Page](#multiple-pagination-instances-on-one-page)
    - [Multiple Instances With ngRepeat](#multiple-instances-with-ngrepeat)
	- [Demo](#demo-1)
- [Working With Asynchronous Data](#working-with-asynchronous-data)
	- [Example Asynchronous Setup](#example-asynchronous-setup)
- [Styling](#styling)
- [FAQ](#frequently-asked-questions)
- [Contribution](#contribution)
- [Changelog](#changelog)
- [Credits](#credits)

## Basic Example

Let's say you have a collection of items on your controller's `$scope`. Often you want to display them with
the `ng-repeat` directive and then paginate the results if there are too many to fit on one page. This is what this
module will enable:

```HTML
<ul>
    <li dir-paginate="item in items | itemsPerPage: 10">{{ item }}</li>
</ul>

// then somewhere else on the page ....

<dir-pagination-controls></dir-pagination-controls>
```

...and that's literally it.

## Installation

You can install with Bower:

`bower install angular-utils-pagination`

or npm:

`npm install angular-utils-pagination`

Alternatively just download the files `dirPagination.js` and `dirPagination.tpl.html`. Using Bower or npm has the advantage of making version management easier.

## Usage

First you need to include the module in your project:

```JavaScript
// in your app
angular.module('myApp', ['angularUtils.directives.dirPagination']);
```

Then create the paginated content:
```HTML
<ANY
    dir-paginate="expression | itemsPerPage: (int|expression) [: paginationId (string literal)]"
    [current-page=""]
    [pagination-id=""]
    [total-items=""]>
    ...
    </ANY>
```
And finally include the pagination itself.


```HTML
...
<dir-pagination-controls
    [max-size=""]
    [direction-links=""]
    [boundary-links=""]
    [on-page-change=""]
    [pagination-id=""]
    [template-url=""]
    [auto-hide=""]>
    </dir-pagination-controls>
```

### Customising & Specifying The Template

By default, the pagination controls will use a built-in template which uses the exact same markup as is found in the
dirPagination.tpl.html file (which conforms to Bootstrap's pagination markup). Therefore, it is not necessary to specify a template.

However, you may not want to use the default embedded template - for example if you use a another CSS framework that
expects pagination lists to have a particular structure different from the default.

If you plan to use a custom template, take a look at the default as demonstrated in dirPagination.tpl.html to get
an idea of how it interacts with the directive.

There are three ways to specify the template of the pagination controls directive:

**1. Use the `paginationTemplateProvider` in your app's config block to set a global templateUrl for your app:**

```JavaScript
myApp.config(function(paginationTemplateProvider) {
    paginationTemplateProvider.setPath('path/to/dirPagination.tpl.html');
});
```

**2. Use the `paginationTemplateProvider` in your app's config block to set a global template string for your app:**

```JavaScript
myApp.config(function(paginationTemplateProvider) {
    paginationTemplateProvider.setString('<div class="my-page-links">...</div>');
    
    // or with e.g. Webpack you might do
    paginationTemplateProvider.setString(require('/path/to/customPagination.tpl.html'));
});
```

**3. Use the `template-url` attribute on each pagination controls directive:**

```HTML
<dir-pagination-controls template-url="path/to/dirPagination.tpl.html"></dir-pagination-controls>
```

#### Template Priority

If you use more than one method for specifying the template, the actual template to use will be decided based on
the following order of precedence (highest priority first):

1. `paginationTemplate.getString()`
2. `template-url`
3. `paginationTemplate.getPath()`
4. (default built-in template)

## Directives API

The following attributes form the API for the pagination and pagination-controls directives. Optional attributes are marked as such,
otherwise they are required.

### `dir-paginate`

* **`expression`** Under the hood, this directive delegates to the `ng-repeat` directive, so the syntax for the
expression is exactly as you would expect. [See the ng-repeat docs for the full rundown](https://docs.angularjs.org/api/ng/directive/ngRepeat).
This means that you can also use any kind of filters you like, etc.

* **`itemsPerPage`** The `expression` **must** include this filter. It is required by the pagination logic. The syntax
is the same as any filter: `itemsPerPage: 10`, or you can also bind it to a property of the $scope: `itemsPerPage: pageSize`. **Note:** This filter should come *after* any other filters in order to work as expected. A safe rule is to always put it at the end of the expression.
The optional third argument `paginationId` is used when you need more than one independent pagination instance on one page. See the section below
on setting up multiple instances.

* **`current-page`** (optional) Specify a property on your controller's $scope that will be bound to the current
page of the pagination. If this is not specified, the directive will automatically create a property named `__default__currentPage` and use
that instead.

* **`pagination-id`** (optional) Used to group together the dir-paginate directive with a corresponding dir-pagination-controls when you need more than
one pagination instance per page. See the section below on setting up multiple instances.

* **`total-items`** When working with asynchronous data (i.e. data that is paginated on the server and sent one page at a time to the client), you would be sent
only one page of results and then some meta-data containing the total number of results. In this case, the pagination directive would think that your one page
of result was the full dataset, and therefore no pagination is needed. To prevent the default behaviour, you need to specify the `total-items` attribute, which
will then be used to calculate the pagination. For more information see the section on working with asynchronous data below.

### `dir-pagination-controls`

* **`max-size`** (optional, default = 9) Specify a maximum number of pagination links to display. The default is 9, and
the minimum is 5 (setting a lower value than 5 will not have an effect).

* **`direction-links`** (optional, default = true) Specify whether to display the "forwards" & "backwards" arrows in the
pagination.

* **`boundary-links`** (optional, default = false) Specify whether to display the "start" & "end" arrows in the
pagination.

* **`on-page-change`** (optional, default = null) Specify a callback method to run each time one of the pagination links is clicked. The method will be passed the
optional arguments `newPageNumber` and `oldPageNumber`, which are integers equal to the page number that has just been navigated to, and the one just left, respectively. **Note** you must use that exact argument name in your view,
i.e. `<dir-pagination-controls on-page-change="myMethod(newPageNumber, oldPageNumber)">`, and the method you specify must be defined on your controller $scope.

* **`pagination-id`** (optional) Used to group together the dir-pagination-controls with a corresponding dir-paginate when you need more than
one pagination instance per page. See the section below on setting up multiple instances.

* **`template-url`** (optional, default = `directives/pagination/dirPagination.tpl.html`) Specifies the template to use.

* **`auto-hide`** (optional, default = true) Specify whether the dir-pagination-controls should be hidden when there's not enough elements to paginate over.

Note: you cannot use the `dir-pagination-controls` directive without `dir-paginate`. Attempting to do so will result in an
exception.

## Writing A Custom Pagination-Controls Template

The default template ([dirPagination.tpl.html](dirPagination.tpl.html)) is based on the [Bootstrap pagination markup](http://getbootstrap.com/components/#pagination). If you wish to modify the template or write your own,
there are a few useful values exposed by the directive which you can use:

- `pages` The array of page numbers, typically used in an `ng-repeat` to generate the individual page links.
- `{{ pagination.current }}` The current page.
- `{{ pagination.last }}` The number of the last page in the collection.
- `{{ range.lower }}` The ordinal number of the first item on the current page. E.g. assuming 10 items per page, when on page 2 this will equal 11.
- `{{ range.upper }}` The ordinal number of the last item on the current page. E.g. assuming 10 items per page, when on page 2 this will equal 20.
- `{{ range.total }}` The total number of items in the collection.

The three `range` values can be used to generate a label like *"Displaying 16-20 of 53 items"*.

Here is an example of a custom template which uses the range values along with "previous" and "next" arrow links, but no page links:

```HTML
<div class="range-label">Displaying {{ range.lower }} - {{ range.upper }} of {{ range.total }}</div>

<a href="" title="Previous page" ng-class="{ disabled : pagination.current == 1 }" ng-click="setCurrent(pagination.current - 1)">&lsaquo;</a>
<a href="" title="Next page"  ng-class="{ disabled : pagination.current == pagination.last }" ng-click="setCurrent(pagination.current + 1)">&rsaquo;</a>
```

To use a custom template in your app, see the section on [specifying the template](#specifying-the-template).

## Special Repeat Start and End Points

As with the [ngRepeat directive](https://docs.angularjs.org/api/ng/directive/ngRepeat#special-repeat-start-and-end-points), you can use the `-start` and `-end` suffix on the `dir-paginate` directive to
repeat a series of elements instead of just one parent element:

```HTML
<header dir-paginate-start="item in items | itemsPerPage: 10">
    Header {{ item }}
</header>
<div class="body">
  Body {{ item }}
</div>
<footer dir-paginate-end>
  Footer {{ item }}
</footer>
```

## Multiple Pagination Instances on One Page

Multiple instances of the directives may be included on a single page by specifying a `pagination-id`. This property **must** be specified in **2** places
for this to work:

1. Specify the `pagination-id` attribute on the `dir-paginate` directive.
3. Specify the `pagination-id` attribute on the `dir-paginations-controls` directive.

**Note:** Prior to version 0.5.0, there was an additional requirement to add the ID as a second parameter of the `itemsPerPage` filter. This is now no longer required, as the
directive will add this parameter automatically. Old code that *does* explicitly declare the ID in the filter will still work.

An example of two independent paginations on one page would look like this:

```HTML
<!-- first pagination instance -->
<ul>
    <li dir-paginate="customer in customers | itemsPerPage: 10" pagination-id="cust">{{ customer.name }}</li>
</ul>

<dir-pagination-controls pagination-id="cust"></dir-pagination-controls>

<!-- second pagination instance -->
<ul>
    <li dir-paginate="branch in branches | itemsPerPage: 10" pagination-id="branch">{{ customer.name }}</li>
</ul>

<dir-pagination-controls pagination-id="branch"></dir-pagination-controls>
```

The pagination-ids above are set to "cust" in the first instance and "branch" in the second. The pagination-ids can be any [valid JavaScript identifier](https://mathiasbynens.be/notes/javascript-identifiers) (i.e. no hyphens, cannot begin with a number etc. [further discussion here](http://www.michaelbromley.co.uk/blog/410/a-note-on-angular-expressions-and-javascript-identifiers)),
the important thing is to make sure the exact same id is used on both the pagination and the controls directives. If the 2 ids don't match, you should see a helpful
exception in the console.

### Multiple Instances With ngRepeat

You can use the pagination-id feature to dynamically create pagination instances, for example inside an `ng-repeat` block. Here is a bare-bones example to
demonstrate how that would work:

```JavaScript
// in the controller
$scope.lists = [
    {
        id: 'list1',
        collection: [1, 2, 3, 4, 5]
    },
    {
        id: 'list2',
        collection: ['a', 'b', 'c', 'd', 'e']
    }];
```

```HTML
<!-- the view -->
<div ng-repeat="list in lists">
    <ul>
        <li dir-paginate="item in list.collection | itemsPerPage: 3" pagination-id="list.id">ID: {{ list.id }}, item: {{ item }}</li>
    </ul>
    <dir-pagination-controls pagination-id="list.id"></dir-pagination-controls>
</div>
```

### Demo

Here is a working demo featuring two instances on one page: [http://plnkr.co/edit/xmjmIId0c9Glh5QH97xz?p=preview](http://plnkr.co/edit/xmjmIId0c9Glh5QH97xz?p=preview)


## Working With Asynchronous Data

The arrangement described above works well for smaller collections, but once your data set reaches a certain size, you may not want to have to get the entire collection
from the server just to view a few pages. The solution to this is to paginate on the server-side, whereby the server will only send one page of data at a time. In this case,
the directive would see the small (one page) data set and think that was all, resulting in no pagination at all (assuming you set the `itemsPerPage` filter to match the number
of items returned per server-side page).

The solution is to use the `total-items` attribute on the `dir-paginate` directive. Commonly, in such a server-side paging scenario, the server would also return some meta-data
along with the result set, specifying the total number of results. A typical example would look like this:

```JavaScript
{
    Count: 1400,
    Items: [
        { // item 1... },
        { // item 2... },
        { // item 3... },
        ...
        { // item 25... }
    ]
}
```

In this case, the server is returning the first *page* - 25 results - of a set that totals 1400 results. Therefore we must tell the directive that, even though it can only see
25 items in the collection right now, there are actually a total of 1400 items, so it should therefore make 1400/25 = **56** pagination links.

Of course, once the user clicks on page 2, you will need to make a new request to the server to fetch the results for page 2. This will have to be implemented by you in your
controller, but you will want to either 1) use the `on-page-change` callback to trigger the request or 2) set up a $watch on the property you specified in the `current-page`
attribute. Either of those methods will allow you to call a function whenever the page changes, which will fetch the new page of results. The second method has the
potential advantage of being triggered whenever the current-page changes, rather than only when the pagination links are clicked.

### Example Asynchronous Setup

```JavaScript
.controller('UsersController', function($scope, $http) {
    $scope.users = [];
    $scope.totalUsers = 0;
    $scope.usersPerPage = 25; // this should match however many results your API puts on one page
    getResultsPage(1);

    $scope.pagination = {
        current: 1
    };

    $scope.pageChanged = function(newPage) {
        getResultsPage(newPage);
    };

    function getResultsPage(pageNumber) {
        // this is just an example, in reality this stuff should be in a service
        $http.get('path/to/api/users?page=' + pageNumber)
            .then(function(result) {
                $scope.users = result.data.Items;
                $scope.totalUsers = result.data.Count
            });
    }
})
```

```HTML
<div ng-controller="UsersController">
    <table>
        <tr dir-paginate="user in users | itemsPerPage: usersPerPage" total-items="totalUsers" current-page="pagination.current">
            <td>{{ user.name }}</td>
            <td>{{ user.email }}</td>
        </tr>
    </table>

    <dir-pagination-controls on-page-change="pageChanged(newPageNumber)"></dir-pagination-controls>
</div>
````

## Styling

I've based the pagination navigation on the Bootstrap 3 component, so if you use Bootstrap in your project,
you'll get some nice styling for free. If you don't use Bootstrap, it's simple to style the links with css.

## Frequently Asked Questions

### Why does my sort / filter only affect the current page?
This is a common problem and is usually due to the `itemsPerPage` filter not being at the end of the expression. For example, consider the following:

```HTML
<li dir-paginate="item in collection | itemsPerPage: 10 | filter: q">...</li> <!-- BAD -->
```

In this case, the collection is first truncated to 10 items by the `itemsPerPage` filter, and then *those 10 items only* are filtered. The solution is to ensure the `itemsPerPage` filter comes after any sorting / filtering:

```HTML
<li dir-paginate="item in collection | filter: q | itemsPerPage: 10">...</li> <!-- GOOD -->
```

### What is the `paginationService` and why is it not documented?

The [`paginationService`](https://github.com/michaelbromley/angularUtils/blob/6055d260be44c0ba221a8c9bea015ac97e836a10/src/directives/pagination/dirPagination.js#L466-L521) is used internally to facilitate communication between the instances of the `dir-pagination` and `dir-pagination-controls` directives. Due to the way Angular's dependency injection system works, the service will be exposed in your app, meaning you can inject it directly into your controllers etc.

However, since the `paginationService` is intended as an internal service, I cannot make any guarantees about the API, so it is dangerous to rely on using it directly in your code. Therefore I am not documenting it currently, so as not to encourage its general use. If you have a case that you feel can only be solved by direct use of this API, please open an issue and we can discuss it.

## Contribution

Pull requests are welcome. If you are adding a new feature or fixing an as-yet-untested use case, please consider
writing unit tests to cover your change(s). All unit tests are contained in the `dirPagination.spec.js` file, and
Karma is set up if you run `grunt watch` as you make changes.

At a minimum, make sure that all the tests still pass. Thanks!

## Changelog

Please see the [releases page of the package repo](https://github.com/michaelbromley/angularUtils-pagination/releases) for details
of each released version.

## Credits

I did quite a bit of research before I figured I needed to make my own directive, and I picked up a lot of good ideas
from various sources:

* Daniel Tabuenca: https://groups.google.com/d/msg/angular/an9QpzqIYiM/r8v-3W1X5vcJ. This is where I learned how to
delegate to the ng-repeat directive from within my own, and I used some of the code he gives here.

* AngularUI Bootstrap: https://github.com/angular-ui/bootstrap. I used a few ideas, and a couple of attribute names,
from their pagination directive.

* StackOverflow: http://stackoverflow.com/questions/10816073/how-to-do-paging-in-angularjs. Picked up a lot of ideas
from the various contributors to this thread.

* Massive credit is due to all the [contributors](https://github.com/michaelbromley/angularUtils/graphs/contributors) to this project - they have brought improvements that I would not have the time or insight to figure out myself.

## License

MIT
