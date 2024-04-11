using Microsoft.AspNetCore.Identity;

namespace WebApp.AccessLayer;
public class ApiUserStore : IUserPasswordStore<IdentityUser>, IUserPhoneNumberStore<IdentityUser>,IUserRoleStore<IdentityUser> 
    {
        private ApiUserDataAccess _dataAccess;
        public ApiUserStore(ApiUserDataAccess da)
        {
            _dataAccess = da;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            //return Task<IdentityResult>.Run(async () =>  {
            IdentityResult result = IdentityResult.Failed();
            bool createResult =await _dataAccess.CreateUserAsync(user);

            if (createResult)
            {
                result = IdentityResult.Success;
            }

            return result;
            //});
        }
        public Task<IdentityUser> FindByPhoneNumberAsync(string normalizedPhoneNumber, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetByPhoneNumber(normalizedPhoneNumber);
            });
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetUserById(userId);
            });
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetUserByUsername(normalizedUserName);
            });
        }

        public Task AddToRoleAsync (IdentityUser user, string roleName, System.Threading.CancellationToken cancellationToken)
        {
              throw new NotImplementedException();
        }
         public Task RemoveFromRoleAsync (IdentityUser user, string roleName, System.Threading.CancellationToken cancellationToken)
        {
              throw new NotImplementedException();
        }
        public Task<IList<string>> GetRolesAsync (IdentityUser user, System.Threading.CancellationToken cancellationToken)
         
        {
              //throw new NotImplementedException();
               return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetRolesAsync(user.Id);
            });
        }
        public Task<bool> IsInRoleAsync (IdentityUser user,string role, System.Threading.CancellationToken cancellationToken)
         
        {
              //throw new NotImplementedException();
              return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.IsInRole(user.Id,role);
            });
        }
        public Task<IList<IdentityUser>> GetUsersInRoleAsync (string role, System.Threading.CancellationToken cancellationToken)
         
        {
              throw new NotImplementedException();
                
        }



        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {

        }
        public Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
        {
                return Task<string>.Run(() =>
                {
                    return user.PhoneNumber;
                });
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() =>
            {
                return user.PhoneNumberConfirmed;
            });
        }

          public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.NormalizedUserName;
            });
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() => { return user.PasswordHash; });
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.Id;
            });
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.UserName;
            });
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() => { return true; });
        }

        public Task SetPhoneNumberAsync(IdentityUser user, string phone, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                user.PhoneNumber = phone;
            });
        }

        public Task SetPhoneNumberConfirmedAsync (IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.PhoneNumberConfirmed = confirmed;
            });
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedUserName = normalizedName;
            });
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() => { user.PasswordHash = passwordHash; });
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.UserName = userName;
                user.NormalizedUserName = userName.ToUpper();
            });
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<IdentityResult>.Run(() =>
            {
                IdentityResult result = IdentityResult.Failed();
                bool updateResult = _dataAccess.Update(user);

                if (updateResult)
                {
                    result = IdentityResult.Success;
                }

                return result;
            });
        }
    }