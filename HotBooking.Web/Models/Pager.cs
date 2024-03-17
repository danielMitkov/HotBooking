﻿namespace HotBooking.Web.Models;

public class Pager<T>
{
    public Pager(int totalPages, int currentPage, string controllerName, string actionName, string? city)
    {
        TotalPages = totalPages;
        CurrentPage = currentPage;

        ControllerName = controllerName;
        ActionName = actionName;
        City = city;

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

    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string? City { get; set; }

    public int StartPage { get; set; }
    public int EndPage { get; set; }
}
