﻿using InternetShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.Web.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;

        public List<SelectListItem>? CategoryDropDown { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int ApplicationTypeId { get; set; }
        public ApplicationType? ApplicationType { get; set; }
        public List<SelectListItem>? TypeDropDown { get; set; }
    }
}
