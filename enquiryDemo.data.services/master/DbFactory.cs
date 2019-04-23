using System;
using System.Data.SqlClient;
using System.Configuration;
using enquiryDemo.data.interfaces;
using System.Data;

namespace enquiryDemo.data.model.master
{
    public class DbFactory : IDataService, IDisposable
    {
        SqlConnection _DBConnection;
        
        public SqlConnection CompanyConnection
        {
            get { return _DBConnection; }
        }
        public void CommitTransaction(Boolean closeSession)
        {
           
        }

        public void RollbackTransaction(Boolean closeSession)
        {

        }

        public void Save(object entity) { }

        public void CreateSession()
        {
            string dbConnection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;            
            _DBConnection = new SqlConnection(dbConnection);
        }

        public void BeginTransaction()
        {
        }

        public void CloseSession() { }

        public void Dispose()
        {
           
        }
    }
}
