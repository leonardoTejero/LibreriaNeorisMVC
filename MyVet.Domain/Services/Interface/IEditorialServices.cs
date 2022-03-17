using LibreriaDomain.Dto.Rest;
using libreriaNeoris.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDomain.Services.Interface
{
    public interface IEditorialServices
    {
        Task<ResponseDto> GetAllEditorials(string token);
        Task<ResponseDto> InsertEditorial(string token, EditorialDto editorial);
        Task<ResponseDto> UpdateEditorial(string token, EditorialDto editorial);
        Task<ResponseDto> DeleteEditorial(string token, int idEditorial);
    }
}
