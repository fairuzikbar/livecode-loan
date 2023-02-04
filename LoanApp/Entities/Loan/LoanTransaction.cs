using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Loan;

[Table(name: "t_loan_transaction")]
public class LoanTransaction
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public LoanType loanType { get; set; }
    public InstallmentType installmentType { get; set; }
    public virtual Customer customer { get; set; }
    
    [Column(name: "nominal")]
    public Double nominal { get; set; }
    
    [Column(name: "approved_at")]
    public long approvedAt { get; set; }
    
    [Column(name: "approved_by")]
    public string approvedBy { get; set; }
    public ApprovalStatus approvalStatus { get; set; }
    public List<TransactionDetail> loanTransactionDetails { get; set; }
    
    [Column(name: "created_at")]
    public long createdAt { get; set; }
    
    [Column(name: "updated_at")]
    public long updatedAt { get; set; }
}