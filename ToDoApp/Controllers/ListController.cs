using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Business;
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
    public class ListController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListController( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int GetUserId()
        {
            string email = HttpContext.User.Identity.Name;           
            var user = _unitOfWork.Users.GetSingleOrDefault(x=>x.Email==email);
            return user.Id;
        }

        [HttpGet]
        public IEnumerable<ListDTO> Get()
        {
            int userId = GetUserId();
            var lists = _unitOfWork.Lists.GetUserList(userId);
            return _mapper.Map<IEnumerable<List>,IEnumerable<ListDTO>>(lists);
        }
        
        [HttpGet("{id}")]
        public ListDTO GetList(int id)
        {
            int userId = GetUserId();
            var list = _unitOfWork.Lists.Get(id);
            return _mapper.Map<ListDTO>(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListDTO listdto)
        {
            int userId = GetUserId();
            var list = _mapper.Map<List>(listdto);
            list.ListOwner = userId;
            _unitOfWork.Lists.Add(list);
            _unitOfWork.SaveChanges();
            return Ok("vse ok");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            int userId = GetUserId();
            var listown =_unitOfWork.Lists.GetSingleOrDefault(x=>x.Id==id && x.ListOwner==userId ); //Является ли удаляющий владельцем листа
            if (listown == null)
            {
                return BadRequest("ne tvoe");
            }
            else
            {
                _unitOfWork.Lists.Delete(id);
                _unitOfWork.SaveChanges();
                return Ok("Udaleno");       
            }
            
        }
        
        

        
    }
}
