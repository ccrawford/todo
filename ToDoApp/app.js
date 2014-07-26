(function () {
    var app = angular.module("todoViewer", ["angularMoment", "ngRoute", "ui.bootstrap"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/main", {
                templateUrl: "main.html",
                controller: "MainController"
            })
            .when("/todo/:todoId", {
                templateUrl: "todo.html",
                controller: "TodoController"
            })
            .when("/newTodo", {
                templateUrl: "newTodo.html",
                controller: "NewTodoController"
            })
            .otherwise({ redirectTo: "/main" });
    });
}());