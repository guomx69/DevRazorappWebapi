using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApp.AccessLayer;
public class ApiRoleStore : IRoleStore<IdentityRole>
    {
        private ApiRoleDataAccess _dataAccess;
        public ApiRoleStore(ApiRoleDataAccess da)
        {
            _dataAccess = da;
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
           
            IdentityResult result = IdentityResult.Failed();
            bool createResult =await _dataAccess.CreateRoleAsync(role);

            if (createResult)
            {
                result = IdentityResult.Success;
            }

            return result;
           
        }
      

        public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return Task<IdentityRole>.Run(() =>
            {
                return _dataAccess.GetRoleById(roleId);
            });
        }

        public Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return Task<IdentityRole>.Run(() =>
            {
                return _dataAccess.GetRoleByRolename(normalizedRoleName);
            });
        }




        public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {

        }
       

      

          public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return role.NormalizedName;
            });
        }

        
        public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return role.Id;
            });
        }

        public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return role.NormalizedName;
            });
        }

        

        public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                role.NormalizedName = normalizedName;
            });
        }

     
        public Task SetRoleNameAsync(IdentityRole role, string userName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                role.Name = userName;
                role.NormalizedName = userName.ToUpper();
            });
        }

        public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task<IdentityResult>.Run(() =>
            {
                IdentityResult result = IdentityResult.Failed();
                bool updateResult = _dataAccess.Update(role);

                if (updateResult)
                {
                    result = IdentityResult.Success;
                }

                return result;
            });
        }
    }