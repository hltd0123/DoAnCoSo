using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
    public class DienThoai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không để trống tên")]
        [Length(1,50,ErrorMessage ="Tên tối thiểu là 1 tối đa 50 ký tự")]
        public string Name { get; set; }
        [ForeignKey("DienThoaiID")]
        List<OpLung> DanhSachOpLung { get; set; }
        [DefaultValue(false)]
        public bool Blocked { get; set; }
    }
}
