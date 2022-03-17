using System.ComponentModel.DataAnnotations;

namespace libreriaNeoris.Domain.Dto
{
    public class UserDto
    {

        [Required(ErrorMessage = "El email es requerido")]
        [MaxLength(200)]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public int IdRol { get; set; }
    }
}
