using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Dapper;
using Force24.Server.DataProcessing.Dapper;
using System.Threading.Tasks;

namespace Test1
{
    public class DbContext : DapperContextBase
    {
        private static string dbString = "data source=sql1.force24.co.uk;initial catalog=Data_Import;persist security info=True;user id=Force24Applications;password=!4orce244pplcations!;MultipleActiveResultSets=True;Connect Timeout=3600";
        public DbContext() : base(dbString, "dbo")
        {            
        }

        public async Task<IEnumerable<TestModel>> LoadTestData()
        {
            return await ExecuteIEnumerableStoredProcedureAsync<TestModel>("usp_TestEntityFrameWork");
        }
    }
}
