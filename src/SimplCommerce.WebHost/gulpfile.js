"use strict";

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    glob = require("glob"),
    argv = require('yargs').argv;

var buildConfigurationName = argv.configurationName || 'Debug';

var paths = {
    host: {
        wwwroot: "./wwwroot/",
        wwwrootModules: "./wwwroot/modules/",
        modules: "./Modules/",
        moduleBin: "/bin/"
    },
    dev: {
        modules: "../Modules/",
        moduleBin: "/bin/" + buildConfigurationName +"/netcoreapp2.1/"
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

gulp.task('clean-module', function () {
    return gulp.src([paths.host.modules + '*', paths.host.wwwrootModules + '*'], { read: false })
        .pipe(clean());
});

gulp.task('copy-static', function () {
    modules.forEach(function (module) {
        console.log('copying static contents ' + paths.dev.modules + module.fullName);
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
        if (!module.isBundledWithHost) {
            console.log('copying ' + paths.dev.modules + module.fullName + paths.dev.moduleBin);
            gulp.src(paths.dev.modules + module.fullName + paths.dev.moduleBin + '**/*.*')
                .pipe(gulp.dest(paths.host.modules + module.fullName + paths.host.moduleBin));
        }
    });
});
