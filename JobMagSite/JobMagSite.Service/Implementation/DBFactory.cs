using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JobMagSite.Domain.Common;
using JobMagSite.Domain.Entities;
using JobMagSite.Persistence;
using JobMagSite.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMagSite.Service.Implementation
{
    public class DBFactory : DbFactoryBase, IDBFactory
    {
        private readonly ILogger<DBFactory> _logger;
        public DBFactory(IConfiguration config, ILogger<DBFactory> logger) : base(config)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await DbQueryAsync<Person>("SELECT * FROM Person");
        }

        public async Task<Person> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<Person>("SELECT * FROM Person WHERE ID = @ID", new { id });
        }

        public async Task<long> CreateAsync(Person person)
        {
            string sqlQuery = $@"INSERT INTO Person (FirstName, LastName, DateOfBirth) 
                                     VALUES (@FirstName, @LastName, @DateOfBirth)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint)";

            return await DbQuerySingleAsync<long>(sqlQuery, person);
        }
        public async Task<bool> UpdateAsync(Person person)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Person WHERE ID = @ID) 
                                            UPDATE Person SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth
                                            WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, person);
        }
        public async Task<bool> DeleteAsync(object id)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Person WHERE ID = @ID)
                                        DELETE Person WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, new { id });
        }
        public async Task<bool> ExistAsync(object id)
        {
            return await DbExecuteScalarAsync("SELECT COUNT(1) FROM Person WHERE ID = @ID", new { id });
        }
    }
}
