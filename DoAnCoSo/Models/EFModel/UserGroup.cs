using DoAnCoSo.Models.EFModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
    public class UserGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Length(1, 40, ErrorMessage = "Tên nhóm không quá 40 ký tự")]
        public string NameGroup { get; set; }
        [ForeignKey("UserGroupID")]
        public List<User> Users { get; set; }
        [ForeignKey("UserGroupID")]
        public List<QuyenThucThi> DanhSachQuuyenThucThi { get; set;}
    }
}
