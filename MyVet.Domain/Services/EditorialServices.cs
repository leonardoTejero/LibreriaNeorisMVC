using Common.Utils.RestServices.Interface;
using LibreriaDomain.Dto.Rest;
using LibreriaDomain.Services.Interface;
using libreriaNeoris.Domain.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDomain.Services
{
    public class EditorialServices : IEditorialServices
    {
        #region Attributes
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public EditorialServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        public async Task<ResponseDto> GetAllEditorials(string token)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodGetAllEditorials").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<EditorialDto>>(response.Result.ToString());

            return response;
        }

        public async Task<ResponseDto> InsertEditorial(string token, EditorialDto editorial)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodInsertEditorial").Value;

            EditorialDto parameters = new EditorialDto()
            {
                Name = editorial.Name,
                Campus = editorial.Campus,    
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;

            return response;
        }

        public async Task<ResponseDto> UpdateEditorial(string token, EditorialDto editorial)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodUpdateEditorial").Value;

            EditorialDto parameters = new EditorialDto()
            {
                Id = editorial.Id,
                Name = editorial.Name,
                Campus = editorial.Campus,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                return response;

            return response;
        }

        public async Task<ResponseDto> DeleteEditorial(string token, int idEditorial)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodDeleteEditorial").Value;

            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("IdEditorial", idEditorial);

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
