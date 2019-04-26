using Dapper;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DataAccess
{
    public class StreetsRepository : IRepository<Street>
    {
        private DbConnection _connection;
        private string _connectionString;

        public StreetsRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void Delete(Guid id)
        {
            var sqlQuery = $"update Streets set DeletedDate = {DateTime.Now} where Id = @Id";
            _connection.Execute(sqlQuery, id);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Insert(Street item)
        {
            var sqlQuery = "insert into Cities(Name, CityId, CreationDate) values(@Name, @CityId, @CreationDate)";
            _connection.Execute(sqlQuery, item);
        }

        public ICollection<Street> Select()
        {
            var sqlQuery = "select * from Streets";
            return _connection.Query<Street>(sqlQuery).AsList();
        }

        public void Update(Street item)
        {
            var sqlQuery = "update Streets set Name = @Name and CityId = @CityId where Id = @Id";
            _connection.Execute(sqlQuery, item);
        }
    }
}
