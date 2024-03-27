﻿namespace HotBooking.Core.Exceptions;

public class PageOutOfRangeException : Exception
{
    public PageOutOfRangeException(int max)
    : base($"The Page Number must be between 1 and {max}")
    {
    }
}