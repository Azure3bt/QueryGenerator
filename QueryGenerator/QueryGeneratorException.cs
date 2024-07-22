using System;

namespace QueryGenerator;

public class QueryGeneratorException : Exception
{
    public QueryGeneratorException(string message) : base(message) { }
}
