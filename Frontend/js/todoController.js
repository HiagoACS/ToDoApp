angular.module('todoApp').controller('todoController', ['todoService', '$window', '$timeout', function(todoService, $window, $timeout){
  var vm = this;

  // estado
  vm.todos = [];
  vm.newTodoTitle = '';
  vm.filterMode = 'all';
  vm.editing = null;
  vm.editText = '';

  vm.load = function(){
    todoService.getTodos().then(function(response){
      vm.todos = response.data;
    }, function(error){
      console.error('Erro ao carregar tarefas:', error)
    });
  };

  vm.addTodo = function(){
    var title = (vm.newTodoTitle || '').trim();
    if(!title) return;
    var newTodo = {Title : title, IsCompleted: false};
    todoService.addTodo(newTodo).then(function(response){ 
      vm.todos.unshift(response.data);
      vm.newTodoTitle = '';
    }, function(error){
      console.error('Erro ao adicionar tarefa:', error);
    });
  };

  vm.remove = function(todo){
    todoService.deleteTodo(todo.Id).then(function(){
      var i = vm.todos.indexOf(todo);
      if(i > -1) vm.todos.splice(i,1);
    }, function(error){
      console.error('Erro ao remover tarefa:', error);
    });
  };

  vm.toggleComplete = function(todo){
    todo.IsCompleted = !todo.IsCompleted;
    todoService.updateTodo(todo).then(function(){}, function(error){
      console.error('Erro ao atualizar tarefa:', error);
    });
  };

  vm.clearCompleted = function(){
    todoService.deleteCompleted().then(function(){
      vm.load();
    });
  };

  vm.clearAll = function(){
    if($window.confirm('Remover todas as tarefas? Isso não pode ser desfeito.')){
      todoService.deleteAll().then(function(){
        vm.load();
      });
    }
  };

  vm.startEdit = function(todo){
    vm.editing = todo.Id;
    vm.editText = todo.Title;
    $timeout(function(){
      var el = document.querySelector('input[autofocus]');
      if(el) el.focus();
    }, 0);
  };

  vm.saveEdit = function(todo){
    var text = (vm.editText || '').trim();
    if(!text) vm.remove(todo);
    else {
      todo.Title = text;
      todoService.updateTodo(todo).then(function(){}, function(error){
        console.error('Erro ao salvar edição:', error)
      });
    }
    vm.editing = null;
    vm.editText = '';
  };

  vm.editKey = function(e, todo){
    if(e.key === 'Enter') vm.saveEdit(todo);
    if(e.key === 'Escape'){ vm.editing = null; vm.editText = ''; }
  };

  vm.setFilter = function(mode){ vm.filterMode = mode; };

  vm.visibleTodos = function(){
    if(vm.filterMode === 'active') return vm.todos.filter(function(t){ return !t.IsCompleted; });
    if(vm.filterMode === 'completed') return vm.todos.filter(function(t){ return t.IsCompleted; });
    return vm.todos;
  };

  vm.remainingCount = function(){ return vm.todos.filter(function(t){ return !t.IsCompleted; }).length; };
  vm.totalCount = function(){ return vm.todos.length; };

  vm.keyPressed = function(e){ if(e.key === 'Enter') vm.addTodo(); };

  // inicializa
  vm.load();
}]);
