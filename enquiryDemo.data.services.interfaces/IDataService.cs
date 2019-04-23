using System;

namespace enquiryDemo.data.interfaces
{
    public  interface IDataService
    {
        void CreateSession();
        void BeginTransaction();
        void CommitTransaction(Boolean closeSession);
        void RollbackTransaction(Boolean closeSession);
        void CloseSession();
    }
}
