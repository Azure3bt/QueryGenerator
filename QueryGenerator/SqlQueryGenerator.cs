using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QueryGenerator;

public static class SqlQueryGenerator
{
    public static QueryResult GenerateQuery<T>(this T model) where T : class 
    {
        var tableAttribute = typeof(T).GetCustomAttribute<TableAttribute>();
        if (tableAttribute is null) return default;

        var sqlParameters = new Dictionary<string, SqlParameter>();
        var joinClause = new List<string>();
        var whereClause = new List<string>();

        foreach (var propertyInfo in typeof(T).GetProperties().Where(propertyInfo => propertyInfo.GetCustomAttribute<QueryAttribute>() != null))
        {
            var queryAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();
            if (queryAttribute != null)
            {
                var value = propertyInfo.GetValue(model);
                if (value != null)
                {
                    var whereClauseTemp = new StringBuilder();
                    var fields = queryAttribute.Fields;
                    var parameterNames = fields;
                    if (queryAttribute.QueryField is not null)
                        parameterNames = new string[] { queryAttribute.QueryField };

                    if (parameterNames.Count() > 1)
                        throw new QueryGeneratorException("You can't define two parameter");

                    var parameterName = parameterNames.Single();
                    if (sqlParameters.ContainsKey(parameterName)) throw new QueryGeneratorException("You can't define two field same name");
                    sqlParameters[parameterName] = new SqlParameter($"@{parameterName}", value) { SqlDbType = queryAttribute.FieldType };

                    if (queryAttribute.HasJoin ?? false)
                        joinClause.Add($" INNER JOIN {queryAttribute.JoinTable} AS _{queryAttribute.JoinTable} ON _{queryAttribute.JoinTable}.{queryAttribute.JoinColumn} = {queryAttribute.Fields} ");

                    whereClause.Add($"({string.Join(" OR ", fields.Select(field => $"{field}{queryAttribute.Operator.GetDisplayValue()}@{parameterName}"))})");
                }
            }
        }

        var sqlQuery = $"SELECT _{tableAttribute.Name}.* FROM [{tableAttribute.Schema}].[{tableAttribute.Name}] AS _{tableAttribute.Name}";
        sqlQuery = $"{sqlQuery} {string.Join(" ", joinClause)}";
        if (whereClause.Any())
            sqlQuery = $"{sqlQuery} WHERE {string.Join(" AND ", whereClause)}";

        return new QueryResult(sqlQuery, sqlParameters.Values);
    }
}