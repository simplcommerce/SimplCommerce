using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HvCommerce.Infrastructure
{
    public static class OrderByExtension
    {
        public static IQueryable<T> OrderByName<T>(this IQueryable<T> source, string propertyName, bool isDescending)
        {
            if(source == null)
            {
                throw new ArgumentException("source");
            }

            if (String.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName");
            }

            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            Expression expression = Expression.Property(arg, propertyInfo);
            type = propertyInfo.PropertyType;

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expression, arg);

            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                        && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2
                        && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)result;
        }
    }
}
