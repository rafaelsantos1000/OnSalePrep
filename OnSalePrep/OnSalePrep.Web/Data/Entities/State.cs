using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Data.Entities
{
    public class State : IEntity
    {
        public int Id { get ; set; }


        [Display(Name = "Estado/Provincia")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caractéres!")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; } = null!;


        public Country Country { get; set; } = null!;


        public ICollection<City> Cities { get; set; } = null!;


        [Display(Name = "Cidades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
