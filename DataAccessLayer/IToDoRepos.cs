using System.Collections.Generic;
using Model;

namespace DataAccessLayer
{
    public interface IToDoRepos
    {
        public void AddToDo(ToDo toDo);
        public List<ToDo> GetToDos();
        public ToDo GetToDo(int Input);
        public void DeleteToDo(int Input);
        public void UpdateToDo(ToDo toDo, int Input);
    }

}
