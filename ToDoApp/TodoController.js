

(function () {

    var app = angular.module("todoViewer");

    var TodoController = function ($scope, todo, $log, $routeParams) {

        var onTodoComplete = function (response) {
            $scope.todo = response.data;
        };

        var onError = function (reason) {
            $scope.error = "Could not get the data";
        };

        var onTodoEventsComplete = function (data) {
            $scope.todoEvents = data;
            $log.info("event data back. Response last complete: " + data.LastCompleted);

        };

        $scope.selectTodo = function (todoId) {
            $scope.getTodoEvents(todoId);
            $scope.currentTodo = todoId;
        };

        $scope.getTodoEvents = function (todoId) {
            $log.info("Getting todo events for " + todoId);
            todo.getTodoEvents(todoId)
                .then(onTodoEventsComplete, onError);
        };

        $scope.getSingleTodo = function (todoId) {
            todo.getTodo(todoId)
            .then(function (data) { $scope.todo = data; $scope.getTodoEvents(todoId); }, onError);
        };

        $scope.currentTodo = $routeParams.todoId;
        $scope.getSingleTodo($scope.currentTodo);

    };

    app.controller("TodoController", TodoController);

}());

