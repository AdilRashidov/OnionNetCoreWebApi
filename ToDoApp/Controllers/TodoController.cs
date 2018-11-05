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
    public class TodoController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoController( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int GetUserId()
        {
            string email = HttpContext.User.Identity.Name;           
            int userId = _unitOfWork.Users.GetUserId(email);
            return userId;
        }

        [HttpGet]
        public IEnumerable<ListDTO> Get()
        {
            int userId = GetUserId();
            var todo = _unitOfWork.Lists.GetUserList(userId);
            return _mapper.Map<IEnumerable<List>, IEnumerable<ListDTO>>(todo);
        }

        

        
    }
}
