using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FranChallenge.Services
{
    public static class LinqExtensions
    {
         public static TEntity GetByIdNew<TEntity>(this IEnumerable<TEntity> source, object primaryKey)
        {
            var itemFound = source.AsQueryable().SingleOrDefault<TEntity>(GetByKeyExpression<TEntity>(primaryKey));
            return itemFound;
        }

        private static Expression<Func<TEntity, bool>> GetByKeyExpression<TEntity>(object primaryKey)
        {
            var primaryKeyProperty = typeof(TEntity).GetProperties()
                .First(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0); 

            //Create entity => portion of lambda expression 
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "element");

            //Create entity.Id portion of lambda expression 
            MemberExpression property = Expression.Property(parameter, primaryKeyProperty.Name);

            //Create 'id' portion of lambda expression 
            var equalsTo = Expression.Constant(primaryKey);

            //Create entity.Id == 'id' portion of lambda expression 
            var equality = Expression.Equal(property, equalsTo);

            //finally create the entire expression: entity => entity.Id = 'id' 
            Expression<Func<TEntity, bool>> retVal = Expression.Lambda<Func<TEntity, bool>>(equality,
                new[] { parameter });

            return retVal;
        }
    }
}