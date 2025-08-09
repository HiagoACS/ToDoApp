angular.module('todoApp').factory('todoStorage', ['$window', function($window){
  var STORAGE_KEY = 'todoApp_v1';
  return {
    load: function(){
      try{
        var raw = $window.localStorage.getItem(STORAGE_KEY);
        return raw ? JSON.parse(raw) : null;
      }catch(e){
        console.error('Erro lendo localStorage', e);
        return null;
      }
    },
    save: function(todos){
      try{
        $window.localStorage.setItem(STORAGE_KEY, JSON.stringify(todos));
      }catch(e){
        console.error('Erro salvando localStorage', e);
      }
    },
    clear: function(){
      try{ $window.localStorage.removeItem(STORAGE_KEY); }catch(e){ console.error(e); }
    }
  };
}]);
