using libreriaNeoris.Domain.Dto;
using libreriaNeoris.Domain.Dto.Rest;
using libreriaNeoris.Domain.Services.Interface;
using libreriaNeoris.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace Libreria.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AuthorController : Controller
    {
        #region Attributes
        private readonly IAuthorServices _authorServices;
        #endregion

        #region Buider
        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            //Extraer la info del calim, autor, expiracion, id user, id rol
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
 
            ResponseDto response = await _authorServices.GetAllAuthors(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor(AuthorDto author)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorServices.InsertAuthor(token, author);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorDto author)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorServices.UpdateAuthor(token, author);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int idAuthor)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorServices.DeleteAuthor(token, idAuthor);
            return Ok(response);
        }

    }
}
