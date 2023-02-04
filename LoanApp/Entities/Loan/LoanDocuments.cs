using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Loan;

[Table(name: "t_loan_documents")]
public class LoanDocuments
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "customer_id")]
    public string Name { get; set; }
    
    [Column(name: "content_type", TypeName = "varchar(50)")]
    public string ContentType { get; set; }
    
    [Column(name: "url", TypeName = "varchar(250)")]
    public string Url { get; set; }
    
    [Column(name: "size")]
    public long Size { get; set; }
    
    public virtual Customer Customer { get; set; }
}