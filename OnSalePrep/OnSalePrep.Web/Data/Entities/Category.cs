﻿using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Data.Entities;

public class Category : IEntity
{
    public int Id { get; set; }

    [Display(Name = "Categoria")]
    [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caractéres!")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Name { get; set; } = null!;
}
