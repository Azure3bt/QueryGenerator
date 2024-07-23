namespace QueryGenerator;

public static class EnumHelper
{
    public static string GetDisplayValue(this QueryOperator queryOperator)
    {
        //return @enum.GetType().GetField(@enum.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
        return queryOperator switch
        {
            QueryOperator.Equal => " = ",
            QueryOperator.NotEqual => " != ",
            QueryOperator.GreaterThan => " > ",
            QueryOperator.GreaterThanOrEqual => " >= ",
            QueryOperator.LessThan => " < ",
            QueryOperator.LessThanOrEqual => " <= ",
            QueryOperator.Like => " LIKE ",
            QueryOperator.NotLike => " NOT LIKE ",
            _ => string.Empty
        };
    }
}
