/// <binding AfterBuild='copy-modules' />
"use strict";

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    ignore = require('gulp-ignore'),
    glob = require("glob"),
    rimraf = require("rimraf");

var paths = {
    host: {
        wwwroot: "./wwwroot/",
        wwwrootModules: "./wwwroot/modules/",
        modules: "./Modules/",
        moduleBin: "/bin/",
        bower: "./bower_components/"
    },
    dev: {
        modules: "../Modules/",
        moduleBin: "/bin/Debug/netcoreapp2.0/"
    }
};

paths.host.js = paths.host.wwwroot + "js/**/*.js";
paths.host.minJs = paths.host.wwwroot + "js/**/*.min.js";
paths.host.css = paths.host.wwwroot + "css/**/*.css";
paths.host.minCss = paths.host.wwwroot + "css/**/*.min.css";
paths.host.concatJsDest = paths.host.wwwroot + "js/site.min.js";
paths.host.concatCssDest = paths.host.wwwroot + "css/site.min.css";
paths.host.lib = paths.host.wwwroot + "lib/";

var bower = {
    "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,woff2,eot}",
    "font-awesome": "components-font-awesome/**/*.{css,ttf,svg,woff,woff2,eot,otf}",
    "jquery": "jquery/dist/jquery*.{js,map}",
    "jquery-validation": "jquery-validation/dist/*.js",
    "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/*.js",
    "nouislider": "nouislider/distribute/*.{js,css}",
    "wnumb": "wnumb/wNumb.js",
    "angular": "angular/angular.js",
    "angular-animate": "angular-animate/angular*.js",
    "angular-aria": "angular-aria/angular*.js",
    "angular-material": "angular-material/angular-material*.{js,css}",
    "angular-messages": "angular-messages/angular-messages.js",
    "angular-ui-router": "angular-ui-router/release/*.js",
    "angular-smart-table": "angular-smart-table/dist/*.js",
    "ng-file-upload": "ng-file-upload/ng-file-upload.js",
    "summernote": "summernote/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
    "angular-summernote": "angular-summernote/dist/*.js",
    "angular-bootstrap": "angular-bootstrap/ui-bootstrap*",
    "matchheight": "matchheight/dist/*.js",
    "toastr": "toastr/toastr*.{js,css}",
    "bootbox": "bootbox/bootbox*.{js,css}",
    "angular-ui-tree": "angular-ui-tree/dist/*.*",
    "angular-bootstrap-colorpicker": "angular-bootstrap-colorpicker/{js,css,img}/*.*"
};

var modules = loadModules();

function loadModules() {
    var moduleManifestPaths,
        modules = [];

    moduleManifestPaths = glob.sync(paths.dev.modules + '*.*/module.json', {});
    moduleManifestPaths.forEach(function (moduleManifestPath) {
        var moduleManifest = require(moduleManifestPath);
        modules.push(moduleManifest);
    });

    return modules;
}

gulp.task('clean-module', function () {
    return gulp.src([paths.host.modules + '*', paths.host.wwwrootModules + '*'], { read: false })
        .pipe(clean());
});

gulp.task('copy-static', function () {
    modules.forEach(function (module) {
        gulp.src([paths.dev.modules + module.fullName + '/Views/**/*.*',
        paths.dev.modules + module.fullName + '/module.json'], { base: module.fullName })
            .pipe(gulp.dest(paths.host.modules + module.fullName));
        gulp.src(paths.dev.modules + module.fullName + '/wwwroot/**/*.*')
            .pipe(gulp.dest(paths.host.wwwrootModules + module.name));
    });

    gulp.src(paths.dev.modules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
        .pipe(gulp.dest(paths.host.modules + 'SimplCommerce.Module.SampleData/SampleContent'));
});

gulp.task('copy-modules', ['clean-module'], function () {
    gulp.start(['copy-static']);

    modules.forEach(function (module) {
        gulp.src(paths.dev.modules + module.fullName + paths.dev.moduleBin + '**/*.*')
            .pipe(gulp.dest(paths.host.modules + module.fullName + paths.host.moduleBin));
    });
});

gulp.task("clean:js", function (cb) {
    rimraf(paths.host.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.host.concatCssDest, cb);
});

gulp.task("clean:lib", function () {
    for (var desDir in bower)
        rimraf.sync(paths.host.lib + desDir);
});

gulp.task("copy-lib", ["clean:lib"], function () {
    var ignoreComponents = ["**/npm.js"];

    for (var desDir in bower)
        gulp.src(paths.host.bower + bower[desDir])
            .pipe(ignore.exclude(ignoreComponents))
            .pipe(gulp.dest(paths.host.lib + desDir));
});

gulp.task("min:js", function () {
    return gulp.src([paths.host.js, "!" + paths.host.minJs], { base: "." })
        .pipe(concat(paths.host.concatJsDest))
        // .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.host.css, "!" + paths.host.minCss])
        .pipe(concat(paths.host.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);