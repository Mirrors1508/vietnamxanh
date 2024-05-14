using Lib.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITIES.Models
{
    public class PortgreDataContext : DataContext
    {
        private readonly string _connection;

        public PortgreDataContext(string connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connection);

            }
        }
    }
}
