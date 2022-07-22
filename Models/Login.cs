using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        public int RoleType { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string ? UserID { get; set; }
        [Column(TypeName = "varchar(200)")]

        public string ? Name { get; set; }
        [Column(TypeName = "varchar(200)")]

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ? Password { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}
