using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MDERP.Business.Models;

namespace MDERP.Business.IRepository.BASE
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> QueryById(object objId);

        Task<TEntity> QueryById(object objId, bool blnUseCache = false);

        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        Task<int> Add(TEntity model);

        Task<int> Add(List<TEntity> listEntity);

        Task<bool> DeleteById(object id);

        Task<bool> Delete(TEntity model);
        Task<bool> DeleteByIds(object[] ids);

        Task<bool> Update(TEntity model);
        Task<bool> Update(TEntity entity, string strWhere);
        Task<bool> Update(object operateAnonymousObjects);

        Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");

        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(string strWhere);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null);
        Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null);

        Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);


        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
        Task<PageModel<TEntity>> QueryPageInIds(Expression<Func<TEntity, bool>> whereExpression, List<string> ids, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, JoinQueryInfos>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new();

        Task<PageModel<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, JoinQueryInfos>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null,
           int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null) where T : class, new();

        Task<List<TResult>> QueryMuch2<T, T2, TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression,
            Expression<Func<T, T2, bool>> whereLambda = null) where T : class, new();

        Task<PageModel<TResult>> QueryMuchPage<T, T2, TResult>(
           Expression<Func<T, T2, object[]>> joinExpression,
           Expression<Func<T, T2, TResult>> selectExpression,
           Expression<Func<T, T2, bool>> whereLambda = null,
           int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null) where T : class, new();

        Task<PageModel<TResult>> QueryMuchPageInIds<T, T2, TResult>(
          Expression<Func<T, T2, object[]>> joinExpression,
          Expression<Func<T, T2, TResult>> selectExpression,
          List<string> ids,
          Expression<Func<T, T2, bool>> whereLambda = null,
          int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null) where T : class, new();
    }
}
