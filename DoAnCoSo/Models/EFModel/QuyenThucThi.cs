using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models.EFModel
{
    public class QuyenThucThi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string NoiDung { get; set; }
        [ForeignKey("QuyenThucThiID")]
        public List<UserGroup> DanhSachUserGroup { get; set; }
    }
}
