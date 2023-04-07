using MDERP.Business.IRepository;
using MDERP.Business.IRepository.BASE;
using MDERP.Business.IService.BASE;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Models.ViewModels;
using MDERP.Business.Repository;
using MDERP.Business.Repository.BASE;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Service.BASE
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> baseRep;

        public async Task<int> Add(TEntity Entity)
        {
            return await baseRep.Add(Entity);
        }

        public async Task<int> AddRange(List<TEntity> listEntity)
        {
            return await baseRep.Add(listEntity);
        }

        public async Task<bool> Delete(TEntity Entity)
        {
            return await baseRep.Delete(Entity);
        }

        public async Task<TEntity> GetModelByExpression(Expression<Func<TEntity, bool>> whereExpression)
        {
            var entityList = await baseRep.Query(whereExpression);
            return entityList.FirstOrDefault();
        }

        public async Task<TEntity> GetModelById(object id)
        {
            return await baseRep.QueryById(id);
        }

        public async Task<List<TEntity>> QueryableByExpression(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseRep.Query(whereExpression);
        }

        public async Task<PageModel<TEntity>> GetPageModel(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await baseRep.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<bool> Update(TEntity Entity)
        {
            return await baseRep.Update(Entity);
        }
    }
}
