'use strict';
(function () {
    var app = angular.module("App",
        [
            'ngRoute',
            'ui.bootstrap',
            "App.Controllers",
            "App.Services",
            "App.Filters"
            //"App.Directives"
        ]);
    app.config(['$stateProvider', function ($routeProvider) {
        var route = $routeProvider
            .when("/users/list", { controller: 'users', templateUrl: '/App/views/users/list.html' })
            .when("/users/form", { controller: 'usersForm', templateUrl: '/App/views/users/form.html' })
            .when("/users/form/:id", { redirectTo: '/users/form' })
            .when("/roles/list", { controller: 'roles', templateUrl: '/App/views/roles/list.html' })
            .when("/roles/form", { controller: 'rolesForm', templateUrl: '/App/views/roles/form.html' })
            .when("/roles/form/:id", { redirectTo: '/roles/form' })
            .when("/", { redirectTo: '/users/list' })
            .otherwise({ templateUrl: '/App/views/utils/404.html' });
    }
    ]);

})();