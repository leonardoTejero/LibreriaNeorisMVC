using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreriaNeoris.Domain.Dto.Rest
{
    public class AuthorDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(100)]
        public string LastName { get; set; }
        public int Id { get; set; }
    }
}
