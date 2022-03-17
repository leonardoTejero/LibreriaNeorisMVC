using LibreriaDomain.Dto.Rest;
using LibreriaDomain.Services.Interface;
using libreriaNeoris.Domain.Dto;
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
    public class EditorialController : Controller
    {
        #region Attributes
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Buider
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEditorials()
        {
            //Extraer la info del calim, autor, expiracion, id user, id rol
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.GetAllEditorials(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditorial(EditorialDto editorial)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.InsertEditorial(token, editorial);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEditorial(EditorialDto editorial)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.UpdateEditorial(token, editorial);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.DeleteEditorial(token, idEditorial);
            return Ok(response);
        }


    }
}
