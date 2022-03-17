using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibreriaDomain.Dto.Rest
{
    public class EditorialDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La sede es requerida")]
        [MaxLength(100)]
        public string Campus { get; set; }
        public int Id { get; set; }
    }
}
