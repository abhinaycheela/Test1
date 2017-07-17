/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': '/node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: 'src/jscode',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',

            // other libraries
            'rxjs': 'npm:rxjs',

            // add ng2-daterangepicker bundles
            'ng2-daterangepicker': 'npm:ng2-daterangepicker',
            'jquery': 'npm:jquery/dist/jquery.js',
            'moment': 'npm:moment',
            'bootstrap-daterangepicker': 'npm:bootstrap-daterangepicker/daterangepicker.js'

        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: './main.js',
                defaultExtension: 'js'
            },
            rxjs: {
                defaultExtension: 'js'
            },
            // ng2-daterangepicker packages
            moment: {
                main: 'moment',
                defaultExtension: 'js'
            },
            'ng2-daterangepicker': {
                main: 'index',
                defaultExtension: 'js'
            }

        }
    });
})(this);