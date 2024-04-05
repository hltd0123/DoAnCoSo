using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
    public class OpLung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không để trống tên")]
        [Length(1, 50, ErrorMessage = "Tên tối thiểu là 1 tối đa 50 ký tự")]
        public string Name { get; set; }
        [Length(0, 100, ErrorMessage = "Tên tối thiểu là 0 tối đa 1-0 ký tự")]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("OpLungID")]
        public DienThoai? DienThoaiLienKet { get; set; }
        [DefaultValue(false)]
        public bool Blocked { get; set; }
    }
}
