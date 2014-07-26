

(function () {

    var app = angular.module("todoViewer");

    var MainController = function ($scope, todo, $log, $location) {

        var onTodoComplete = function (response) {
            $scope.todo = response.data;
        };

        var onAllTodosComplete = function (data) {
            $scope.todos = data;
        };

        var onError = function (reason) {
            $scope.error = "Could not get the data";
        };


        var onTodoEventsComplete = function (data) {
            $scope.todoEvents = data;
            $log.info("event data back. Response last complete: " + data.LastCompleted);
            
        };

        var onAddEventComplete = function (data) {
            $scope.getTodoEvents($scope.currentTodo);
            $log.info(data);
            return data;
        }

        $scope.addEvent = function () {
            $scope.todoEvent.todoId = $scope.currentTodo;
            todo.addEvent($scope.todoEvent)
            .then(onAddEventComplete, onError);
        };

        // $scope.addTodo = function () {
        //    todo.addTodo($scope.todo)
        //    .then(function (data) { $scope.getAllTodos(); return data; }, onError);
        // };

        var onDeleteComplete = function () {
            $scope.currentTodo = null;
            $scope.getAllTodos();
        };

        $scope.deleteTodo = function (todoId) {
            todo.deleteTodo(todoId)
                .then(onDeleteComplete, onError);
        };

        $scope.selectTodo = function (todoId) {
            $location.path("/todo/" + todoId);
            //$scope.getTodoEvents(todoId);
            //$scope.currentTodo = todoId;
        };

        $scope.getTodoEvents = function (todoId) {
            $log.info("Getting todo events for " + todoId);
            todo.getTodoEvents(todoId)
                .then(onTodoEventsComplete, onError);
        };

        $scope.getSingleTodo = function (todoId) {
            todo.getSingleTodo(todoId)
            .then(function (data) { $scope.todo = data; }, onError);
        };

        $scope.getAllTodos = function () {
            todo.getAllTodos().then(onAllTodosComplete, onError);
        }

        $scope.curDate = new Date();
        $scope.todoEvent = {occurredDttm: Date()};
        $scope.getAllTodos();

    };

    app.controller("MainController", MainController);

}());

