using HackathonMonolito.DTO;
using Microsoft.EntityFrameworkCore;

namespace HackathonMonolito.Configuration;


public static class QueryableExtensions
{
    public static async Task<PagedResponse<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> source, 
        int pageNumber, 
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken);
        
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResponse<T>
        {
            Data = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = count,
            TotalPages = count > 0 ? (int)Math.Ceiling(count / (double)pageSize) : 0
        };
    }
}
