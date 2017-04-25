/// <binding AfterBuild='copy-modules' />
"use strict";

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    glob = require("glob"),
	rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    ignore = require('gulp-ignore'),
    del = require('del');

var mPaths = {
    devModules: "../Modules/",
    hostModules: "./Modules/",
    hostWwwrootModules: "./wwwroot/modules/"
};

var modules = loadModules();

var paths = {
    webroot: "./wwwroot/",
    bower: "./bower_components/"
};

var bower = {
    "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,woff2,eot}",
    "font-awesome": "components-font-awesome/**/*.{css,ttf,svg,woff,woff2,eot,otf}",
    "jquery": "jquery/dist/jquery*.{js,map}",
    "jquery-validation": "jquery-validation/dist/*.js",
    "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/*.js",
    "nouislider": "nouislider/distribute/*.{js,css}",
    "wnumb" : "wnumb/wNumb.js",
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
    "angular-ui-tree": "angular-ui-tree/dist/*.*"
};

gulp.task('clean-module', function () {
    return gulp.src([mPaths.hostModules + '*', mPaths.hostWwwrootModules + '*'], { read: false })
    .pipe(clean());
});

gulp.task('copy-modules', ['clean-module'], function () {
    modules.forEach(function (module) {
        gulp.src([mPaths.devModules + module.fullName + '/Views/**/*.*', mPaths.devModules + module.fullName + '/module.json'], { base: module.fullName })
            .pipe(gulp.dest(mPaths.hostModules + module.fullName));
        gulp.src(mPaths.devModules + module.fullName + '/bin/Debug/netstandard1.6/**/*.*')
            .pipe(gulp.dest(mPaths.hostModules + module.fullName + '/bin'));
        gulp.src(mPaths.devModules + module.fullName + '/wwwroot/**/*.*')
            .pipe(gulp.dest(mPaths.hostWwwrootModules + module.name));
    });

    gulp.src(mPaths.devModules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
            .pipe(gulp.dest(mPaths.hostModules + 'SimplCommerce.Module.SampleData/SampleContent'));
});

gulp.task('copy-static', function () {
    modules.forEach(function (module) {
        gulp.src([mPaths.devModules + module.fullName + '/Views/**/*.*', mPaths.devModules + module.fullName + '/module.json'], { base: module.fullName })
            .pipe(gulp.dest(mPaths.hostModules + module.fullName));
        gulp.src(mPaths.devModules + module.fullName + '/wwwroot/**/*.*')
            .pipe(gulp.dest(mPaths.hostWwwrootModules + module.name));
    });

    gulp.src(mPaths.devModules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
            .pipe(gulp.dest(mPaths.hostModules + 'SimplCommerce.Module.SampleData/SampleContent'));
});

function loadModules() {
    var moduleManifestPaths,
        modules = [];

    moduleManifestPaths = glob.sync(mPaths.devModules + 'SimplCommerce.Module.*/module.json', {});
    moduleManifestPaths.forEach(function (moduleManifestPath) {
        var moduleManifest = require(moduleManifestPath);
        modules.push(moduleManifest);
    });

    return modules;
}

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";
paths.lib = paths.webroot + "lib/";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:lib", function () {
    for (var desDir in bower) {
        del.sync(paths.lib + desDir);
    }
});

gulp.task("copy-lib", ["clean:lib"], function () {
    var ignoreComponents = [ "**/npm.js" ];

    for (var desDir in bower) {
        gulp.src(paths.bower + bower[desDir])
            .pipe(ignore.exclude(ignoreComponents))
            .pipe(gulp.dest(paths.lib + desDir));
    }
});

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
       // .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
