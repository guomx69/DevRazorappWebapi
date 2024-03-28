using Microsoft.AspNetCore.Identity;

namespace WebApp.AccessLayer;
public class InMemoryUserStore : IUserPasswordStore<IdentityUser>, IUserPhoneNumberStore<IdentityUser>
    {
        private InMemoryUserDataAccess _dataAccess;
        public InMemoryUserStore(InMemoryUserDataAccess da)
        {
            _dataAccess = da;
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<IdentityResult>.Run(() =>
            {
                IdentityResult result = IdentityResult.Failed();
                bool createResult = _dataAccess.CreateUser(user);

                if (createResult)
                {
                    result = IdentityResult.Success;
                }

                return result;
            });
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

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

        // public Task<string> GetNormalizedPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
        // {
        //     return Task<string>.Run(() =>
        //     {
        //         return user.NormalizedPhoneNumber;
        //     });
        // }

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

        // public Task SetNormalizedPhoneNumberAsync(IdentityUser user, string normalizedPhoneNumber, CancellationToken cancellationToken)
        // {
        //     return Task.Run(() =>
        //     {
        //         user.NormalizedPhoneNumber = normalizedPhoneNumber;
        //     });
        // }

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