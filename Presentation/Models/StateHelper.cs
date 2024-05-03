using Application.DTOs;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Presentation.Models
{
    public interface IStateHelper
    {
        GetUserDTO User();
    }
    public class StateHelper : IStateHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StateHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public GetUserDTO User()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.UserData);
            return JsonConvert.DeserializeObject<GetUserDTO>(result);
        }
    }
}
