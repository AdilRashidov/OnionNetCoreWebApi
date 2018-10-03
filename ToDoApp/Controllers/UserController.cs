using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Infrastructure.Business;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
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
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            {
                if (ModelState.IsValid)
                {
                    var kek = _repository.UserExist(user);      //наличие пользователя
                    if (kek == false)
                    {
                        user.Role = "user";
                        _repository.Create(user);
                        _repository.Save();
                        return Ok("You зарегистрированы");
                    }
                    else
                    {
                        return Ok("Username существует");
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
