using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Loan;

[Table(name: "t_guarantee_picture")]
public class GuaranteePicture
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "name", TypeName = "varchar(50)")]
    public string Name { get; set; }
    
    [Column(name: "content_type", TypeName = "varchar(50)")]
    public string ContentType { get; set; }
    
    [Column(name: "path", TypeName = "varchar(250)")]
    public string Path { get; set; }
    
    [Column(name: "size")]
    public long Size { get; set; }
}