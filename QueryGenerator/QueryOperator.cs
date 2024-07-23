namespace QueryGenerator;

public enum QueryOperator : byte
{
    None = 0,
    Equal = 1,
    NotEqual = 2,
    GreaterThan = 3,
    GreaterThanOrEqual = 4,
    LessThan = 5,
    LessThanOrEqual = 6,
    Like = 7,
    NotLike = 8
}