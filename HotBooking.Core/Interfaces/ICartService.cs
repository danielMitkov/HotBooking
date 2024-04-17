using HotBooking.Core.Models.DTOs.CartDtos;

namespace HotBooking.Core.Interfaces;

public interface ICartService
{
    Task<Guid> AddAsync(CartAddDto addDto);
}
