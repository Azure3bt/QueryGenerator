using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace QueryGenerator;

public class QueryResult
{
    public QueryResult(string query, IEnumerable<SqlParameter> parameters)
    {
        Query = query;
        Parameters = parameters;
    }

    public string Query { get; set; }
    public IEnumerable<SqlParameter> Parameters { get; set; }
}
