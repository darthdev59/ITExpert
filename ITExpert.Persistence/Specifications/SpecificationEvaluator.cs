﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITExpert.Persistence.Specifications
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQueryable,
        Specification<TEntity> specification)
        where TEntity : class
        {
            IQueryable<TEntity> queryable = inputQueryable;

            if (specification.Criteria is not null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            specification.IncludeExpressions.Aggregate(
                queryable,
                (current, includeExpression) =>
                current.Include(includeExpression));

            return queryable;
        }
    }
}