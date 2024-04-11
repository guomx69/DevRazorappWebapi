
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
namespace WebApp.AccessLayer;
    public class ApiRoleDataAccess:IRoleDataAccess
    {
      private readonly ILogger<ApiRoleDataAccess> _logger;
      private readonly IHttpClientFactory _clientFactory;
      private readonly string _apiUrl;
      //private List<IdentityRole> _users;
   
   
        public ApiRoleDataAccess(ILogger<ApiRoleDataAccess> logger,IHttpClientFactory clientFactory,IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _apiUrl=configuration.GetValue<string>("DataAPI:inUseAPI");
            //_users = new List<IdentityRole>();
            
        }
        
        public  async Task<bool> CreateRoleAsync(IdentityRole role)
        {   throw new NotImplementedException();
            // bool apiResponse=false;
            // using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            // {              
            //     using (HttpResponseMessage response = await httpClient.PostAsJsonAsync<IdentityRole>(_apiUrl+"/Auth/CreateRole",role))
            //     {                   
            //         apiResponse = response.IsSuccessStatusCode;              
            //     }
            // }
            // return apiResponse;
        }
        public bool Update(IdentityRole role)
        {
            // Since get role gets the role from the same in-memory list,
            // the role parameter is the same as the object in the list, so nothing needs to be updated here.
            return true;
        }
        public async Task<IdentityRole> GetRoleById(string id)
        {
           throw new NotImplementedException();
           //System.Console.WriteLine("GetRoleById by Console:role:"+id);
           // return await GetRoleAsync("/Auth/GetIRoleById/"+id);
        }
       
        public async Task<IdentityRole> GetRoleByRolename(string rolename)
        {
           throw new NotImplementedException();
           //System.Console.WriteLine("GetRoleById by Console:role:"+rolename);
           //return await GetRoleAsync("/Auth/GetIRoleByName/"+rolename);
        }


        
        public string GetNormalizedRolename(IdentityRole role)
        {
            return role.NormalizedName;
        }
        private async Task<IdentityRole> GetRoleAsync(string uri)
        {
            IdentityRole apiResponse=null; //new IdentityRole();
            using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(_apiUrl+uri))
                {
                    if(response.IsSuccessStatusCode && response.ReasonPhrase!="No Content")
                    apiResponse = await response.Content.ReadFromJsonAsync<IdentityRole>();
                }
            }
            return apiResponse;
        }
    }