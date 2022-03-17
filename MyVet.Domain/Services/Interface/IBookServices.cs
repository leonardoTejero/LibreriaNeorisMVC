using libreriaNeoris.Domain.Dto;
using LibreriaNeoris.Domain.Dto.Rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNeoris.Domain.Services.Interface
{
    public interface IBookServices
    {
        Task<ResponseDto> GetAllBooks(string token);
        Task<ResponseDto> InsertBook(string token, InsertBookDto book);
        Task<ResponseDto> UpdateBook(string token, InsertBookDto book);
        Task<ResponseDto> DeleteBook(string token, int idBook);
    }
}
