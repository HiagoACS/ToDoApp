angular.module('todoApp').controller('todoController', function(){
	var vm = this;

	//Lista inicial de tarefas (simulando)
	vm.todos = [
		{ Title: 'Angular JS', IsCompleted: false},
		{ Title: 'C#', IsCompleted : true},
		{ Title : 'Estudar', IsCompleted : true}
	];
});