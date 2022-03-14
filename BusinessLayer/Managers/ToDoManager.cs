using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace BusinessLayer.Managers
{
    public class ToDoManager
    {
        private readonly IToDoRepos ToDoRepos;
        public ToDoManager(IToDoRepos toDoRepos)
        {
            this.ToDoRepos = toDoRepos;
        }
        public void Add(ToDo toDo)
        {
            ToDoRepos.AddToDo(toDo);
        }
        public void DeleteToDo(int Input)
        {
            ToDoRepos.DeleteToDo(Input);
        }

        public ToDo GetToDo(int Input)
        {
            return ToDoRepos.GetToDo(Input);
        }

        public List<ToDo> Get()
        {
            return ToDoRepos.GetToDos();
        }

        public void Update(ToDo toDo, int Input)
        {
            ToDoRepos.UpdateToDo(toDo, Input);  
        }

    }
}
