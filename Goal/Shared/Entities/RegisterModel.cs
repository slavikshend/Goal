using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goal.Shared.Entities
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказана адреса електронної пошти.")]
        [EmailAddress(ErrorMessage = "Не вказана адреса електронної пошти.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль має складатися з мінімум {2} знаків та максимум {1} знаків.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*\W).*$", ErrorMessage = "Пароль повинен містити принаймні один небуквений символ, одну цифру і одну велику літеру.")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Паролі не збігаются")]
        public string? ConfirmPassword { get; set; }
    }
}