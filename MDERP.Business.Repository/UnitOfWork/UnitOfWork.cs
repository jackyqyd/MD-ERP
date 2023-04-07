using MDERP.Business.IRepository.UnitOfWork;
using SqlSugar;
using System;

namespace MDERP.Business.Repository.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ISqlSugarClient _sqlSugarClient;
        public UnitOfWork(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        public SqlSugarClient GetDbClient()
        {
            return _sqlSugarClient as SqlSugarClient;
        }
        public void BeginTran()
        {
            GetDbClient().BeginTran();
        }

        public void CommitTran()
        {
            try
            {
                GetDbClient().CommitTran(); //
            }
            catch (Exception ex)
            {
                GetDbClient().RollbackTran();
            }
        }

        public void RollbackTran()
        {
            GetDbClient().RollbackTran();
        }
    }
}
