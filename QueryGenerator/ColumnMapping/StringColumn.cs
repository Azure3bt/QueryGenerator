namespace QueryGenerator.ColumnMapping
{
    public class StringColumn<T> : BaseColumn<T>
    {
        public override object GetValue(T model)
        {
            return ValueGetter(model);
        }
    }
}
