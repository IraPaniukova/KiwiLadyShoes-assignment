using System.ComponentModel.DataAnnotations;

namespace KiwiLadyShoes.Models.ViewModels
{
    public class OrdersVM
    {

        //select sa.SaleId, us.Id, us.FirstName, us.LastName, sho.ShoeId, sho.ShoeName, sho.[Image], sa.Quantity, sa.TotalPrice, sho.Price From Sale sa
        //inner join  Shoe sho on sho.ShoeId = sa.ShoeId
        //inner join AspNetUsers as us on sa.UserId = us.Id;
        [Key]
        public int SaleId { get; set; }
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime SaleDate { get; set; }
        public string UserId { get; set; } 
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int ShoeId { get; set; }
        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }
        public string? Image { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public int PaymentId { get; set; }
        public int ShippingId { get; set; }
        [Display(Name = "Unit Price")]
        public decimal Price { get; set; }
        [Display(Name = "Order Total")]
        public decimal TotalPrice { get; set; }
       
    }
}
