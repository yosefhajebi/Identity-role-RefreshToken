namespace TestIdentity.Application.Common.Filters;
public class FilterCondition
{
    public string PropertyName { get; set; } = string.Empty;
    public object? Value { get; set; }
    public FilterOperator Operator { get; set; } = FilterOperator.Equals;
}