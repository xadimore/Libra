using Libra.Library.Models;
using Libra.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libra.Services
{
    public class SqlRepository : IRepository
    {
        private readonly AppConnect db;

        public SqlRepository(AppConnect db)
        {
            this.db = db;
        }

       
    }
}
