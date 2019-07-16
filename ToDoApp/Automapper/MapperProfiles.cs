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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<List, ListDTO>().ReverseMap();
            CreateMap<Todo, TodoDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
    
}
