using System;
using System.Linq.Expressions;

namespace QueryGenerator.ColumnMapping
{
    public class IntColumn<T> : BaseColumn<T>
    {
        public override object GetValue(T model)
        {
            return (int)ValueGetter(model);
        }

        //public override bool IsEqual(object first, object second)
        //{
        //    int firstValue = (int)first;
        //    if (firstValue == 0) return false;
        //    int secondValue = (int)second;
        //    switch (QueryOperator)
        //    {
        //        case QueryOperator.None: return false;
        //        case QueryOperator.Equal:
        //            return firstValue == secondValue;
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
    }
}
