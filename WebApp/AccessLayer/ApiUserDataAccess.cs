
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
namespace WebApp.AccessLayer;
    public class ApiUserDataAccess:IUserDataAccess
    {
      private readonly ILogger<ApiUserDataAccess> _logger;
      private readonly IHttpClientFactory _clientFactory;
      private readonly string _apiUrl;
      private List<IdentityUser> _users;
   
   
        public ApiUserDataAccess(ILogger<ApiUserDataAccess> logger,IHttpClientFactory clientFactory,IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _apiUrl=configuration.GetValue<string>("DataAPI:inUseAPI");
            _users = new List<IdentityUser>();
            
        }
        
        public  async Task<bool> CreateUserAsync(IdentityUser user)
        //public  bool CreateUser(IdentityUser user)
        {   //System.Console.WriteLine("Data From Client::"+_apiUrl); // _users.Add(user); // return true;_logger.LogInformation("CreateUserAsync by Logger:User:",user);
            //string jsonString = JsonSerializer.Serialize(user);  System.Console.WriteLine("CreateUserAsync by Console:User:"+jsonString);
            bool apiResponse=false;
            using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            {              
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync<IdentityUser>(_apiUrl+"/Auth/RegisterIUser",user))
                {                   
                    apiResponse = response.IsSuccessStatusCode;              
                }
            }
            return apiResponse;
        }
         

         public async Task<bool> IsInRole(string userId, string rolename)
        {
            bool apiResponse=false; 
            using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(_apiUrl+"/auth/IsInRole/"+userId+"/"+rolename))
                {
                    //apiResponse = await response.Content.ReadAsStringAsync<bool>();
                    apiResponse=response.IsSuccessStatusCode;
                }
            }
            return apiResponse;
        }
        
         public async Task<IList<string>> GetRolesAsync (string userId)
         {
             IList<string> apiResponse=null; 
            using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(_apiUrl+"/auth/GetRolesAsync/"+userId))
                {
                   apiResponse = await response.Content.ReadFromJsonAsync<IList<string>> ();
                  
                }
            }
            return apiResponse;
         }

        public bool Update(IdentityUser user)
        {
            // Since get user gets the user from the same in-memory list,
            // the user parameter is the same as the object in the list, so nothing needs to be updated here.
            return true;
        }
        public async Task<IdentityUser> GetUserById(string id)
        {
           // return _users.FirstOrDefault(u => u.Id == id);
             System.Console.WriteLine("GetUserById by Console:User:"+id);
            return await GetUserAsync("/Auth/GetIUserById/"+id);
        }
        public async Task<IdentityUser> GetByPhoneNumber(string phone)
        {
            //return _users.FirstOrDefault(u => u.PhoneNumber == phone);
              System.Console.WriteLine("GetUserById by Console:User:"+phone);
             return await GetUserAsync("/Auth/GetIUserByPhone/"+phone);
        }
        public async Task<IdentityUser> GetUserByUsername(string username)
        {
           //return _users.FirstOrDefault(u => u.NormalizedUserName == username);
              System.Console.WriteLine("GetUserById by Console:User:"+username);
           return await GetUserAsync("/Auth/GetIUserByUsername/"+username);
        }


        
        public string GetNormalizedUsername(IdentityUser user)
        {
            return user.NormalizedUserName;
        }
        private async Task<IdentityUser> GetUserAsync(string uri)
        {
            IdentityUser apiResponse=null; //new IdentityUser();
            using (var httpClient = _clientFactory.CreateClient(_apiUrl)) //localhost:7024
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(_apiUrl+uri))
                {
                    if(response.IsSuccessStatusCode && response.ReasonPhrase!="No Content")
                    apiResponse = await response.Content.ReadFromJsonAsync<IdentityUser>();
                }
            }
            return apiResponse;
        }
    }