using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public IConfiguration Configuration { get; }
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, 
            ISystemClock clock, IConfiguration configuration) 
            : base(options, logger, encoder, clock)
        {

            Configuration = configuration;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string username = credentials[0];
                string password = credentials[1];
                var authenticationSection = Configuration.GetSection("authentication");

                string adminLogin = authenticationSection["adminlogin"];
                string adminPassword = authenticationSection["adminpassword"];

                if(username != null && password != null)
                {
                    if(username == adminLogin && password == adminPassword)
                    {
                        var claim = new[] { new Claim(ClaimTypes.Name, username) };
                        var identity = new ClaimsIdentity(claim,Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal,Scheme.Name);

                       return AuthenticateResult.Success(ticket);
                    }
                }
                else
                {
                   return AuthenticateResult.Fail("UnAuthorized");
                }
            }
            catch (Exception)
            {

                return AuthenticateResult.Fail("Error has occured");
            }

            return AuthenticateResult.Fail("UnAuthorized");

        }
    }

}