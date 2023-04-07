using MDERP.Business.Models.Entities;
using MDERP.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.IService.BASE
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetModelById(object id);

        Task<TEntity> GetModelByExpression(Expression<Func<TEntity, bool>> whereExpression);

        Task<PageModel<TEntity>> GetPageModel(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<List<TEntity>> QueryableByExpression(Expression<Func<TEntity, bool>> whereExpression);

        Task<int> Add(TEntity Entity);

        Task<int> AddRange(List<TEntity> listEntity);

        Task<bool> Update(TEntity Entity);

        Task<bool> Delete(TEntity Entity);
    }
}
