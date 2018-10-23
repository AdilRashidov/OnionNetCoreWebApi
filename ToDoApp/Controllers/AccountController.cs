using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Infrastructure.Business;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Automapper;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public AccountController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<controller>
       // [Authorize]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetUserList();
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<controller>

        [HttpPost("register")]
        public IActionResult Post([FromBody]UserDTO userdto)
        {
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(userdto);
                    var kek = _repository.UserExist(user);      //наличие пользователя
                    if (kek == false)
                    {
                        _repository.Create(user);
                        _repository.Save();
                        return Ok("You зарегистрированы");
                    }
                    else
                    {
                        return BadRequest("Username существует");
                    }
                }
                else { return BadRequest("Vvedite login и password  "); }
            }
        }
        
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
