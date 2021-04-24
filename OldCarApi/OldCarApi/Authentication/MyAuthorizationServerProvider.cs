using Microsoft.Owin.Security.OAuth;
using OldCarApi.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace webApiTokenAuthentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            CustomerModel account = new CustomerModel();
            CustomerModel customerModel = new CustomerModel();

            account = customerModel.checkExist(context.UserName, context.Password);

            if (account != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", account.Account_name));
                identity.AddClaim(new Claim(ClaimTypes.Name, account.Customer_name));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Autorization Error", "The username or password is incorrect!");
                context.Response.Headers.Add("AuthorizationResponse", new[] { "Failed" });
            }
        }
    }
}