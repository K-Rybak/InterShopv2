﻿using System.ComponentModel.DataAnnotations;

namespace InternetShop.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле дожно быть заполнено!")]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;
    }
}
