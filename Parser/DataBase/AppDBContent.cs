using Microsoft.EntityFrameworkCore;
using Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.DataBase
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<UrlBody> UrlBodies { get; set; }
    }
}
