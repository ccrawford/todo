(function () {

    var apiUri = "http://localhost:63711/api/";

    var todo = function($http) {

        var getTodo = function (todoId) {
            return $http.get(apiUri + "todos/" + todoId)
            .then(function (response) { return response.data; });
        };

        var getTodoEvents = function (todoId) {
            return $http.get(apiUri + "todos/" + todoId + "/events")
                .then(function (response) { return response.data; });
        };

        var getAllTodos = function () {
            return $http.get(apiUri + "todos/")
                .then(function (response) { return response.data; });
        };
        
        var onAddTodoComplete = function (response) {
            return response.data;
        }
        var addTodo = function (newTodo) {
            return $http.post(apiUri + "todos/", newTodo)
                .then(onAddTodoComplete);
        };

        var addEvent = function (newEvent) {
            return $http.post(apiUri + "todos/0/event", newEvent)
                .then(function (response) { return response.data; });
        };

        var deleteTodo = function (todoId) {
            return $http.delete(apiUri + "todos/" + todoId)
                .then(function (response) { return response.data; });
        }


        return {
            getTodo: getTodo,
            getAllTodos: getAllTodos,
            getTodoEvents: getTodoEvents,
            addTodo: addTodo,
            addEvent: addEvent,
            deleteTodo: deleteTodo
        };

    };

    var module = angular.module("todoViewer"); // Get reference to module
    module.factory("todo", todo);

}());