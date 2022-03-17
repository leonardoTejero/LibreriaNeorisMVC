using libreriaNeoris.Domain.Dto;
using libreriaNeoris.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils.Helpers;
using static Common.Utils.Enums.Enums;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using libreriaNeoris.Domain.Dto.RestServoces;
using Newtonsoft.Json;

namespace libreriaNeoris.Domain.Services
{
    public class UserServices : IUserServices
    {
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public UserServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        #region authentication

        public async Task<ResponseDto> Login(UserDto user)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerAuthentication").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodLogin").Value;

            LoginDto parameters = new LoginDto()
            {
                Password = user.Password,
                UserName = user.UserName, 
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken =await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }

        #endregion

        #region Method
        public async Task<ResponseDto> GetAllUsers(string token)
        {
            string urlBase = _config.GetSection("ApiLibreriaNeoris").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiLibreriaNeoris").GetSection("ControlerUser").Value;
            string method = _config.GetSection("ApiLibreriaNeoris").GetSection("MethodGetAllUsers").Value;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<UserDto>>(response.Result.ToString());


            return response;
        }

        #endregion
    }
}
