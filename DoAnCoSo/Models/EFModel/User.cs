using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không để trống tên")]
        [Length(1, 50, ErrorMessage = "Tên tối thiểu là 1 tối đa 50 ký tự")]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Decription { get; set; }
        [ForeignKey("UserID")]
        public List<UserGroup> UserGroupIn { get; set; }
        [DefaultValue(false)]
        public bool Blocked { get; set; }
    }
}
