namespace HotBooking.Web.Models;

public class Pager
{
    public Pager()
    {

    }

    public Pager(int totalItems, int page, int pageSize)
    {
        int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
        int currentPage = page;

        int startPage = currentPage - 1;
        int endPage = currentPage + 1;

        if (startPage <= 0)
        {
            startPage = 1;
        }

        if (endPage > totalPages)
        {
            endPage = totalPages;
        }

        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;

        TotalPages = totalPages;
        StartPage = startPage;
        EndPage = endPage;
    }

    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }

    public int TotalPages { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
}
