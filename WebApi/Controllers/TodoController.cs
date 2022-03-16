using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Managers;
using Model;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ToDoManager toDoManager;
        public TodoController(ToDoManager toDoManager)
        {
            this.toDoManager = toDoManager;
        }

        //todo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(toDoManager.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(toDoManager.GetToDo(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDo toDo)
        {
            toDoManager.Add(toDo);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ToDo toDo, [FromRoute] int id)
        {
            toDo.ToDoID = id;
            toDoManager.Update(toDo, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            toDoManager.DeleteToDo(id);
            return Ok();
        }

    }
}
