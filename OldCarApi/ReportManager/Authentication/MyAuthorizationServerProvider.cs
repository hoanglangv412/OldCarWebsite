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
            CustomerModel customerModel = new CustomerModel();
            CustomerModel objDB = new CustomerModel();

            customerModel = objDB.checkExist(context.UserName, context.Password);

            if (customerModel != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, customerModel.Account_role == 0 ? "admin" : "user"));
                identity.AddClaim(new Claim("username", customerModel.Account_name));
                identity.AddClaim(new Claim(ClaimTypes.Name, customerModel.Customer_id.ToString()));
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