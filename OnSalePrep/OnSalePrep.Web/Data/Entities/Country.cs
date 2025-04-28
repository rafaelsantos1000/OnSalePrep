using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Data.Entities;

public class Country : IEntity
{
    public int Id { get; set; }

    [Display(Name = "País")]
    [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caractéres!")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Name { get; set; } = null!;


    public ICollection<State> States { get; set; } = null!;


    [Display(Name = "Estados/Provincias")]
    public int StatesNumber => States == null ? 0 : States.Count;
}
