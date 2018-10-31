using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Infrastructure.Business;
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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoController(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor http)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ToDoDTO> Get()
        {
           
            return _mapper.Map<IEnumerable<Todo>, IEnumerable<ToDoDTO>>(todo);
        }
        
        [HttpGet("{id}")]
        public ToDoDTO Get(int id)
        {
            var todo = .GetToDo(id);
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
                int userId = .GetUserId(name);
                todo.Check= false;
                todo.UserId = userId;
                .Create(todo);
                .Save();
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
            var todo = _mapper.Map<Todo>(tododto);
            string name = HttpContext.User.Identity.Name;
            int userId = .GetUserId(name);
            todo.TodoList.Users=userId;
            .Update(todo);
            .Save();
            return Ok(todo);
        }
     
        [HttpPut("do/{id}")]
        public IActionResult PutDo([FromRoute]int id)
            {
            bool todoexist = .ToDoExist(id);
            if (todoexist == false)
            { return BadRequest("Takogo taska net"); }
            else {
                string message =.ToDoDo(id);
                .Save();
                return Ok(message);
                 } 
            }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {   
            .Delete(id);
            .Save();
        }
                
        [HttpGet("search/{search}")]
        public IEnumerable<ToDoDTO> GetName(string search)
         { 
            if (search=="undefined")
            {
                string name = HttpContext.User.Identity.Name;
                int userId = .GetUserId(name);
                var todo = .GetToDoUserList(userId);
                return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todo); 
            }
         else
            {
                string name = HttpContext.User.Identity.Name;
                int userId = .GetUserId(name);
                var todo = .GetToDoUserList(userId);
                var todoname = todo.Where(x => x.Name.Contains(search));         //выборка по названию
                return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todoname);
            }
         }
    }
}
