using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using System.Collections;
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

    public IEnumerable<Guid> SelectedFacilityIds { get; set; } = new List<Guid>();


    public PagerViewModel? Pager { get; set; }

    public IEnumerable<HotelPreviewDto> Hotels { get; set; } = new List<HotelPreviewDto>();

    public IEnumerable<FacilityChecksDto> Facilities { get; set; } = new List<FacilityChecksDto>();

    public int AllHotelsCount { get; set; }
}
