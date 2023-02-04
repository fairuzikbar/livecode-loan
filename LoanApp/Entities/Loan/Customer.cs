using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoanApp.Entities.Auth;

namespace LoanApp.Entities.Loan;

[Table(name: "m_customer")]
public class Customer
{
    [Key, Column(name: "id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    
    [Column(name: "last_name", TypeName = "varchar(50)")]
    public string LastName { get; set; }
    
    [Column(name: "dob")]
    public DateTime DateOfBirth { get; set; }
    
    [Column(name: "phone", TypeName = "varchar(14)")]
    public string Phone { get; set; }
    
    // public AppUser User { get; set; }
    public ProfilePicture? ProfilePicture { get; set; }
    public ICollection<LoanDocuments>? LoanDocuments { get; set; }
}