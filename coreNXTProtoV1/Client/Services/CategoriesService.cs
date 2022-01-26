//using coreNXTProtoV1.Server.Models;
using coreNXTProtoV1.Shared;
using System.Net.Http;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace coreNXTProtoV1.Client.Services
{
    public class CategoriesService : ICategoriesService
    {

        //  private readonly HttpClient httpClient;
        //       private readonly List<TopLevelMenu> TopLevelMenu;
        //public CategoriesService(HttpClient httpClient)
        //{
        //  this.httpClient = httpClient;
        //}


        /*----------------------------------------------
        private readonly AppDBContext appDBContext;

        public CategoriesService(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;

        }
        --------------------------------------*/
        public IConfiguration _configuration { get; }

        public string _connectionString { get; }

        public CategoriesService(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString = configuration.GetConnectionString("DBConnection");
        }
        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        /*
        public IConfiguration _configuration { get; }
        public string _connectionString { get; }
        public CategoriesService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DBConnection");
        }
        */
        public async Task<IEnumerable<TopLevelMenu>> GetTopLevelMenu(int localeid, int parentcategoryid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("localeid", localeid, DbType.Int32);
            parameters.Add("parentcategoryid", parentcategoryid, DbType.Int32);
            IEnumerable<TopLevelMenu> tlm;
            //Task<IEnumerable<TopLevelMenu>> tlm;
            //   return await httpClient.GetFromJsonAsync<IEnumerable<TopLevelMenu>>("/api/toplevelmenu");
           // using (var conn = new SqlConnection(_connectionString))
            using(SqlConnection conn=Connection) 
            {
                if (conn.State == ConnectionState.Closed)
                     conn.Open();
                  try
                  {
                    //                       var locale = new SqlParameter("@localeid", localeid);
                    //                   var parentcat= new SqlParameter("@parentcategoryid", parentcategoryid);

                    tlm = await conn.QueryAsync<TopLevelMenu>("dbo.sp_GetTopLevelMenu", parameters, commandType: CommandType.StoredProcedure);
                    //                    tlm= await conn.QueryAsync(("exec sp_GetTopLevelMenu @localeid, @parentcategoryid", locale, parentcat).ToListAsync; 
                    // return await _connectionString.sp_GetTopLevelMenu(localeid, parentcategoryid).ToListAsync();
                    //              tlm = await conn.QueryFirstOrDefaultAsync<TopLevelMenu>("master.sp_GetTopLevelMenu", parameters, commandType: CommandType.StoredProcedure).ToList();


                }
                catch (Exception)
                  {
                      throw;
                  }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return tlm;
        }
    }
}
