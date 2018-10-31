using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Business
{
    public class TagsRepository : Repository<Tag>,ITagsRepository
    {
        public TagsRepository(DbContext context) : base(context)
        {}
        private AppDBContext  _appContext => (AppDBContext) _context;
    }
}
