using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Automapper;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {

        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoController(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ToDoDTO> Get()
        {
            string name = HttpContext.User.Identity.Name;
            int userId = _repository.GetUserId(name);
            var todo = _repository.GetToDoUserList(userId);
            return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todo);
        }
        
        [HttpGet("{id}")]
        public ToDoDTO Get(int id)
        {
            var todo = _repository.GetToDo(id);
            return _mapper.Map<ToDoDTO>(todo);
        } 

        [HttpPost]
        public IActionResult Post([FromBody]ToDoDTO tododto)
        {
            {
                var todo = _mapper.Map<ToDo>(tododto);
                if (todo == null)
                {
                    return BadRequest();
                }
                string name = HttpContext.User.Identity.Name;
                int userId = _repository.GetUserId(name);
                todo.Check= false;
                todo.UserId = userId;
                _repository.Create(todo);
                _repository.Save();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]ToDoDTO tododto)
        {
            if (tododto == null)
            {
                return BadRequest();
            }
            var todo = _mapper.Map<ToDo>(tododto);
            string name = HttpContext.User.Identity.Name;
            int userId = _repository.GetUserId(name);
            todo.UserId=userId;
            _repository.Update(todo);
            _repository.Save();
            return Ok(todo);
        }
     
        [HttpPut("do/{id}")]
        public IActionResult PutDo([FromRoute]int id)
            {
            bool todoexist = _repository.ToDoExist(id);
            if (todoexist == false)
            { return BadRequest("Takogo taska net"); }
            else {
                string message =_repository.ToDoDo(id);
                _repository.Save();
                return Ok(message);
                 } 
            }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {   
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
