using System;

namespace QueryGenerator.ColumnMapping
{
    public class BaseColumn<TSource>
    {
        public Func<TSource, object> ValueGetter { get; set; }
        public QueryOperator QueryOperator { get; set; }
        public virtual object GetValue(TSource model) => default;
        public virtual bool IsEqual(object first, object second) => false;
    }
}
