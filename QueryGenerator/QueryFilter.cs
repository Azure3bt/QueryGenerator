using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryGenerator;

public class QueryFilter<T>
{
    private string _schema;
    private string _table;

    private IList<QueryFilterColumn<T>> _columns = new List<QueryFilterColumn<T>>();

    private bool _isInit = false;
    private bool HasInit() => _isInit ? true : throw new QueryGeneratorException("object not initialize");

    public QueryFilter<T> Init(string schema, string table)
    {
        _schema = schema;
        _table = table;
        _isInit = true;
        return this;
    }

    public QueryFilter<T> AddFilter(QueryFilterColumn<T> column)
    {
        HasInit();
        _columns.Add(column);

        return this;
    }

    public QueryResult<T> GenerateQuery(T instance)
    {
        var whereCaluse = new List<string>();
        var sqlParameters = new List<SqlParameter>();
        foreach (var column in _columns)
        {
            var queryResult = column.GenerateQuery(instance);
            if (queryResult is null) continue;

            whereCaluse.Add(queryResult.Query.ToString());
            sqlParameters.AddRange(queryResult.Parameters);
        }

        var sqlQuery = $"SELECT _{_table}.* FROM [{_schema}].[{_table}] AS _{_table}";
        if (whereCaluse.Any())
            sqlQuery = $"{sqlQuery} WHERE {string.Join(" AND ", whereCaluse)}";

        Expression<Func<T, bool>> whereClause = PredicateBuilder.True<T>();

        return new QueryResult<T>(whereClause, sqlParameters);
    }
}
