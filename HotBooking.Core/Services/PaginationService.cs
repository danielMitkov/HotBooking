using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Data.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace HotBooking.Core.Services;

public class PaginationService: IPaginationService
{
    public int GetTotalPages(int allHotelsCount, int pageSize, int currentPage)
    {
        int totalPages = (int)Math.Ceiling(allHotelsCount / (decimal)pageSize);

        if (currentPage < 1 || currentPage > totalPages)
        {
            throw new PageOutOfRangeException(totalPages);
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
