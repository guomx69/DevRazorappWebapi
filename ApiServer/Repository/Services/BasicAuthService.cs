// Raw coding to see authentication
//https://www.youtube.com/watch?v=ExQJljpj1lY&list=PLOeFnOV9YBa4yaz-uIi5T4ZW3QQGHJQXi
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using System.Security.Cryptography;

namespace ApiServer.Repository.Service;
    //as a service https://www.youtube.com/watch?v=pY9Rcc3gsAA or https://www.youtube.com/watch?v=z46lqVOv1hQ

    public class BasicAuthService : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AppDbContext _dbContext;
        public BasicAuthService(IOptionsMonitor<AuthenticationSchemeOptions> option, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, AppDbContext dBContext) : base(option, logger, encoder, clock)
        {
            _dbContext = dBContext;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header found");

            var _haedervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_haedervalue.Parameter!=null?_haedervalue.Parameter:string.Empty);
            string credentials = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = getHash(array[1]);
                 var user=await this._dbContext.Users.FirstOrDefaultAsync(item=>item.UserName==username && item.PasswordHash==password);
                 if(user==null)
                   return AuthenticateResult.Fail("UnAuthorized");

                // Generate Ticket
                var claim=new[]{new Claim(ClaimTypes.Name,username)};
                var identity=new ClaimsIdentity(claim,Scheme.Name);
                var principal=new ClaimsPrincipal(identity);
                var ticket=new AuthenticationTicket(principal,Scheme.Name);

                    return AuthenticateResult.Success(ticket);
            }else{
                return AuthenticateResult.Fail("UnAuthorized");

            }
        }
        private  string getHash(string text)  
        {  
            // SHA512 is disposable by inheritance.  
            using(var sha256 = SHA256.Create())  
            {  
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));  
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
            }  
        } 
        //https://www.c-sharpcorner.com/article/hashing-passwords-in-net-core-with-tips/
        private string getSalt()  
        {  
            byte[] bytes = new byte[128 / 8];  
            using(var keyGenerator = RandomNumberGenerator.Create())  
            {  
                keyGenerator.GetBytes(bytes);  
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();  
            }  
        }   
    }

//there are two ways to handle basic authentication using midddleware
//1 https://www.youtube.com/watch?v=3WPbVFMc5JU
//2 https://www.youtube.com/watch?v=tLfYd1U1cAY

//AuthorizationFilterAttribute  instead of the preceding AuthenticationHandler<AuthenticationSchemeOptions>
//https://www.youtube.com/watch?v=tZckljxYjMA


