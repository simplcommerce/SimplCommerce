using System;
using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Infrastructure;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable
{
    public static class SmartTableExtension
    {
        public static SmartTableResult<TResult> ToSmartTableResult<TModel, TResult>(this IQueryable<TModel> query, SmartTableParam param, Func<TModel, TResult> selector)
        {
            if (param.Pagination.Number <= 0)
            {
                param.Pagination.Number = 10;
            }

            // TODO Prevent sql injection
            if (param.Search.PredicateObject != null)
            {
                var filter = string.Empty;
                var index = 0;
                List<object> values = new List<object>();
                foreach (var item in param.Search.PredicateObject)
                {
                    if (index == 0)
                    {
                        filter = string.Format("{0}.Contains(@{1})", item.Path, index);
                    }
                    else
                    {
                        filter = string.Format("{0} AND {1}.Contains(@{2})", filter, item.Path, index);
                    }
                    values.Add(item.Value.Value);
                    index++;
                }
                if (!string.IsNullOrWhiteSpace(filter))
                {
                   // query = query.Where(filter, values.ToArray());
                }
            }

            var totalRecord = query.Count();

            if (!string.IsNullOrWhiteSpace(param.Sort.Predicate))
            {
                query = query.OrderByName(param.Sort.Predicate, param.Sort.Reverse);
            }
            else
            {
               // query = query.OrderBy("Id");
            }

            var items = query
                .Skip(param.Pagination.Start)
                .Take(param.Pagination.Number)
                .Select(selector);

            return new SmartTableResult<TResult>
            {
                Items = items,
                TotalRecord = totalRecord,
                NumberOfPages = (int)Math.Ceiling((double)totalRecord / param.Pagination.Number)
            };
        }
    }
}
