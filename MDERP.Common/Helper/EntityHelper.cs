using System;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MDERP.Common.Helper
{
    public static class EntityHelper
    {
        public static TDestination MapTo<TDestination, TSource>(this TSource source)
            where TDestination : class
            where TSource : class
        {
            if (source == null) return default(TDestination);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }
    }
}
