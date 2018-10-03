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

namespace ToDoApp.Controllers
{
    [Route("api/todo/search/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public SearchController(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Name/{search}")]
        public IEnumerable<ToDoDTO> GetName(string search)
         { 
            string name = HttpContext.User.Identity.Name;
            int userId = _repository.GetUserId(name);
            var todo = _repository.GetToDoUserList(userId);
            var todoname = todo.Where(x => x.Name == search);         //выборка по названию
            return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todoname);
         }

        [Authorize]
        [HttpGet("Tags/{search}")]
        public IEnumerable<ToDoDTO> GetTags(string search)
        {
            string name = HttpContext.User.Identity.Name;
            int userId = _repository.GetUserId(name);
            var todo = _repository.GetToDoUserList(userId);
            var todoname = todo.Where(x => x.Tags == search);         //выборка по тегам
            return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todoname);
        }

        [Authorize]
        [HttpGet("desc/{search}")]
        public IEnumerable<ToDoDTO> GetDesc(string search)
        {
            string name = HttpContext.User.Identity.Name;
            int userId = _repository.GetUserId(name);
            var todo = _repository.GetToDoUserList(userId);
            var todoname = todo.Where(x => x.Desc == search);         //выборка по описанию
            return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(todoname);
        }
        }
    
}
