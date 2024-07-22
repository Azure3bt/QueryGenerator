using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QueryGenerator;

public class QueryAttribute : Attribute
{
    public const char Delimiter = ',';
    public string[] Fields { get; set; }
    public string? QueryField { get; set; }
    public SqlDbType FieldType { get; set; }
    public Operator Operator { get; set; }
    public bool? HasJoin { get; set; } = false;
    public string? JoinColumn { get; set; }
    public string? JoinTable { get; set; } = string.Empty;
    public bool HasMultipleFields { get; set; } = false;

    public QueryAttribute(string fieldName, string? queryField, SqlDbType sqlDbType, Operator @operator)
    {
        Fields = fieldName.Split(Delimiter);
        QueryField = queryField;
        FieldType = sqlDbType;
        Operator = @operator;
    }

    public QueryAttribute(string fieldName, SqlDbType fieldType, Operator @operator)
    {
        Fields = fieldName.Split(Delimiter);
        FieldType = fieldType;
        Operator = @operator;
    }

    public QueryAttribute(string fieldName, string queryField, SqlDbType fieldType, Operator @operator, bool hasMultiple)
    {
        Fields = fieldName.Split(Delimiter);
        FieldType = fieldType;
        QueryField = queryField;
        Operator = @operator;
        HasMultipleFields = hasMultiple;
    }

    public QueryAttribute(string fieldName, SqlDbType fieldType, Operator @operator, bool hasJoin, string? joinTable, string? joinColumn)
    {
        Fields = fieldName.Split(Delimiter);
        FieldType = fieldType;
        Operator = @operator;
        HasJoin = hasJoin;
        JoinTable = joinTable;
        JoinColumn = joinColumn;
    }
}

public enum Operator : byte
{
    None = 0,
    [Display(Name = " = ")]
    Equal = 1,
    [Display(Name = " != ")]
    NotEqual = 2,
    [Display(Name = " > ")]
    GreaterThan = 3,
    [Display(Name = " >= ")]
    GreaterThanOrEqual = 4,
    [Display(Name = " < ")]
    LessThan = 5,
    [Display(Name = " <= ")]
    LessThanOrEqual = 6,
    [Display(Name = " LIKE ")]
    Like = 7,
    [Display(Name = " NOT LIKE ")]
    NotLike = 8
}