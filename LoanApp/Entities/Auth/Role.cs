using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Auth;

[Table(name: "m_role")]
public class Role
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private string Id { get; set; }
    
    [Column(name: "role_name", TypeName = "varchar(50)")]
    private string RoleName { get; set; }
}