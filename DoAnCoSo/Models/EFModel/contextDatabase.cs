using DoAnCoSo.Models.EFModel;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Models
{
    public class contextDatabase: DbContext
    {
        public contextDatabase(DbContextOptions<contextDatabase> options): base(options) { }

        public DbSet<OpLung> OpLungs { get; set; }
        public DbSet<DienThoai> DienThoais { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UsersGroups { get; set; }
        public DbSet<QuyenThucThi> DSQuyenThucThi { get; set; }
    }
}
