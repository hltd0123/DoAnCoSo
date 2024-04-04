
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAnCoSo.Models 
{
    public class OpLungAction
    {
        private readonly contextDatabase _db;
        public OpLungAction(contextDatabase db)
        {
            _db = db;
        }
        public async Task<bool> AddOpLungAsync(OpLung opLung)
        {
            using(var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    trans.Commit();
                    _db.OpLungs.Add(opLung);
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<List<OpLung>> GetListOpLungAsync()
        {
            return await _db.OpLungs.ToListAsync();
        }

        public async Task<OpLung?> GetOpLungByIdAsync(int id)
        {
            return await _db.OpLungs.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<OpLung?> GetOpLungByNameAsync(string nameOp)
        {
            return await _db.OpLungs.SingleOrDefaultAsync(p => p.Name == nameOp);
        }

        public async Task<string> RemoveOpLungiAsync(int id)
        {
            try
            {
                OpLung find = await GetOpLungByIdAsync(id);
                if (find != null)
                {
                    find.Blocked = true;
                    await UpdateOpLungAsync(find);
                    return find.Name;
                }
                return "false";
            }
            catch (Exception e)
            {
                return "error";
            }

        }

        public async Task<string> UpdateOpLungAsync(OpLung x)
        {
            try
            {
                _db.OpLungs.Update(x);
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
