using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class AwardModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [RegularExpression(@"(?:[a-zA-ZА-Яа-яЁё]+)(?:[12][0-9]{3})?",ErrorMessage="Название награды может состоять только из букв, в конце можно указать год")]
        public String Title { get; set; }

        public List<String> Users { get; set; }
    }
}