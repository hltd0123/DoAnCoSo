
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace DoAnCoSo.Models 
{
    public class UserAction
    {
        private readonly contextDatabase _db;
        public UserAction(contextDatabase db) 
        {
            _db = db;
        }
        public async Task<bool> AddUserAsync(User user)
        {
            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    trans.Commit();
                    _db.Users.Add(user);
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

        public Task<bool> BlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckExitCantAdd(string userName, string email)
        {
            return await _db.Users.SingleOrDefaultAsync(p => p.Name == userName || p.Email == email) != null;
        }

        public async Task<List<User>> GetListUserAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            return await _db.Users.Include(p => p.UserGroupIn).SingleOrDefaultAsync(p => p.Name == userName);
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _db.Users.SingleOrDefaultAsync(p => p.Email == email);
        }

        public async Task<string> RemoveUserAsync(string userName)
        {
            User? find = await _db.Users.SingleOrDefaultAsync(p => p.Name == userName);
            if (find != null)
            {
                find.Blocked = true;
                await UpdateUserAsync(find);
                return userName;
            }

            return "false";
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            try
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                return user.Name;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
