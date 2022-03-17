using Common.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using libreriaNeoris.Domain.Dto;
using Newtonsoft.Json;

namespace libreriaNeoris.Handlers
{
    public class CustomExceptionHandler: ExceptionFilterAttribute
    {
        /// <summary>
        /// Metodo encargado de capturar todas las Excepciones del proyecto,
        /// Se debe agregar el decorador a cada controller [TypeFilter(typeof(CustomExceptionHandler))]
        /// </summary>
        /// <param name="exception"> Parametro donde queda capturada la Exception </param>
        public override void OnException(ExceptionContext context)
        {

            HttpResponseException responseExeption = new HttpResponseException();


            ResponseDto response = new ResponseDto();

            response.Result = JsonConvert.SerializeObject(context.Exception);
            responseExeption.Status = StatusCodes.Status500InternalServerError;
            response.Message = "Ha ocurrido un error interno";
            context.ExceptionHandled = true;

            context.Result = new ObjectResult(responseExeption.Value)
            {
                StatusCode = responseExeption.Status,
                Value = response
            };

            if (responseExeption.Status == StatusCodes.Status500InternalServerError)
                context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase ="Ha ocurrido un error";
        }
    }
}
