using Common.Utils.RestServices.Interface;
using libreriaNeoris.Domain.Dto;
using Microsoft.Extensions.Configuration;
using LibreriaNeoris.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Domain.Dto.Book;
using LibreriaNeoris.Domain.Dto.Rest;

namespace LibreriaNeoris.Domain.Services
{
    public class BookServices : IBookServices
    {
        #region Attributes
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public BookServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        public async Task<ResponseDto> GetAllBooks(string token)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerBook").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodGetAllBooks").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                   response.Result = JsonConvert.DeserializeObject<List<ConsultBookDto>>(response.Result.ToString());
                   return response;

            return response;
        }

        public async Task<ResponseDto> InsertBook(string token, InsertBookDto book)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerBook").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodInsertBook").Value;

            InsertBookDto parameters = new InsertBookDto()
            {
                IdAuthor = book.IdAuthor,
                Name = book.Name,
                Synopsis = book.Synopsis,
                NumberPages = book.NumberPages,
                IdEditorial = book.IdEditorial,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;

            return response;
        }

        public async Task<ResponseDto> UpdateBook(string token, InsertBookDto book)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerBook").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodUpdateBook").Value;

            InsertBookDto parameters = new InsertBookDto()
            {
                IdAuthor = book.IdAuthor,
                Name = book.Name,
                Synopsis = book.Synopsis,
                NumberPages = book.NumberPages,
                IdEditorial = book.IdEditorial,
                IdAuthorBook = book.IdAuthorBook,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;

            return response;
        }

        public async Task<ResponseDto> DeleteBook(string token, int idBook)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerBook").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodDeleteBook").Value;



            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("IdBook", idBook);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            response.IsSuccess = true;
            if (response.IsSuccess)
                return response;

            return response;
        }

    }
}
