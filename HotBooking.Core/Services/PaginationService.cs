using HotBooking.Core.Interfaces;
using HotBooking.Data.Models;

namespace HotBooking.Core.Services;

public class PaginationService : IPaginationService
{
    public string ErrorMessage { get; private set; } = string.Empty;

    public int? GetTotalPages(int allHotelsCount, int pageSize, int currentPage)
    {
        int totalPages = (int)Math.Ceiling(allHotelsCount / (decimal)pageSize);

        if (currentPage < 1 || currentPage > totalPages)
        {
            ErrorMessage = $"The Page Number must be between 1 and {totalPages}";//extract message
            return null;
        }

        return totalPages;
    }

    public IQueryable<Hotel> ApplyPagination(IQueryable<Hotel> query, int pageSize, int currentPage)
    {
        int skipAmount = (currentPage - 1) * pageSize;

        query = query
            .Skip(skipAmount)
            .Take(pageSize);

        return query;
    }
}
