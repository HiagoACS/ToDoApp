angular.module('todoApp').service('todoService', function($http) {
	const baseUrl = 'https://localhost:44312/api/todo';

	this.getTodos = function(){
		return $http.get(baseUrl);
	};

	this.addTodo = function(todo) {
		return $http.post(baseUrl, todo);
	};

	this.updateTodo = function(todo) {
		return $http.put(`${baseUrl}/${todo.Id}`, todo);
	};

	this.deleteTodo = function(id) {
		return $http.delete(`${baseUrl}/${id}`);
	};

	this.deleteCompleted = function() {
		return $http.delete(`${baseUrl}/deleteallcompleted`);
	};

	this.deleteAll = function() {
		return $http.delete(`${baseUrl}/deleteall`);
	};
});