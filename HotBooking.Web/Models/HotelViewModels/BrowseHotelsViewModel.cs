using HotBooking.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.HotelViewModels;

public class BrowseHotelsViewModel
{
    public string? City { get; set; }

    public int Page { get; set; } = 1;

    [Required]
    [EnumDataType(typeof(HotelSorting))]
    public HotelSorting Sorting { get; set; }


    public string? CitiesJson { get; set; }

    public Pager? Pager { get; set; }

    public IEnumerable<PreviewHotelViewModel> Hotels { get; set; } = new List<PreviewHotelViewModel>();
}
