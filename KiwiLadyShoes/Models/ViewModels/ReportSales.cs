using System.ComponentModel.DataAnnotations;
// Added View Module -- Victor Reis - 05/11/2023
namespace KiwiLadyShoes.Models.ViewModels
{
    public class ReportSales
    {
        // select sh.ShoeId,sh.Image,sh.ShoeName,sa.SaleId,sa.Quantity
        // from Shoe sh Join Sale as sa on sh.ShoeId = sa.ShoeId;

        [Key]
        public int ShoeId { get; set; }
        public string Image { get; set; }
        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }
        [Display(Name = "Quantity Sold")]
        public int Quantity { get; set; }
        [Display(Name = "Quantity Available")]
        public int StockQuantity { get; set; }
    }
}
