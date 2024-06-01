using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryFarm.Models
{
    public class UsersRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter the role.")]
        [DisplayName("Role")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Role { get; set; }
    }
}
