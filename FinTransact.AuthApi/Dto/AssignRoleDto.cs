using System.ComponentModel.DataAnnotations;

namespace FinTransact.AuthApi.Dto;

public class AssignRoleDto
{
    [Required] public string Email { get; set; }
    [Required] public string Role { get; set; }
}