using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Domain.Core;

namespace ToDoApp.Automapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Todo, ToDoDTO> ().ReverseMap();
            CreateMap<User, UserDTO> ().ReverseMap();         
        }
    }
    
}
