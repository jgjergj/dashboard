using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dashboard.Application.Common.Utils
{
    public class Utils
    {
        public static Expression<Func<T, bool>> CreatePredicate<T>(string columnName, object searchValue)
        {
            var xType = typeof(T);
            var x = Expression.Parameter(xType, "x");
            var column = xType.GetProperties().FirstOrDefault(p => p.Name == columnName);
            if (column.PropertyType == typeof(int))
            {
                searchValue = Convert.ToInt32(searchValue);
            }

            var body = column == null
                ? (Expression)Expression.Constant(true)
                : Expression.Equal(
                    Expression.PropertyOrField(x, columnName),
                    Expression.Constant(searchValue));

            return Expression.Lambda<Func<T, bool>>(body, x);
        }
    }
}
