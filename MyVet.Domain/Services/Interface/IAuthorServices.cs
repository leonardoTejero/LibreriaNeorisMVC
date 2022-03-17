using Common.Utils.RestServices.Interface;
using libreriaNeoris.Domain.Dto;
using libreriaNeoris.Domain.Dto.Rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libreriaNeoris.Domain.Services.Interface
{
    public interface IAuthorServices
    {
        Task<ResponseDto> GetAllAuthors(string token);
        Task<ResponseDto> InsertAuthor(string token, AuthorDto author);
        Task<ResponseDto> UpdateAuthor(string token, AuthorDto author);
        Task<ResponseDto> DeleteAuthor(string token, int idAuthor);
    }
}
