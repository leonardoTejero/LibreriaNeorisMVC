using Microsoft.AspNetCore.Mvc;
using LibreriaNeoris.Domain.Services.Interface;
using System.Threading.Tasks;
using System.Linq;
using static Common.Utils.Constant.Const;
using libreriaNeoris.Domain.Dto;
using LibreriaNeoris.Domain.Dto.Rest;
using MyLibrary.Domain.Dto.Book;
using libreriaNeoris.Handlers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Libreria.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BookController : Controller
    {
        #region Attributes
        private readonly IBookServices _bookServices;
        #endregion

        #region Builder
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            //Extraer la info del calim, autor, expiracion, id user, id rol
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.GetAllBooks(token);  
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(InsertBookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.InsertBook(token, book);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(ConsultBookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.UpdateBook(token, book);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int idBook)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.DeleteBook(token, idBook);
            return Ok(response);
        }

    }
}
