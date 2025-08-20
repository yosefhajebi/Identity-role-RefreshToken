namespace TestIdentity.Application.Common.Filters;
public class QueryFilter
{
    public List<FilterCondition> Conditions { get; set; } = new();
    public List<SortOption> SortOptions { get; set; } = new();
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public bool Descending { get; set; } = false;
}