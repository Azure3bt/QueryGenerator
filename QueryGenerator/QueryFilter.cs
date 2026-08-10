using System.Collections.Generic;

namespace QueryGenerator;

public class QueryFilter<TModel, TEntity>
{
    private string _schema;
    private string _table;

    private IList<QueryFilterColumn<TModel, TEntity>> _columns = new List<QueryFilterColumn<TModel, TEntity>>();

    private bool _isInit = false;
    private bool HasInit() => _isInit ? true : throw new QueryGeneratorException("object not initialize");

    public QueryFilter<TModel, TEntity> Init(string schema, string table)
    {
        _schema = schema;
        _table = table;
        _isInit = true;
        return this;
    }

    public QueryFilter<TModel, TEntity> AddFilter(QueryFilterColumn<TModel, TEntity> column)
    {
        _columns.Add(column);
        HasInit();

        return this;
    }

    public QueryResult<TEntity> Build(TModel instance)
    {
        var whereClause = PredicateBuilder.True<TEntity>();
        foreach (var column in _columns)
        {
            var queryResult = column.GenerateQuery(instance);
            if (queryResult is null) continue;

            whereClause = whereClause.And(queryResult.Query);
        }

        return new QueryResult<TEntity>(whereClause);
    }
}
