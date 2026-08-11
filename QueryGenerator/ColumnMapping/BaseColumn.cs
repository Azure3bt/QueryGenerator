using System;
using System.Linq.Expressions;

namespace QueryGenerator.ColumnMapping
{
    public abstract class BaseColumn<TSource>
    {
        public string PropertyName { get; set; }
        public Func<TSource, object> ValueGetter { get; set; }
        public QueryOperator QueryOperator { get; set; }
        //public abstract object GetValue(TSource model);
        public Expression<Func<TSource, bool>> GetExpression(string propertyName, object value)
        {
            var parameter = Expression.Parameter(typeof(TSource), "x");
            var property = Expression.PropertyOrField(parameter, propertyName);

            var convertedValue = Expression.Convert(
                Expression.Constant(value),
                property.Type);


            var expression = QueryOperator switch
            {
                QueryOperator.Equal => Expression.Equal(property, convertedValue),
                QueryOperator.NotEqual => Expression.NotEqual(property, convertedValue),
                QueryOperator.GreaterThan   => Expression.GreaterThan(property, convertedValue),
                QueryOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, convertedValue),
                QueryOperator.LessThan => Expression.LessThan(property, convertedValue),
                QueryOperator.LessThanOrEqual => Expression.LessThanOrEqual(property,convertedValue),
                _ => throw new NotSupportedException()
            };

            return Expression.Lambda<Func<TSource, bool>>(expression, parameter);
        }
    }
}
