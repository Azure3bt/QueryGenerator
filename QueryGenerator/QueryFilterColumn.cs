using QueryGenerator.ColumnMapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryGenerator;

public class QueryFilterColumn<TModel, TEntity>
{
    private const char Delimiter = ',';
    private IEnumerable<BaseColumn<TEntity>> Fields { get; set; }
    private QueryOperator Operator { get; set; }
    private bool? HasJoin { get; set; } = false;

    private Func<TModel, object> _valueGetter;

    public QueryFilterColumn(IEnumerable<BaseColumn<TEntity>> fields)
    {
        Fields = fields;
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

            foreach (var field in fields)
            {
                var func = ((LongColumn<TEntity>)field).GetExpression(field.PropertyName, value);
                whereClause = whereClause.Or(func);
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