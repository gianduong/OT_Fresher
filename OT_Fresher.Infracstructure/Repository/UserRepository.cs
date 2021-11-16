using Dapper;
using Microsoft.Extensions.Configuration;
using OT_Fresher.Core.Entities;
using OT_Fresher.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Infracstructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        DynamicParameters _dynamicParameters;
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            _dynamicParameters = new DynamicParameters();
        }
        public IEnumerable<User> GetByPaginationFilter(int pageInt, int pageSize, string filterString)
        {
            using (_dbConnection = new MySqlConnection(_connectString))
            {
                var storeName = Properties.Resources.Proc_GetUser_Pagination_Filter;
                _dynamicParameters.Add(Properties.Resources.dy_size, pageSize);
                _dynamicParameters.Add(Properties.Resources.dy_int, pageInt);
                _dynamicParameters.Add(Properties.Resources.dy_fitler, filterString);
                return _dbConnection.Query<User>(storeName, _dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetTotalByFilter(string filterString)
        {
            using (_dbConnection = new MySqlConnection(_connectString))
            {
                var storeName = Properties.Resources.Proc_GetTotalUser;
                _dynamicParameters.Add(Properties.Resources.dy_fitler, filterString);
                return _dbConnection.ExecuteScalar<int>(storeName, _dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
