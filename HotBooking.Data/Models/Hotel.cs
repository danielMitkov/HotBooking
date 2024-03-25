﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotBooking.Data.Constants;

namespace HotBooking.Data.Models;

public class Hotel : BaseEntity
{
    public Hotel()
    {
        Facilities = new HashSet<Facility>();
        Rooms = new HashSet<Room>();
        HotelImages = new HashSet<HotelImageUrl>();
        Reviews = new HashSet<Review>();
        Bookings = new HashSet<Booking>();
    }

    [Required]
    [MaxLength(HotelConstants.HotelNameLengthMax)]
    public string HotelName { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.DescriptionLengthMax)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.StreetAddressLengthMax)]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.CityNameLengthMax)]
    public string CityName { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.CountryNameLengthMax)]
    public string CountryName { get; set; } = null!;

    [Required]
    public int StarRating { get; set; }

    [Required]
    public int ManagerId { get; set; }

    [ForeignKey(nameof(ManagerId))]
    public Manager Manager { get; set; } = null!;

    public ICollection<Facility> Facilities { get; set; }

    public ICollection<Room> Rooms { get; set; }

    public ICollection<HotelImageUrl> HotelImages { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}
