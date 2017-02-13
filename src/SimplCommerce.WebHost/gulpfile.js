/// <binding AfterBuild='copy-modules' />
"use strict";

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    glob = require("glob");

var paths = {
    devModules: "../Modules/",
    hostModules: "./Modules/",
    hostWwwrootModules: "./wwwroot/modules/"
};

var modules = loadModules();

gulp.task('clean-module', function () {
    return gulp.src([paths.hostModules + '*', paths.hostWwwrootModules + '*'], { read: false })
    .pipe(clean());
});

gulp.task('copy-modules', ['clean-module'], function () {
    modules.forEach(function (module) {
        gulp.src([paths.devModules + module.fullName + '/Views/**/*.*', paths.devModules + module.fullName + '/module.json'], { base: module.fullName })
            .pipe(gulp.dest(paths.hostModules + module.fullName));
        gulp.src(paths.devModules + module.fullName + '/bin/Debug/netstandard1.6/**/*.*')
            .pipe(gulp.dest(paths.hostModules + module.fullName + '/bin'));
        gulp.src(paths.devModules + module.fullName + '/wwwroot/**/*.*')
            .pipe(gulp.dest(paths.hostWwwrootModules + module.name));
    });

    gulp.src(paths.devModules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
            .pipe(gulp.dest(paths.hostModules + 'SimplCommerce.Module.SampleData/SampleContent'));
});

gulp.task('copy-static', function () {
    modules.forEach(function (module) {
        gulp.src([paths.devModules + module.fullName + '/Views/**/*.*', paths.devModules + module.fullName + '/module.json'], { base: module.fullName })
            .pipe(gulp.dest(paths.hostModules + module.fullName));
        gulp.src(paths.devModules + module.fullName + '/wwwroot/**/*.*')
            .pipe(gulp.dest(paths.hostWwwrootModules + module.name));
    });

    gulp.src(paths.devModules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
            .pipe(gulp.dest(paths.hostModules + 'SimplCommerce.Module.SampleData/SampleContent'));
});

function loadModules() {
    var moduleManifestPaths,
        modules = [];

    moduleManifestPaths = glob.sync(paths.devModules + 'SimplCommerce.Module.*/module.json', {});
    moduleManifestPaths.forEach(function (moduleManifestPath) {
        var moduleManifest = require(moduleManifestPath);
        modules.push(moduleManifest);
    });

    return modules;
}
