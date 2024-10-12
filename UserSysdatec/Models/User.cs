using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UserSysdatec.Models;

public partial class User
{
    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ser una dirección de correo válida.")]
    public string Email { get; set; } = null!;

    public long CountryId { get; set; }

    public long DepartmentId { get; set; }

    public long CityId { get; set; }

    public string Address { get; set; } = null!;

    public string TypeDocument { get; set; } = null!;

    public string NumberDocument { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Image { get; set; }

    public byte? Deleted { get; set; }

    public string? RememberToken { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long CompanyId { get; set; }
    public string? Sal { get; set; }
    public string? Token { get; set; }
    public bool? Status { get; set; }

}
