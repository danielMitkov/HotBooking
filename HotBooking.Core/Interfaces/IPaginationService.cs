﻿using HotBooking.Data.Models;

namespace HotBooking.Core.Interfaces;

public interface IPaginationService : IErrorMessageProp
{
    int? GetTotalPages(int allHotelsCount, int pageSize, int currentPage);
    IQueryable<Hotel> ApplyPagination(IQueryable<Hotel> query, int pageSize, int currentPage);
}
