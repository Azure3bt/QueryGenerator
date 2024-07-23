using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QueryGenerator;

public class QueryFilterColumn
{
    private const char Delimiter = ',';
    private string[] Fields { get; set; }
    private string? QueryField { get; set; }
    private SqlDbType FieldType { get; set; }
    private QueryOperator Operator { get; set; }
    private bool? HasJoin { get; set; } = false;
    private string JoinColumn { get; set; }
    private string JoinTable { get; set; } = string.Empty;
    private bool HasMultipleFields { get; set; } = false;

    private Func<object, object> _valueGetter;

    public QueryFilterColumn(string fieldName, SqlDbType fieldType, QueryOperator @operator)
    {
        Fields = fieldName.Split(Delimiter);
        FieldType = fieldType;
        Operator = @operator;
    }

    public QueryFilterColumn(string fieldName, string? queryField, SqlDbType sqlDbType, QueryOperator @operator) : this(fieldName, sqlDbType, @operator)
    {
        QueryField = queryField;
    }

    public QueryFilterColumn(string fieldName, string queryField, SqlDbType fieldType, QueryOperator @operator, bool hasMultiple) : this(fieldName, queryField,fieldType,@operator)
    {
        HasMultipleFields = hasMultiple;
    }

    public QueryFilterColumn(string fieldName, SqlDbType fieldType, QueryOperator @operator, bool hasJoin, string joinTable, string joinColumn) : this(fieldName, fieldType, @operator)
    {
        JoinTable = joinTable;
        JoinColumn = joinColumn;
    }

    public QueryFilterColumn GetValue<T>(Func<T, object> valueGetter)
    {
        _valueGetter = x => _valueGetter;
        return this;
    }

    internal QueryResult GenerateQuery<T>(T instance)
    {
        var sqlParameters = new Dictionary<string, SqlParameter>();
        var joinClause = string.Empty;
        var whereClause = new List<string>();
        var value = _valueGetter(instance);
        if (value is not null)
        {
            var whereClauseTemp = new StringBuilder();
            var fields = Fields;
            var parameterNames = fields;
            if (QueryField is not null)
                parameterNames = [QueryField];

            if (parameterNames.Count() > 1)
                throw new QueryGeneratorException("You can't define two parameter");

            var parameterName = parameterNames.Single();
            if (sqlParameters.ContainsKey(parameterName)) throw new QueryGeneratorException("You can't define two field same name");
            sqlParameters[parameterName] = new SqlParameter($"@{parameterName}", value) { SqlDbType = FieldType };

            if (HasJoin ?? false)
                joinClause = $" INNER JOIN {JoinTable} AS _{JoinTable} ON _{JoinTable}.{JoinColumn} = {Fields} ";

            whereClause.Add($"({string.Join(" OR ", fields.Select(field => $"{field}{Operator.GetDisplayValue()}@{parameterName}"))})");
            var sqlQuery = $"{string.Join(" ", joinClause.ToArray())}";
            if (whereClause.Any())
                sqlQuery = $"{sqlQuery} {string.Join(" AND ", whereClause)}";
            return new QueryResult(sqlQuery, sqlParameters.Values);
        }

        return default;
    }
}