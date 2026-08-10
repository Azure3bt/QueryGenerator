namespace QueryGenerator.ColumnMapping
{
    public class LongColumn<T> : BaseColumn<T>
    {
        public override object GetValue(T model)
        {
            return (long)ValueGetter(model);
        }

        public override bool IsEqual(object first, object second)
        {
            long firstValue = (long)first;
            if (firstValue == 0) return false;
            long secondValue = (long)second;
            switch (QueryOperator)
            {
                case QueryOperator.None: return false;
                case QueryOperator.Equal:
                     return firstValue == secondValue;
                case QueryOperator.NotEqual:
                    return firstValue != secondValue;
                case QueryOperator.GreaterThan:
                    return secondValue > firstValue;
                case QueryOperator.GreaterThanOrEqual:
                    return secondValue <= firstValue;
                case QueryOperator.LessThan:
                    return firstValue < secondValue;
                case QueryOperator.LessThanOrEqual:
                    return firstValue <= secondValue;
                case QueryOperator.Like:
                case QueryOperator.NotLike:
                    throw new System.Exception();
            }

            return false;
        }
    }
}
