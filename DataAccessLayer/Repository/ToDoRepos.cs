using Model;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class ToDoRepos : BaseRepos, IToDoRepos
    {
        public ToDoRepos(Settings settings) : base(settings.ConnectionString)
        {

        }

        public void AddToDo(ToDo toDo)
        {
            using (var connection = GetConnection()) 
            {
                connection.Execute("Insert Into ToDoList (ToDoStr) Values (@ToDoStr)", toDo);
            }
        }

        public List<ToDo> GetToDos()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<ToDo>("Select*From ToDoList").OrderBy(x => x.ToDoID).ToList();
            }
        }
        public ToDo GetToDo(int Input)
        {
            using (var connection = GetConnection()) 
            {
               return connection.Query<ToDo>($"Select*From ToDoList Where ToDoId={Input}").FirstOrDefault();
            }
        }

        public void DeleteToDo(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute($"Delete From ToDoList Where ToDoId={Input}");
            }
        }

        public void UpdateToDo(ToDo toDo, int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute($"Update ToDoList Set ToDoStr=@ToDoStr, isActive=@isActive Where ToDoId={Input}", toDo);
            }
        }
    }
}
