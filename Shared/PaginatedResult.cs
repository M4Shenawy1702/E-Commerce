    namespace Shared
{
    public record PaginatedResult<TData>(int PageIndex, int PageSize, int TotalCount , IEnumerable<TData> Data);   
}
