﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class RoomFeature
{
    [Required]
    public int FeatureId { get; set; }

    [Required, ForeignKey(nameof(FeatureId))]
    public Feature Feature { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [Required, ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;
}
