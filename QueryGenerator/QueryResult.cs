using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryGenerator;

public class QueryResult<T>
{
    public QueryResult(Expression<Func<T, bool>> query)
    {
        Query = query;
    }

    public Expression<Func<T, bool>> Query { get; set; }
}
