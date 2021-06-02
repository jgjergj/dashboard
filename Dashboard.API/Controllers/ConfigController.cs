using Microsoft.AspNetCore.Mvc;

namespace Dashboard.API.Controllers
{
    [Route("/_configuration/Dashboard.Api")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new {
                authority= "https://localhost:44304",
                client_id= "vue-client",
                redirect_uri= "http://localhost:8080",
                response_type= "code",
                scope= "openid profile read write dashboard-api",
                post_logout_redirect_uri= "http://localhost:8080",
                // silent_redirect_uri= window.location.origin + '/static/silent-renew.html',
                // accessTokenExpiringNotificationTime= 10,
                // automaticSilentRenew= true,
                // filterProtocolClaims= true,
                loadUserInfo= true
            });            
        }
    }
}
