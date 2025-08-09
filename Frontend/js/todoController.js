angular.module('todoApp').controller('todoController', ['todoStorage', '$window', '$timeout', function(todoStorage, $window, $timeout){
  var vm = this;

  // estado
  vm.todos = [];
  vm.newTodoTitle = '';
  vm.filterMode = 'all';
  vm.editing = null;
  vm.editText = '';

  function guid(){ return 'id-' + Math.random().toString(36).slice(2,9); }

  vm.load = function(){
    var saved = todoStorage.load();
    if(saved && saved.length){
      vm.todos = saved;
    } else {
      vm.todos = [
        { Id: guid(), Title: 'Aprender AngularJS', IsCompleted:false },
        { Id: guid(), Title: 'Preparar backend .NET', IsCompleted:true }
      ];
      todoStorage.save(vm.todos);
    }
  };

  vm.save = function(){ todoStorage.save(vm.todos); };

  vm.addTodo = function(){
    var title = (vm.newTodoTitle || '').trim();
    if(!title) return;
    vm.todos.unshift({ Id: guid(), Title: title, IsCompleted:false });
    vm.newTodoTitle = '';
    vm.save();
  };

  vm.remove = function(todo){
    var i = vm.todos.indexOf(todo);
    if(i>-1){ vm.todos.splice(i,1); vm.save(); }
  };

  vm.toggleComplete = function(todo){
    todo.IsCompleted = !todo.IsCompleted;
    vm.save();
  };

  vm.clearCompleted = function(){
    vm.todos = vm.todos.filter(function(t){ return !t.IsCompleted; });
    vm.save();
  };

  vm.clearAll = function(){
    if($window.confirm('Remover todas as tarefas? Isso não pode ser desfeito.')){
      vm.todos = [];
      vm.save();
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
    else todo.Title = text;
    vm.editing = null;
    vm.editText = '';
    vm.save();
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
