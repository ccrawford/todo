(function () {
    var app = angular.module("todoViewer");

    var NewTodoController = function ($scope, todo, $log, $location) {

        var onError = function (reason) {
            $scope.error = "Could not add the new ToDo";
        };

        var addTodoComplete = function (data) {
            $location.path("/todo/" + data.ToDoId);
        }

        $scope.addTodo = function () {
            todo.addTodo($scope.todo)
            .then(addTodoComplete, onError);
        };

    };

    app.controller("NewTodoController", NewTodoController);
}());