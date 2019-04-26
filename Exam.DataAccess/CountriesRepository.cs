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
    public class CountriesRepository : IRepository<Country>
    {
        private DbConnection _connection;
        private string _connectionString;

        public CountriesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void Delete(Guid id)
        {
            var sqlQuery = $"update Countries set DeletedDate = {DateTime.Now} where Id = @Id";
            _connection.Execute(sqlQuery, id);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Insert(Country item)
        {
            var sqlQuery = "insert into Countries(Name, Population, CreationDate) values(@Name, @Population, @CreatioDate)";
            _connection.Execute(sqlQuery, item);
        }

        public ICollection<Country> Select()
        {
            var sqlQuery = "select * from Countries";
            return _connection.Query<Country>(sqlQuery).AsList();
        }

        public void Update(Country item)
        {
            var sqlQuery = "update Countries set Name = @Name and Population = @Population where Id = @Id";
            _connection.Execute(sqlQuery, item);
        }
    }
}