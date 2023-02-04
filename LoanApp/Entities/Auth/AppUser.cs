using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Auth;

[Table(name: "m_user")]
public class AppUser
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private string Id { get; set; }
    
    [Column(name: "email", TypeName = "varchar(50)")]
    private string Email {get; set;}
    
    [Column(name: "password", TypeName = "varchar(50)")]
    private string Password {get; set;}
    
    private ICollection<Role> Roles {get; set;}
}