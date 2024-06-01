using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DiaryFarm.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        public string? LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(Max)")]
        public string? username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(Max)")]
        [MaxLength(6)]
        public string? password { get; set; }

        [Required]
        public long RoleId { get; set; }

        [Required]
        public bool Active { get; set; }


    }
}
