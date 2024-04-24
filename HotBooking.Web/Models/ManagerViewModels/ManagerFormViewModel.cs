using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.ManagerViewModels;

public class ManagerFormViewModel
{
    [Required]
    [MinLength(ManagerConstants.CompanyNameLengthMin)]
    [MaxLength(ManagerConstants.CompanyNameLengthMax)]
    public string CompanyName { get; set; } = null!;

    [Required]
    [MinLength(ManagerConstants.DepartmentLengthMin)]
    [MaxLength(ManagerConstants.DepartmentLengthMax)]
    public string Department { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{10}$",
        ErrorMessage = "Please enter a valid 10-digit phone number.")]
    public string PhoneNumber { get; set; } = null!;
}
