using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class CopyDAO : DAO<Copy>
    {
        public override bool Create(Copy obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Copy obj)
        {
            throw new NotImplementedException();
        }

        public override List<Copy> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Copy Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Copy obj)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Copy c)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Copy(IdPlayer,IdGame) VALUES(IdPlayer, IdGame)", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }
    }
}
