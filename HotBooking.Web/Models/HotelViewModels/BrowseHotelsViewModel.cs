using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Core.Models.DTOs.HotelDtos;
using HotBooking.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.HotelViewModels;

public class BrowseHotelsViewModel
{
    public SearchHotelsViewModel? SearchModel { get; set; }

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
