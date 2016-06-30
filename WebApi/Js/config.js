app.config(function ($routeProvider /*, $locationProvider*/) {

    //$locationProvider.html5Mode(true);

    $routeProvider
        .when("/",
        {
            templateUrl: "/Html/index.html",
            controller: "IndexCtrl"
        })
        .when("/login",
        {
            templateUrl: "/Html/login.html",
            controller: "LoginCtrl"
        });

    /*.otherwise({ redirectTo: '/' });*/
});