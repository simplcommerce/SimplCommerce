"use strict";

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    glob = require("glob");

var paths = {
    host: {
        wwwroot: "./wwwroot/",
        wwwrootModules: "./wwwroot/modules/",
        modules: "./Modules/"
    },
    dev: {
        modules: "../Modules/"
    }
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

gulp.task('clean-module', async function () {
    return gulp.src([paths.host.modules + '*', paths.host.wwwrootModules + '*'], { read: false })
        .pipe(clean());
});

gulp.task('copy-static', async function () {
    modules.forEach(function (module) {
        console.log('copying static contents ' + paths.dev.modules + module.id);
        gulp.src([paths.dev.modules + module.id + '/Views/**/*.*',
        paths.dev.modules + module.id + '/module.json'], { base: module.id })
            .pipe(gulp.dest(paths.host.modules + module.id));
        gulp.src(paths.dev.modules + module.id + '/wwwroot/**/*.*')
            .pipe(gulp.dest(paths.host.wwwrootModules + module.id.split(".").pop().toLowerCase()));
    });

    gulp.src(paths.dev.modules + 'SimplCommerce.Module.SampleData/SampleContent/**/*.*')
        .pipe(gulp.dest(paths.host.modules + 'SimplCommerce.Module.SampleData/SampleContent'));
});
