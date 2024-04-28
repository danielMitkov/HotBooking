using HotBooking.Core.Models.DTOs.ManagerDtos;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.ManagerViewModels;

public class ManagerMyRoomsViewModel
{
    [Required]
    public Guid HotelId { get; set; }

    public ICollection<ManagerRoomPreviewDto> Rooms { get; set; }
    = new List<ManagerRoomPreviewDto>();
}
