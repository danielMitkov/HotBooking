﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class ApplicationUser : IdentityUser<int>
{
    [Required]
    public bool IsActive { get; set; } = true;

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
