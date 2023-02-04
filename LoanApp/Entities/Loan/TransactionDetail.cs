using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Entities.Loan;

[Table(name: "t_transaction_detail")]
public class TransactionDetail
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "transaction_date")]
    public long TransactionDate { get; set; }
    
    [Column(name: "nominal")]
    public double Nominal { get; set; }
    
    public LoanTransaction LoanTransaction { get; set; }
    public GuaranteePicture GuaranteePicture { get; set; }
    public LoanStatus LoanStatus { get; set; }
    
    [Column(name: "created_date")]
    public long CreatedDate { get; set; }
    
    [Column(name: "updated_date")]
    public long UpdatedDate { get; set; }
}