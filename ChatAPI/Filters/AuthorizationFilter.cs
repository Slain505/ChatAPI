using System;
using System.Text;
using System.Threading.Tasks;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAPI.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();
            var authHeader = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authHeader))
            {
                context.Result = new UnauthorizedResult();
                return Task.CompletedTask;
            }
            
            try
            {
                authHeader = authHeader.ToString().Split(' ')[1]; 
                byte[] credentialBytes = Convert.FromBase64String(authHeader);
                string credentials = Encoding.UTF8.GetString(credentialBytes);
                var userDataArray = credentials.Split(':');

                foreach (var user in userRepository.GetUserList())
                {
                    if (user.Username == userDataArray[0] && user.PasswordHash == userDataArray[1].ComputeSha256Hash())
                    {
                        return Task.CompletedTask;
                    }
                }
                context.Result = new UnauthorizedResult();
                return Task.CompletedTask;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid base64 string");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
                throw;
            }
            
            context.Result = new NotFoundResult();

            return Task.CompletedTask;
        }
    }
}