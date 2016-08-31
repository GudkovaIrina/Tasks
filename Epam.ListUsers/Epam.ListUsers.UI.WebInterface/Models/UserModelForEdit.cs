using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class UserModelForEdit
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [RegularExpression(@"^(?:[А-ЯЁ][а-яё]*(?:['-][А-ЯЁ][а-яё]+)? [А-ЯЁ][а-яё]*(?:['-][А-ЯЁ][а-яё]+)?)|(?:[A-Z][a-z]*(?:['-][A-Z][a-z]+)? [A-Z][a-z]*(?:['-][A-Z][a-z]+)?)$",
                            ErrorMessage ="Надо ввести имя и фамилию с заглавной буквы через пробел")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [RegularExpression(@"^(?:(?:0?[1-9])|(?:[12][0-9])|(?:3[01]))\.(?:(?:0[1-9])|(?:[1][0-2]))\.[12][0-9]{3}$",
            ErrorMessage = "Введите дату в формате dd.mm.yyyy")]   
        public string DateOfBirth { get; set; }

        public List<Award> Awards { get; set; }
    }
}