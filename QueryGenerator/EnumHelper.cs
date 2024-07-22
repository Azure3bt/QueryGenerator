using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QueryGenerator;

public static class EnumHelper
{
    public static string GetDisplayValue(this Enum @enum)
    {
        return @enum.GetType().GetField(@enum.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
    }
}
