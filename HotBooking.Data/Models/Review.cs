﻿using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Review : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal RatingScore { get; set; }

    [Required]
    [MaxLength(ReviewConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ReviewConstants.CommentMax)]
    public string Comment { get; set; } = null!;

    [Required]
    public DateTime ReviewedOn { get; set; } = DateTime.Now;

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    [Required]
    public int BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public Booking Booking { get; set; } = null!;

    [Required]
    public int AuthorId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public ApplicationUser Author { get; set; } = null!;
}
