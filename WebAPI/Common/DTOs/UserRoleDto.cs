using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class UserRoleDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
