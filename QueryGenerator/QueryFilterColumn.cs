using System;
using System.Collections.Generic;

namespace QueryGenerator;

public class QueryFilterColumn<TModel, TEntity>
{
    private const char Delimiter = ',';
    private IEnumerable<Func<TEntity, object>> Fields { get; set; }
    private QueryOperator Operator { get; set; }
    private bool? HasJoin { get; set; } = false;

    private Func<object, object> _valueGetter;

    public QueryFilterColumn(IEnumerable<Func<TEntity, object>> fields, QueryOperator @operator)
    {
        Fields = fields;
        Operator = @operator;
    }

    public QueryFilterColumn<TModel, TEntity> GetValue(Func<TModel, object> valueGetter)
    {
        _valueGetter = obj => valueGetter((TModel)obj);
        return this;
    }

    internal QueryResult<TEntity> GenerateQuery(TModel instance)
    {
        var joinClause = string.Empty;
        var whereClause = PredicateBuilder.False<TEntity>();
        var value = _valueGetter(instance);
        if (value is not null)
        {
            var fields = Fields;
            if (HasJoin ?? false)
            {
                throw new NotSupportedException("Join is not supported");
                //joinClause = $" INNER JOIN {JoinTable} AS _{JoinTable} ON _{JoinTable}.{JoinColumn} = {Fields} ";
            }

            foreach(var field in fields)
            {
                whereClause = whereClause.Or(x => field(x) == value);
            }

            //whereClause.Add($"({string.Join(" OR ", fields.Select(field => $"{field}{Operator.GetDisplayValue()}@{parameterName}"))})");
            //var sqlQuery = $"{string.Join(" ", joinClause.ToArray())}";
            //if (whereClause.Any())
            //    sqlQuery = $"{sqlQuery} {string.Join(" AND ", whereClause)}";

            return new QueryResult<TEntity>(whereClause);
        }

        return default;
    }
}