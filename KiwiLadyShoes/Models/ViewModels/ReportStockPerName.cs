using System.ComponentModel.DataAnnotations;

namespace KiwiLadyShoes.Models.ViewModels
{
    public class ReportStockPerName //Ira, 10/111/23
    {
        [Key]
        [Display(Name = "Show Name")]
        public string ShoeName { get; set; }
        [Display(Name = "Full Stock")]
        public int FullStock { get; set; }
    }
}
