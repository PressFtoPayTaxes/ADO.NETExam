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
    public class CitiesRepository : IRepository<City>
    {
        private DbConnection _connection;
        private string _connectionString;

        public CitiesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void Delete(Guid id)
        {
            var sqlQuery = $"update Cities set DeletedDate = {DateTime.Now} where Id = @Id";
            _connection.Execute(sqlQuery, id);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Insert(City item)
        {
            var sqlQuery = "insert into Cities(Name, Population, CountryId, CreationDate) values(@Name, @Population, @CountryId, @CreationDate)";
            _connection.Execute(sqlQuery, item);
        }

        public ICollection<City> Select()
        {
            var sqlQuery = "select * from Cities";
            return _connection.Query<City>(sqlQuery).AsList();
        }

        public void Update(City item)
        {
            var sqlQuery = "update Cities set Name = @Name and Population = @Population and CountryId = @CountryId where Id = @Id";
            _connection.Execute(sqlQuery, item);
        }
    }
}
