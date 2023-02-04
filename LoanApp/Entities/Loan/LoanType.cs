using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Loan;

[Table(name: "m_loan_type")]
public class LoanType
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "type", TypeName = "varchar(50)")]
    public string Type { get; set; }
    
    [Column(name: "max_loan")]
    public Double MaxLoan { get; set; }
}