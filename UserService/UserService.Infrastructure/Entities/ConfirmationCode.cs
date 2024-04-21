using System.ComponentModel.DataAnnotations;

namespace UserService.Infrastructure.Entities;

public class ConfirmationCode
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Code { get; set; }
}
