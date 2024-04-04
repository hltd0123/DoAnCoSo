
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Models
{
    public class DienThoaiAction
    {
        private readonly contextDatabase _db;
        public DienThoaiAction(contextDatabase db)
        {
            _db = db;
        }
        public async Task<bool> AddDienThoaiAsync(DienThoai dienThoai)
        {
            try
            {
                _db.DienThoais.Add(dienThoai);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<DienThoai?> GetDienThoaiByIdAsync(int id)
        {
            return await _db.DienThoais.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<DienThoai?> GetDienThoaiByNameAsync(string nameDienThoai)
        {
            return await _db.DienThoais.SingleOrDefaultAsync(p => p.Name.Equals(nameDienThoai, StringComparison.InvariantCulture));
        }

        public async Task<List<DienThoai>> GetListDienThoaiAsync()
        {
            return await _db.DienThoais.ToListAsync();
        }

        public async Task<string> RemoveDienThoaiAsync(int id)
        {
            try
            {
                DienThoai find = await GetDienThoaiByIdAsync(id);
                if (find != null)
                {
                    find.Blocked = true;
                    await UpdateDienThoaiAsync(find);
                    return find.Name;
                }
                return "false";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public async Task<string> UpdateDienThoaiAsync(DienThoai x)
        {
            try
            {
                _db.DienThoais.Update(x);
                await _db.SaveChangesAsync();
                return x.Name;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
