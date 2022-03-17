using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using libreriaNeoris.Domain.Dto;
using libreriaNeoris.Domain.Dto.Rest;
using libreriaNeoris.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libreriaNeoris.Domain.Services
{
    public class AuthorServices : IAuthorServices
    {
        #region Attributes
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public AuthorServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        public async Task<ResponseDto> GetAllAuthors(string token)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerAuthor").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodGetAllAuthors").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<AuthorDto>>(response.Result.ToString());

            return response;
        }

        public async Task<ResponseDto> InsertAuthor(string token, AuthorDto author)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerAuthor").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodInsertAuthor").Value;

            AuthorDto parameters = new AuthorDto()
            {
                Name = author.Name,
                LastName = author.LastName,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;

            return response;
        }

        public async Task<ResponseDto> UpdateAuthor(string token, AuthorDto author)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerAuthor").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodUpdateAuthor").Value;

            AuthorDto parameters = new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;//response.Result = JsonConvert.DeserializeObject<List<ResponseDto>>(response.Result.ToString());

            return response;
        }

        public async Task<ResponseDto> DeleteAuthor(string token, int idAuthor)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerAuthor").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodDeleteAuthor").Value;



            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("IdAuthor", idAuthor);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            //response.IsSuccess = true;
            if (response.IsSuccess)
                return response;

            return response;
        }


    }    
}
