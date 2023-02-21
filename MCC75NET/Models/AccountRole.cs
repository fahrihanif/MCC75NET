using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC75NET.Models;

[Table("tb_tr_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("account_nik", TypeName = "nchar(5)")]
    public string AccountNIK { get; set; }
    [Required, Column("role_id")]
    public int RoleId { get; set; }

    // Relation & Cardinality
    [ForeignKey(nameof(AccountNIK))]
    public Account? Account { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}
