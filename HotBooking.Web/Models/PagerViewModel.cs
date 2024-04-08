namespace HotBooking.Web.Models;

public class PagerViewModel
{
    public PagerViewModel(int totalPages, int currentPage)
    {
        TotalPages = totalPages;
        CurrentPage = currentPage;

        int startPage = CurrentPage - 1;
        int endPage = CurrentPage + 1;

        if (startPage <= 0)
        {
            startPage = 1;
        }

        if (endPage > TotalPages)
        {
            endPage = TotalPages;
        }

        StartPage = startPage;
        EndPage = endPage;
    }

    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
}
