using System;
using System.Linq.Expressions;

namespace QueryGenerator.ColumnMapping
{
    public class LongColumn<T> : BaseColumn<T>
    {
        //public override object GetValue(T model)
        //{
        //    return (long)ValueGetter(model);
        //}

        //public override bool IsEqual(object first, object second)
        //{
        //    long firstValue = (long)first;
        //    if (firstValue == 0) return false;
        //    long secondValue = (long)second;
        //    switch (QueryOperator)
        //    {
        //        case QueryOperator.None: return false;
        //        case QueryOperator.Equal:
        //             return firstValue == secondValue;
        //        case QueryOperator.NotEqual:
        //            return firstValue != secondValue;
        //        case QueryOperator.GreaterThan:
        //            return secondValue > firstValue;
        //        case QueryOperator.GreaterThanOrEqual:
        //            return secondValue <= firstValue;
        //        case QueryOperator.LessThan:
        //            return firstValue < secondValue;
        //        case QueryOperator.LessThanOrEqual:
        //            return firstValue <= secondValue;
        //        case QueryOperator.Like:
        //        case QueryOperator.NotLike:
        //            throw new System.Exception();
        //    }

        //    return false;
        //}

        //public override Expression<Func<T, bool>> GetExpression(string propertyName, object value)
        //{
        //    var parameter = Expression.Parameter(typeof(T), "x");
        //    var property = Expression.PropertyOrField(parameter, propertyName);

        //    var convertedValue = Expression.Convert(
        //        Expression.Constant(value),
        //        property.Type);

        //    var equal = Expression.Equal(property, convertedValue);

        //    return Expression.Lambda<Func<T, bool>>(equal, parameter);
        //}
    }
}
