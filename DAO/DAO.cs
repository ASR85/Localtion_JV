﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    public abstract class DAO<T>
    {
        protected string connectionString = null;

        public DAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
        }
        //public abstract bool Create(T obj);
        //public abstract bool Delete(T obj);
        //public abstract bool Update(T obj);
        //public abstract T Find(int id);
        //public abstract List<T> DisplayAll();
    }
}
