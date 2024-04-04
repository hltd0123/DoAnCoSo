
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Models
{
    public class LoginAction
    {
        private readonly UserAction _UserAction;
        public LoginAction(UserAction db)
        {
            _UserAction = db;
        }
        public async Task<bool> CheckExistAsyn(string userName, string email)
        {
            return await _UserAction.CheckExitCantAdd(userName, email);
        }

        public async Task<bool> CheckLoginAsyn(string userName, string password, bool isAdminLogin = false)
        {
            User? findingUser = await _UserAction.GetUserAsync(userName);
            if (findingUser == null)
            {
                return false;
            }
            if (findingUser.Password == password)
            {
                if (isAdminLogin && findingUser.UserGroupIn.SingleOrDefault(p => p.Id == Role.Admin) != null)
                {
                    return true;
                } 
                if (!isAdminLogin)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> SignInAsyn(User inputUser)
        {
            try
            {
                await _UserAction.AddUserAsync(inputUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
