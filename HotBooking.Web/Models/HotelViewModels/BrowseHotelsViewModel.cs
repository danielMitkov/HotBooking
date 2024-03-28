using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.HotelViewModels;

public class BrowseHotelsViewModel
{
    [Required]
    public SearchHotelsViewModel Search { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(HotelSorting))]
    public HotelSorting Sorting { get; set; }

    public int Page { get; set; } = 1;

    public ICollection<Guid> SelectedFacilityIds { get; set; } = new List<Guid>();


    public PagerViewModel? Pager { get; set; }

    public ICollection<PreviewHotelDto> Hotels { get; set; } = new List<PreviewHotelDto>();

    public ICollection<FacilityDto> Facilities { get; set; } = new List<FacilityDto>();
}
