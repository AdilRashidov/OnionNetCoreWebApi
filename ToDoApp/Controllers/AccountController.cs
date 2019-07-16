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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/<controller>
       // [Authorize]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _unitOfWork.Users.GetAll();
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
                    var user = _mapper.Map<User>(userdto);
                    var alluser = _unitOfWork.Users.GetAll();
                    var UserExist = alluser.SingleOrDefault(x => x.Email == user.Email); //наличие пользователя
                    if (UserExist == null)
                    {
                        user.Role="user";
                        _unitOfWork.Users.Add(user);
                        _unitOfWork.SaveChanges();
                        return Ok("You зарегистрированы");
                    }
                    else
                    {
                        return BadRequest("Username существует");
                    }
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
            _unitOfWork.Users.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}
