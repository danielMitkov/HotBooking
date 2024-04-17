using HotBooking.Core.Models.DTOs.CartDtos;

namespace HotBooking.Core.Interfaces;

public interface ICartService
{
    Task AddAsync(CartAddDto addDto);
}
