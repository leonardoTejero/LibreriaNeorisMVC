using Common.Utils.RestServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using libreriaNeoris.Domain.Dto;
using libreriaNeoris.Domain.Services.Interface;
using libreriaNeoris.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace libreriaNeoris.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRestService _restService;

        public UserController(IUserServices userServices, IRestService restService)
        {
            _userServices = userServices;
            _restService = restService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.GetAllUsers(token);
            return Ok(response);
        }

    }
}
