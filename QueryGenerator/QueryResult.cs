using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryGenerator;

public class QueryResult<T>
{
    public QueryResult(Expression<Func<T, bool>> query, IEnumerable<SqlParameter> parameters)
    {
        Query = query;
        Parameters = parameters;
    }

    public Expression<Func<T, bool>> Query { get; set; }
    public IEnumerable<SqlParameter> Parameters { get; set; }
}
