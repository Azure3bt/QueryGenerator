namespace QueryGenerator.ColumnMapping
{
    public class StringColumn<T> : BaseColumn<T>
    {
        public override object GetValue(T model)
        {
            return ValueGetter(model);
        }

        public override bool IsEqual(object first, object second)
        {
            if (first is null) return false;
            var firstStr = first.ToString();
            var secondStr = second.ToString();
            return firstStr.Contains(secondStr);
        }
    }
}
