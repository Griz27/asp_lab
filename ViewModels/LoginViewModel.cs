using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}
